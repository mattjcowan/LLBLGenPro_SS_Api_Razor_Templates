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
    public partial class ShipperServiceRepository : EntityServiceRepositoryBase<Shipper, ShipperEntity, ShipperEntityFactory, ShipperFieldIndex>, IShipperServiceRepository
    {
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected override EntityType EntityType
        {
            get { return EntityType.ShipperEntity; }
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(ShipperDataTableRequest request)
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
ShipperQueryCollectionRequest
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
            var includeOrders = ((request.Include ?? "").IndexOf("orders", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/orders?filter=shipvia:eq:{2}"">{1} Orders</a></div>",
                            includeOrders ? item.Orders.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeOrders ? "": "",
                            item.ShipperId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.ShipperId.ToString(),
                        item.CompanyName,
                        item.Phone,

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

        public ShipperCollectionResponse Fetch(ShipperQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var entities = base.Fetch(request.Sort, request.Include, request.Filter,
                                      request.Relations, request.Select, request.PageNumber,
                                      request.PageSize, request.Limit, out totalItemCount);
            var response = new ShipperCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;
        }
    
        public ShipperResponse Fetch(ShipperUcShipperNameRequest request)
        {
            var entity = new ShipperEntity();
            entity.CompanyName = request.CompanyName;

            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntityUsingUniqueConstraint(entity, entity.ConstructFilterForUCCompanyName(), prefetchPath, null, excludedIncludedFields))
                {
                    return new ShipperResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public ShipperResponse Fetch(ShipperPkRequest request)
        {
            var entity = new ShipperEntity();
            entity.ShipperId = request.ShipperId;

            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    return new ShipperResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public ShipperResponse Create(ShipperAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if(adapter.SaveEntity(entity, true))
                {
                    return new ShipperResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public ShipperResponse Update(ShipperUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.SaveEntity(entity, true))
                {
                    return new ShipperResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public bool Delete(ShipperDeleteRequest request)
        {
            var entity = new ShipperEntity();
            entity.ShipperId = request.ShipperId;


            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                return adapter.DeleteEntity(entity);
            }
        }

        private const string UcMapCacheKey = "shipper-uc-map";
        internal override IDictionary< string, IEntityField2[] > UniqueConstraintMap
        {
            get 
            { 
                var map = CacheClient.Get<IDictionary< string, IEntityField2[] >>(UcMapCacheKey);
                if (map == null)
                {
                    map = new Dictionary< string, IEntityField2[] >();
                    map.Add("companyname", new IEntityField2[]
                        {
                            ShipperFields.CompanyName,                         
                        });
                    CacheClient.Set(UcMapCacheKey, map);
                }
                return map;
            }
            set { }
        }
    }

    internal static class ShipperEntityDtoMapperExtensions
    {
        public static Shipper ToDto(this ShipperEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static Shipper ToDto(this ShipperEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            var dto = new Shipper();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

                // Map dto properties
                dto.ShipperId = entity.ShipperId;
                dto.CompanyName = entity.CompanyName;
                dto.Phone = entity.Phone;


                // Map dto associations
                // 1:n Orders association of Order entities
                if (entity.Orders != null && entity.Orders.Any())
                {
                  dto.Orders = new OrderCollection(entity.Orders.RelatedArray(seenObjects, parents));
                }

            }
            return dto;
        }

        public static ShipperCollection ToDtoCollection(this EntityCollection<ShipperEntity> entities)
        {
            var seenObjects = new Hashtable();
            var collection = new ShipperCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            return collection;
        }

        public static ShipperEntity FromDto(this Shipper dto)
        {
            var entity = new ShipperEntity();

            // Map entity properties
            entity.ShipperId = dto.ShipperId;
            entity.CompanyName = dto.CompanyName;
            entity.Phone = dto.Phone;


            // Map entity associations
            // 1:n Orders association
            if (dto.Orders != null && dto.Orders.Any())
            {
                foreach (var relatedDto in dto.Orders)
                    entity.Orders.Add(relatedDto.FromDto());
            }

            return entity;
        }

        public static Shipper[] RelatedArray(this EntityCollection<ShipperEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new Shipper[entities.Count];
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
                    arr[i++] = seenObjects[entity] as Shipper;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static Shipper RelatedObject(this ShipperEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as Shipper;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
