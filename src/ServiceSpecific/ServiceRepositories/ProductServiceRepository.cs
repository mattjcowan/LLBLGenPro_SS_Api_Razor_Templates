using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using ServiceStack.Text;
using Northwind.Data;
using Northwind.Data.Dtos;
using Northwind.Data.EntityClasses;
using Northwind.Data.FactoryClasses;
using Northwind.Data.HelperClasses;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceRepositories
{ 
    public partial class ProductServiceRepository : EntityServiceRepositoryBase<Product, ProductEntity, ProductEntityFactory, ProductFieldIndex>, IProductServiceRepository
    {
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected override EntityType EntityType
        {
            get { return EntityType.ProductEntity; }
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(ProductDataTableRequest request)
        {
            //UrlDecode Request Properties
            request.sSearch = System.Web.HttpUtility.UrlDecode(request.sSearch);
            request.Sort = System.Web.HttpUtility.UrlDecode(request.Sort);
            request.Include = System.Web.HttpUtility.UrlDecode(request.Include);
            request.Filter = System.Web.HttpUtility.UrlDecode(request.Filter);
            request.Relations = System.Web.HttpUtility.UrlDecode(request.Relations);
            request.Select = System.Web.HttpUtility.UrlDecode(request.Select);

            //Paging
            var iDisplayStart = request.iDisplayStart + 1; // this is because it passes in the 0 instead of 1, 10 instead of 11, etc...
            iDisplayStart = iDisplayStart <= 0 ? (1+((request.PageNumber-1)*request.PageSize)): iDisplayStart;
            var iDisplayLength = request.iDisplayLength <= 0 ? request.PageSize: request.iDisplayLength;
            var pageNumber = Math.Ceiling(iDisplayStart*1.0/iDisplayLength);
            var pageSize = iDisplayLength;
            //Sorting
            var sort = request.Sort;
            if (request.iSortingCols > 0 && request.iSortCol_0 >= 0)
            {
                sort = string.Format("{0}:{1}", FieldMap.Keys.ElementAt(Convert.ToInt32(request.iSortCol_0)), request.sSortDir_0);
            }
            //Search
            var filter = request.Filter;
            var searchStr = string.Empty;
            if (!string.IsNullOrEmpty(request.sSearch))
            {
                // process int field searches
                var n = 0;
                var searchStrAsInt = -1;
                if (int.TryParse(request.sSearch, out searchStrAsInt))
                {
                    foreach (var fm in FieldMap)
                    {
                        if (fm.Value.DataType.IsNumericType())
                        {
                            n++;
                            searchStr += string.Format("({0}:eq:{1})", fm.Key, searchStrAsInt);
                        }
                    }
                }
                // process string field searches
                foreach (var fm in FieldMap)
                {
                    if (fm.Value.DataType == typeof (string)/* && fm.Value.MaxLength < 2000*/)
                    {
                        n++;
                        searchStr += string.Format("({0}:lk:*{1}*)", fm.Key, request.sSearch);
                    }
                }
                searchStr = n > 1 ? "(|" + searchStr + ")": searchStr.Trim('(', ')');

                filter = string.IsNullOrEmpty(filter) ? searchStr
                    : string.Format("(^{0}{1})", 
                    filter.StartsWith("(") ? filter: "(" + filter + ")",
                    searchStr.StartsWith("(") ? searchStr : "(" + searchStr + ")");
            }

            var entities = Fetch(new 
ProductQueryCollectionRequest
                {
                    Filter = filter, 
                    PageNumber = Convert.ToInt32(pageNumber),
                    PageSize = pageSize,
                    Sort = sort,
                    Include = request.Include,
                    Relations = request.Relations,
                    Select = request.Select,
                });
            var response = new DataTableResponse();
            var includeCategory = ((request.Include ?? "").IndexOf("category", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeOrderDetails = ((request.Include ?? "").IndexOf("orderdetails", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeSupplier = ((request.Include ?? "").IndexOf("supplier", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/categories?filter=categoryid:eq:{2}"">{1} Category</a></div>",
                            includeCategory ? (item.Category==null?"0":"1"): "",
                            includeCategory ? "": "",
                            item.CategoryId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/orderdetails?filter=productid:eq:{2}"">{1} Order Details</a></div>",
                            includeOrderDetails ? item.OrderDetails.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeOrderDetails ? "": "",
                            item.ProductId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/suppliers?filter=supplierid:eq:{2}"">{1} Supplier</a></div>",
                            includeSupplier ? (item.Supplier==null?"0":"1"): "",
                            includeSupplier ? "": "",
                            item.SupplierId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.ProductId.ToString(),
                        item.ProductName,
                        item.SupplierId.ToString(),
                        item.CategoryId.ToString(),
                        item.QuantityPerUnit,
                        item.UnitPrice.ToString(),
                        item.UnitsInStock.ToString(),
                        item.UnitsOnOrder.ToString(),
                        item.ReorderLevel.ToString(),
                        item.Discontinued.ToString(),

                        string.Join("", relatedDivs.ToArray())
                    });
            }
            response.sEcho = request.sEcho;
            // total records in the database before datatables search
            response.iTotalRecords = entities.Paging.TotalCount;
            // total records in the database after datatables search
            response.iTotalDisplayRecords = entities.Paging.TotalCount;
            return response;
        }

        public ProductCollectionResponse Fetch(ProductQueryCollectionRequest request)
        {
            var totalItemCount = 0;
            var entities = base.Fetch(request.Sort, request.Include, request.Filter,
                                      request.Relations, request.Select, request.PageNumber,
                                      request.PageSize, out totalItemCount);
            var response = new ProductCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;
        }
    
        public ProductResponse Fetch(ProductUcProductNameRequest request)
        {
            var entity = new ProductEntity();
            entity.ProductName = request.ProductName;

            var prefetchPath = ConvertStringToPrefetchPath(EntityType, request.Include);
            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntityUsingUniqueConstraint(entity, entity.ConstructFilterForUCProductName(), prefetchPath, null, excludedIncludedFields))
                {
                    return new ProductResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public ProductResponse Fetch(ProductPkRequest request)
        {
            var entity = new ProductEntity();
            entity.ProductId = request.ProductId;

            var prefetchPath = ConvertStringToPrefetchPath(EntityType, request.Include);
            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    return new ProductResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public ProductResponse Create(ProductAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if(adapter.SaveEntity(entity, true))
                {
                    return new ProductResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public ProductResponse Update(ProductUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.SaveEntity(entity, true))
                {
                    return new ProductResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public bool Delete(ProductDeleteRequest request)
        {
            var entity = new ProductEntity();
            entity.ProductId = request.ProductId;


            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                return adapter.DeleteEntity(entity);
            }
        }

        private const string UcMapCacheKey = "product-uc-map";
        internal override IDictionary< string, IEntityField2[] > UniqueConstraintMap
        {
            get 
            { 
                var map = CacheClient.Get<IDictionary< string, IEntityField2[] >>(UcMapCacheKey);
                if (map == null)
                {
                    map = new Dictionary< string, IEntityField2[] >();
                    map.Add("productname", new IEntityField2[]
                        {
                            ProductFields.ProductName,                         
                        });
                    CacheClient.Set(UcMapCacheKey, map);
                }
                return map;
            }
            set { }
        }
    }

    internal static class ProductEntityDtoMapperExtensions
    {
        public static Product ToDto(this ProductEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static Product ToDto(this ProductEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            var dto = new Product();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

              // Map dto properties
                dto.ProductId = entity.ProductId;
                dto.ProductName = entity.ProductName;
                dto.SupplierId = entity.SupplierId;
                dto.CategoryId = entity.CategoryId;
                dto.QuantityPerUnit = entity.QuantityPerUnit;
                dto.UnitPrice = entity.UnitPrice;
                dto.UnitsInStock = entity.UnitsInStock;
                dto.UnitsOnOrder = entity.UnitsOnOrder;
                dto.ReorderLevel = entity.ReorderLevel;
                dto.Discontinued = entity.Discontinued;


              // Map dto associations
              // n:1 Category association
              if (entity.Category != null)
              {
                dto.Category = entity.Category.RelatedObject(seenObjects, parents);
              }
              // 1:n OrderDetails association of OrderDetail entities
              if (entity.OrderDetails != null && entity.OrderDetails.Any())
              {
                dto.OrderDetails = new OrderDetailCollection(entity.OrderDetails.RelatedArray(seenObjects, parents));
              }
              // n:1 Supplier association
              if (entity.Supplier != null)
              {
                dto.Supplier = entity.Supplier.RelatedObject(seenObjects, parents);
              }

            }
            return dto;
        }

        public static ProductCollection ToDtoCollection(this EntityCollection<ProductEntity> entities)
        {
            var seenObjects = new Hashtable();
            var collection = new ProductCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            return collection;
        }

        public static ProductEntity FromDto(this Product dto)
        {
            var entity = new ProductEntity();

            // Map entity properties
            entity.ProductId = dto.ProductId;
            entity.ProductName = dto.ProductName;
            entity.SupplierId = dto.SupplierId;
            entity.CategoryId = dto.CategoryId;
            entity.QuantityPerUnit = dto.QuantityPerUnit;
            entity.UnitPrice = dto.UnitPrice;
            entity.UnitsInStock = dto.UnitsInStock;
            entity.UnitsOnOrder = dto.UnitsOnOrder;
            entity.ReorderLevel = dto.ReorderLevel;
            entity.Discontinued = dto.Discontinued;


            // Map entity associations
            // n:1 Category association
            if (dto.Category != null)
            {
        entity.Category = dto.Category.FromDto();
            }
            // 1:n OrderDetails association
            if (dto.OrderDetails != null && dto.OrderDetails.Any())
            {
                foreach (var relatedDto in dto.OrderDetails)
                    entity.OrderDetails.Add(relatedDto.FromDto());
            }
            // n:1 Supplier association
            if (dto.Supplier != null)
            {
        entity.Supplier = dto.Supplier.FromDto();
            }

            return entity;
        }

        public static Product[] RelatedArray(this EntityCollection<ProductEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new Product[entities.Count];
            var i = 0;

            foreach (var entity in entities)
            {
                if (parents.Contains(entity))
                {
                    // - avoid all cyclic references and return null
                    // - another option is to 'continue' and just disregard this one entity; however,
                    // if this is a collection this would lead the client app to believe that other
                    // items are part of the collection and not the parent item, which is misleading and false
                    // - it is therefore better to just return null, indicating nothing is being retrieved
                    // for the property all-together
                    return null;
                }
            }

            foreach (var entity in entities)
            {
                if (seenObjects.Contains(entity))
                {
                    arr[i++] = seenObjects[entity] as Product;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static Product RelatedObject(this ProductEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entity)
            {
                return null;
            }

            if (seenObjects.Contains(entity))
            {
                if (parents.Contains(entity))
                {
                    // avoid cyclic references
                    return null;
                }
                else
                {
                    return seenObjects[entity] as Product;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
