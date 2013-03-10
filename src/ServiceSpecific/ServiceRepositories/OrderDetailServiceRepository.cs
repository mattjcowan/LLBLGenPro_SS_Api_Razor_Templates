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
    public partial class OrderDetailServiceRepository : EntityServiceRepositoryBase<OrderDetail, OrderDetailEntity, OrderDetailEntityFactory, OrderDetailFieldIndex>, IOrderDetailServiceRepository
    {
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected override EntityType EntityType
        {
            get { return EntityType.OrderDetailEntity; }
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(OrderDetailDataTableRequest request)
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
OrderDetailQueryCollectionRequest
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
            var includeOrder = ((request.Include ?? "").IndexOf("order", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeProduct = ((request.Include ?? "").IndexOf("product", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/orders?filter=orderid:eq:{2}"">{1} Order</a></div>",
                            includeOrder ? (item.Order==null?"0":"1"): "",
                            includeOrder ? "": "",
                            item.OrderId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/products?filter=productid:eq:{2}"">{1} Product</a></div>",
                            includeProduct ? (item.Product==null?"0":"1"): "",
                            includeProduct ? "": "",
                            item.ProductId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.OrderId.ToString(),
                        item.ProductId.ToString(),
                        item.UnitPrice.ToString(),
                        item.Quantity.ToString(),
                        item.Discount.ToString(),

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

        public OrderDetailCollectionResponse Fetch(OrderDetailQueryCollectionRequest request)
        {
            var totalItemCount = 0;
            var entities = base.Fetch(request.Sort, request.Include, request.Filter,
                                      request.Relations, request.Select, request.PageNumber,
                                      request.PageSize, out totalItemCount);
            var response = new OrderDetailCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;
        }
    

        public OrderDetailResponse Fetch(OrderDetailPkRequest request)
        {
            var entity = new OrderDetailEntity();
            entity.OrderId = request.OrderId;
            entity.ProductId = request.ProductId;

            var prefetchPath = ConvertStringToPrefetchPath(EntityType, request.Include);
            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    return new OrderDetailResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public OrderDetailResponse Create(OrderDetailAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if(adapter.SaveEntity(entity, true))
                {
                    return new OrderDetailResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public OrderDetailResponse Update(OrderDetailUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.SaveEntity(entity, true))
                {
                    return new OrderDetailResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public bool Delete(OrderDetailDeleteRequest request)
        {
            var entity = new OrderDetailEntity();
            entity.OrderId = request.OrderId;
            entity.ProductId = request.ProductId;


            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                return adapter.DeleteEntity(entity);
            }
        }

        private const string UcMapCacheKey = "orderdetail-uc-map";
        internal override IDictionary< string, IEntityField2[] > UniqueConstraintMap
        {
            get 
            { 
                var map = CacheClient.Get<IDictionary< string, IEntityField2[] >>(UcMapCacheKey);
                if (map == null)
                {
                    map = new Dictionary< string, IEntityField2[] >();
                    CacheClient.Set(UcMapCacheKey, map);
                }
                return map;
            }
            set { }
        }
    }

    internal static class OrderDetailEntityDtoMapperExtensions
    {
        public static OrderDetail ToDto(this OrderDetailEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static OrderDetail ToDto(this OrderDetailEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            var dto = new OrderDetail();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

              // Map dto properties
                dto.OrderId = entity.OrderId;
                dto.ProductId = entity.ProductId;
                dto.UnitPrice = entity.UnitPrice;
                dto.Quantity = entity.Quantity;
                dto.Discount = entity.Discount;


              // Map dto associations
              // n:1 Order association
              if (entity.Order != null)
              {
                dto.Order = entity.Order.RelatedObject(seenObjects, parents);
              }
              // n:1 Product association
              if (entity.Product != null)
              {
                dto.Product = entity.Product.RelatedObject(seenObjects, parents);
              }

            }
            return dto;
        }

        public static OrderDetailCollection ToDtoCollection(this EntityCollection<OrderDetailEntity> entities)
        {
            var seenObjects = new Hashtable();
            var collection = new OrderDetailCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            return collection;
        }

        public static OrderDetailEntity FromDto(this OrderDetail dto)
        {
            var entity = new OrderDetailEntity();

            // Map entity properties
            entity.OrderId = dto.OrderId;
            entity.ProductId = dto.ProductId;
            entity.UnitPrice = dto.UnitPrice;
            entity.Quantity = dto.Quantity;
            entity.Discount = dto.Discount;


            // Map entity associations
            // n:1 Order association
            if (dto.Order != null)
            {
        entity.Order = dto.Order.FromDto();
            }
            // n:1 Product association
            if (dto.Product != null)
            {
        entity.Product = dto.Product.FromDto();
            }

            return entity;
        }

        public static OrderDetail[] RelatedArray(this EntityCollection<OrderDetailEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new OrderDetail[entities.Count];
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
                    arr[i++] = seenObjects[entity] as OrderDetail;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static OrderDetail RelatedObject(this OrderDetailEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as OrderDetail;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
