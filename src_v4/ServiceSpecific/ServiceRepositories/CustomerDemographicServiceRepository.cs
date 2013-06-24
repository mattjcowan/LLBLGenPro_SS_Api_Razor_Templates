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
using Northwind.Data.Helpers;
using Northwind.Data.HelperClasses;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceRepositories
{ 
    public partial class CustomerDemographicServiceRepository : EntityServiceRepositoryBase<CustomerDemographic, CustomerDemographicEntity, CustomerDemographicEntityFactory>, ICustomerDemographicServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeFetchCustomerDemographicPkRequest(IDataAccessAdapter adapter, CustomerDemographicPkRequest request, CustomerDemographicEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchCustomerDemographicPkRequest(IDataAccessAdapter adapter, CustomerDemographicPkRequest request, CustomerDemographicEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);

        partial void OnBeforeFetchCustomerDemographicQueryCollectionRequest(IDataAccessAdapter adapter, CustomerDemographicQueryCollectionRequest request, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchCustomerDemographicQueryCollectionRequest(IDataAccessAdapter adapter, CustomerDemographicQueryCollectionRequest request, EntityCollection<CustomerDemographicEntity> entities, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);

        partial void OnBeforeCustomerDemographicDeleteRequest(IDataAccessAdapter adapter, CustomerDemographicDeleteRequest request, CustomerDemographicEntity entity);
        partial void OnAfterCustomerDemographicDeleteRequest(IDataAccessAdapter adapter, CustomerDemographicDeleteRequest request, CustomerDemographicEntity entity, ref bool deleted);
        partial void OnBeforeCustomerDemographicUpdateRequest(IDataAccessAdapter adapter, CustomerDemographicUpdateRequest request);
        partial void OnAfterCustomerDemographicUpdateRequest(IDataAccessAdapter adapter, CustomerDemographicUpdateRequest request);
        partial void OnBeforeCustomerDemographicAddRequest(IDataAccessAdapter adapter, CustomerDemographicAddRequest request);
        partial void OnAfterCustomerDemographicAddRequest(IDataAccessAdapter adapter, CustomerDemographicAddRequest request);

        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override EntityType EntityType
        {
            get { return EntityType.CustomerDemographicEntity; }
        }
    
        public CustomerDemographicServiceRepository()
        {
            OnCreateRepository();
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
            
            //Selection
            var iSelectColumns = request.iSelectColumns;

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

            var columnFieldIndexNames = Enum.GetNames(typeof(
CustomerDemographicFieldIndex));
            if(iSelectColumns != null && iSelectColumns.Length > 0){
                try { request.Select = string.Join(",", iSelectColumns.Select(c => columnFieldIndexNames[c]).ToArray()); } catch {}
            }
                
            var entities = Fetch(new CustomerDemographicQueryCollectionRequest
                {
                    Filter = filter, 
                    PageNumber = Convert.ToInt32(pageNumber),
                    PageSize = pageSize,
                    Sort = sort,
                    Include = request.Include,
                    Relations = request.Relations,
                    Select = request.Select,
                    RCache = request.RCache
                });
            var response = new DataTableResponse();
            var includeCustomerCustomerDemos = ((request.Include ?? "").IndexOf("customercustomerdemos", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/customercustomerdemos?filter=customertypeid:eq:{2}"">{1} Customer Customer Demos</a></div>",
                            includeCustomerCustomerDemos ? item.CustomerCustomerDemos.Count.ToString(CultureInfo.InvariantCulture): "", "",
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
            var sortExpression = RepositoryHelper.ConvertStringToSortExpression(EntityType, request.Sort);
            var includeFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);
            var predicateBucket = RepositoryHelper.ConvertStringToRelationPredicateBucket(EntityType, request.Filter, request.Relations);

            EntityCollection<CustomerDemographicEntity> entities;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchCustomerDemographicQueryCollectionRequest(adapter, request, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                entities = base.Fetch(adapter, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, request.RCache, out totalItemCount);
                OnAfterFetchCustomerDemographicQueryCollectionRequest(adapter, request, entities, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }
            var response = new CustomerDemographicCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;            
        }


        public CustomerDemographicResponse Fetch(CustomerDemographicPkRequest request)
        {
            var entity = new CustomerDemographicEntity();
            entity.CustomerTypeId = request.CustomerTypeId;

            var excludedIncludedFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchCustomerDemographicPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);

                var pkPredicate = adapter.CreatePrimaryKeyFilter(entity.Fields.PrimaryKeyFields);
                entity = base.Fetch(adapter, pkPredicate, prefetchPath, excludedIncludedFields, request.RCache);
                if (entity != null)
                {
                    OnAfterFetchCustomerDemographicPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);
                    return new CustomerDemographicResponse(entity.ToDto());
                }
            }
            return new CustomerDemographicResponse(null);
        }

        public CustomerDemographicResponse Create(CustomerDemographicAddRequest request)
        {
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCustomerDemographicAddRequest(adapter, request);
                
                var entity = request.FromDto();
                entity.IsNew = true;
            
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterCustomerDemographicAddRequest(adapter, request);
                    return new CustomerDemographicResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public CustomerDemographicResponse Update(CustomerDemographicUpdateRequest request)
        {
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCustomerDemographicUpdateRequest(adapter, request);
                
                var entity = request.FromDto();
                entity.IsNew = false;
                entity.IsDirty = true;
            
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterCustomerDemographicUpdateRequest(adapter, request);
                    return new CustomerDemographicResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }
        
        public SimpleResponse<bool> Delete(CustomerDemographicDeleteRequest request)
        {
            var entity = new CustomerDemographicEntity();
            entity.CustomerTypeId = request.CustomerTypeId;


            var deleted = false;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCustomerDemographicDeleteRequest(adapter, request, entity);
                deleted = adapter.DeleteEntity(entity);
                OnAfterCustomerDemographicDeleteRequest(adapter, request, entity, ref deleted);
            }
            return new SimpleResponse<bool> { Result = deleted };
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
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }

    internal static partial class CustomerDemographicEntityDtoMapperExtensions
    {
        static partial void OnBeforeEntityToDto(CustomerDemographicEntity entity, Hashtable seenObjects, Hashtable parents);
        static partial void OnAfterEntityToDto(CustomerDemographicEntity entity, Hashtable seenObjects, Hashtable parents, CustomerDemographic dto);
        static partial void OnBeforeEntityCollectionToDtoCollection(EntityCollection<CustomerDemographicEntity> entities);
        static partial void OnAfterEntityCollectionToDtoCollection(EntityCollection<CustomerDemographicEntity> entities, CustomerDemographicCollection dtos);
        static partial void OnBeforeDtoToEntity(CustomerDemographic dto);
        static partial void OnAfterDtoToEntity(CustomerDemographic dto, CustomerDemographicEntity entity);
        
        public static CustomerDemographic ToDto(this CustomerDemographicEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static CustomerDemographic ToDto(this CustomerDemographicEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            OnBeforeEntityToDto(entity, seenObjects, parents);
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
            
            OnAfterEntityToDto(entity, seenObjects, parents, dto);
            return dto;
        }
        
        public static CustomerDemographicCollection ToDtoCollection(this EntityCollection<CustomerDemographicEntity> entities)
        {
            OnBeforeEntityCollectionToDtoCollection(entities);
            var seenObjects = new Hashtable();
            var collection = new CustomerDemographicCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            OnAfterEntityCollectionToDtoCollection(entities, collection);
            return collection;
        }

        public static CustomerDemographicEntity FromDto(this CustomerDemographic dto)
        {
            OnBeforeDtoToEntity(dto);
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

            OnAfterDtoToEntity(dto, entity);
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
