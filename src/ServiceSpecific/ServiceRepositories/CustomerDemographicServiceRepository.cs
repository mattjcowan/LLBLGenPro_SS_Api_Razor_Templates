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
    public partial class CustomerDemographicServiceRepository : EntityServiceRepositoryBase<CustomerDemographic, CustomerDemographicEntity, CustomerDemographicEntityFactory, CustomerDemographicFieldIndex>, ICustomerDemographicServiceRepository
    {
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected override EntityType EntityType
        {
            get { return EntityType.CustomerDemographicEntity; }
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(CustomerDemographicDataTableRequest request)
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
CustomerDemographicQueryCollectionRequest
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
            var includeCustomerCustomerDemos = ((request.Include ?? "").IndexOf("customercustomerdemos", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/customercustomerdemos?filter=customertypeid:eq:{2}"">{1} Customer Customer Demos</a></div>",
                            includeCustomerCustomerDemos ? item.CustomerCustomerDemos.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeCustomerCustomerDemos ? "": "",
                            item.CustomerTypeId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.CustomerTypeId,
                        item.CustomerDesc,

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

        public CustomerDemographicCollectionResponse Fetch(CustomerDemographicQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var entities = base.Fetch(request.Sort, request.Include, request.Filter,
                                      request.Relations, request.Select, request.PageNumber,
                                      request.PageSize, request.Limit, out totalItemCount);
            var response = new CustomerDemographicCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;
        }
    

        public CustomerDemographicResponse Fetch(CustomerDemographicPkRequest request)
        {
            var entity = new CustomerDemographicEntity();
            entity.CustomerTypeId = request.CustomerTypeId;

            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    return new CustomerDemographicResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public CustomerDemographicResponse Create(CustomerDemographicAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if(adapter.SaveEntity(entity, true))
                {
                    return new CustomerDemographicResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public CustomerDemographicResponse Update(CustomerDemographicUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.SaveEntity(entity, true))
                {
                    return new CustomerDemographicResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public bool Delete(CustomerDemographicDeleteRequest request)
        {
            var entity = new CustomerDemographicEntity();
            entity.CustomerTypeId = request.CustomerTypeId;


            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                return adapter.DeleteEntity(entity);
            }
        }

        private const string UcMapCacheKey = "customerdemographic-uc-map";
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

    internal static class CustomerDemographicEntityDtoMapperExtensions
    {
        public static CustomerDemographic ToDto(this CustomerDemographicEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static CustomerDemographic ToDto(this CustomerDemographicEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            var dto = new CustomerDemographic();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

                // Map dto properties
                dto.CustomerTypeId = entity.CustomerTypeId;
                dto.CustomerDesc = entity.CustomerDesc;


                // Map dto associations
                // 1:n CustomerCustomerDemos association of CustomerCustomerDemo entities
                if (entity.CustomerCustomerDemos != null && entity.CustomerCustomerDemos.Any())
                {
                  dto.CustomerCustomerDemos = new CustomerCustomerDemoCollection(entity.CustomerCustomerDemos.RelatedArray(seenObjects, parents));
                }

            }
            return dto;
        }

        public static CustomerDemographicCollection ToDtoCollection(this EntityCollection<CustomerDemographicEntity> entities)
        {
            var seenObjects = new Hashtable();
            var collection = new CustomerDemographicCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            return collection;
        }

        public static CustomerDemographicEntity FromDto(this CustomerDemographic dto)
        {
            var entity = new CustomerDemographicEntity();

            // Map entity properties
            entity.CustomerTypeId = dto.CustomerTypeId;
            entity.CustomerDesc = dto.CustomerDesc;


            // Map entity associations
            // 1:n CustomerCustomerDemos association
            if (dto.CustomerCustomerDemos != null && dto.CustomerCustomerDemos.Any())
            {
                foreach (var relatedDto in dto.CustomerCustomerDemos)
                    entity.CustomerCustomerDemos.Add(relatedDto.FromDto());
            }

            return entity;
        }

        public static CustomerDemographic[] RelatedArray(this EntityCollection<CustomerDemographicEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new CustomerDemographic[entities.Count];
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
                    arr[i++] = seenObjects[entity] as CustomerDemographic;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static CustomerDemographic RelatedObject(this CustomerDemographicEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as CustomerDemographic;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
