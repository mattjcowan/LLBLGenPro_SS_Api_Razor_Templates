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
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceRepositories
{ 
    public partial class ProductServiceRepository : EntityServiceRepositoryBase<Product, ProductEntity, ProductEntityFactory, ProductFieldIndex>, IProductServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeProductDeleteRequest(IDataAccessAdapter adapter, ProductDeleteRequest request, ProductEntity entity);
        partial void OnAfterProductDeleteRequest(IDataAccessAdapter adapter, ProductDeleteRequest request, ProductEntity entity, ref bool deleted);
        partial void OnBeforeProductUpdateRequest(IDataAccessAdapter adapter, ProductUpdateRequest request);
        partial void OnAfterProductUpdateRequest(IDataAccessAdapter adapter, ProductUpdateRequest request);
        partial void OnBeforeProductAddRequest(IDataAccessAdapter adapter, ProductAddRequest request);
        partial void OnAfterProductAddRequest(IDataAccessAdapter adapter, ProductAddRequest request);
        partial void OnBeforeFetchProductPkRequest(IDataAccessAdapter adapter, ProductPkRequest request, ProductEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchProductPkRequest(IDataAccessAdapter adapter, ProductPkRequest request, ProductEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnBeforeFetchProductUcProductNameRequest(IDataAccessAdapter adapter, ProductUcProductNameRequest request, ProductEntity entity, IPredicateExpression predicate, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchProductUcProductNameRequest(IDataAccessAdapter adapter, ProductUcProductNameRequest request, ProductEntity entity, IPredicateExpression predicate, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);

        partial void OnBeforeFetchProductQueryCollectionRequest(IDataAccessAdapter adapter, ProductQueryCollectionRequest request, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchProductQueryCollectionRequest(IDataAccessAdapter adapter, ProductQueryCollectionRequest request, EntityCollection<ProductEntity> entities, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);
        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override EntityType EntityType
        {
            get { return EntityType.ProductEntity; }
        }
    
        public ProductServiceRepository()
        {
            OnCreateRepository();
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
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var sortExpression = ConvertStringToSortExpression(request.Sort);
            var includeFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);
            var predicateBucket = ConvertStringToRelationPredicateBucket(request.Filter, request.Relations);

            EntityCollection<ProductEntity> entities;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchProductQueryCollectionRequest(adapter, request, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                entities = base.Fetch(adapter, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, out totalItemCount);
                OnAfterFetchProductQueryCollectionRequest(adapter, request, entities, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }
            var response = new ProductCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;            
        }

        public ProductResponse Fetch(ProductUcProductNameRequest request)
        {
            var entity = new ProductEntity();
            entity.ProductName = request.ProductName;

            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                var predicate = entity.ConstructFilterForUCProductName();
                OnBeforeFetchProductUcProductNameRequest(adapter, request, entity, predicate, prefetchPath, excludedIncludedFields);
                if (adapter.FetchEntityUsingUniqueConstraint(entity, predicate, prefetchPath, null, excludedIncludedFields))
                {
                    OnAfterFetchProductUcProductNameRequest(adapter, request, entity, predicate, prefetchPath, excludedIncludedFields);
                    return new ProductResponse(entity.ToDto());
                }
            }
            return new ProductResponse(null);
        }
        

        public ProductResponse Fetch(ProductPkRequest request)
        {
            var entity = new ProductEntity();
            entity.ProductId = request.ProductId;

            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchProductPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    OnAfterFetchProductPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);
                    return new ProductResponse(entity.ToDto());
                }
            }
            return new ProductResponse(null);
        }

        public ProductResponse Create(ProductAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeProductAddRequest(adapter, request);
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterProductAddRequest(adapter, request);
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
                OnBeforeProductUpdateRequest(adapter, request);
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterProductUpdateRequest(adapter, request);
                    return new ProductResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }
        
        public SimpleResponse<bool> Delete(ProductDeleteRequest request)
        {
            var entity = new ProductEntity();
            entity.ProductId = request.ProductId;


            var deleted = false;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeProductDeleteRequest(adapter, request, entity);
                deleted = adapter.DeleteEntity(entity);
                OnAfterProductDeleteRequest(adapter, request, entity, ref deleted);
            }
            return new SimpleResponse<bool> { Result = deleted };
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
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }

    internal static partial class ProductEntityDtoMapperExtensions
    {
        static partial void OnBeforeEntityToDto(ProductEntity entity, Hashtable seenObjects, Hashtable parents);
        static partial void OnAfterEntityToDto(ProductEntity entity, Hashtable seenObjects, Hashtable parents, Product dto);
        static partial void OnBeforeEntityCollectionToDtoCollection(EntityCollection<ProductEntity> entities);
        static partial void OnAfterEntityCollectionToDtoCollection(EntityCollection<ProductEntity> entities, ProductCollection dtos);
        static partial void OnBeforeDtoToEntity(Product dto);
        static partial void OnAfterDtoToEntity(Product dto, ProductEntity entity);
        
        public static Product ToDto(this ProductEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static Product ToDto(this ProductEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            OnBeforeEntityToDto(entity, seenObjects, parents);
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
            
            OnAfterEntityToDto(entity, seenObjects, parents, dto);
            return dto;
        }
        
        public static ProductCollection ToDtoCollection(this EntityCollection<ProductEntity> entities)
        {
            OnBeforeEntityCollectionToDtoCollection(entities);
            var seenObjects = new Hashtable();
            var collection = new ProductCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            OnAfterEntityCollectionToDtoCollection(entities, collection);
            return collection;
        }

        public static ProductEntity FromDto(this Product dto)
        {
            OnBeforeDtoToEntity(dto);
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

            OnAfterDtoToEntity(dto, entity);
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
