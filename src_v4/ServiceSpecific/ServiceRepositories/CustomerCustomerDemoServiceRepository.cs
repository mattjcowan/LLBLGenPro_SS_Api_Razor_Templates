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
    public partial class CustomerCustomerDemoServiceRepository : EntityServiceRepositoryBase<CustomerCustomerDemo, CustomerCustomerDemoEntity, CustomerCustomerDemoEntityFactory>, ICustomerCustomerDemoServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeFetchCustomerCustomerDemoPkRequest(IDataAccessAdapter adapter, CustomerCustomerDemoPkRequest request, CustomerCustomerDemoEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchCustomerCustomerDemoPkRequest(IDataAccessAdapter adapter, CustomerCustomerDemoPkRequest request, CustomerCustomerDemoEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);

        partial void OnBeforeFetchCustomerCustomerDemoQueryCollectionRequest(IDataAccessAdapter adapter, CustomerCustomerDemoQueryCollectionRequest request, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchCustomerCustomerDemoQueryCollectionRequest(IDataAccessAdapter adapter, CustomerCustomerDemoQueryCollectionRequest request, EntityCollection<CustomerCustomerDemoEntity> entities, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);

        partial void OnBeforeCustomerCustomerDemoDeleteRequest(IDataAccessAdapter adapter, CustomerCustomerDemoDeleteRequest request, CustomerCustomerDemoEntity entity);
        partial void OnAfterCustomerCustomerDemoDeleteRequest(IDataAccessAdapter adapter, CustomerCustomerDemoDeleteRequest request, CustomerCustomerDemoEntity entity, ref bool deleted);
        partial void OnBeforeCustomerCustomerDemoUpdateRequest(IDataAccessAdapter adapter, CustomerCustomerDemoUpdateRequest request);
        partial void OnAfterCustomerCustomerDemoUpdateRequest(IDataAccessAdapter adapter, CustomerCustomerDemoUpdateRequest request);
        partial void OnBeforeCustomerCustomerDemoAddRequest(IDataAccessAdapter adapter, CustomerCustomerDemoAddRequest request);
        partial void OnAfterCustomerCustomerDemoAddRequest(IDataAccessAdapter adapter, CustomerCustomerDemoAddRequest request);

        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override EntityType EntityType
        {
            get { return EntityType.CustomerCustomerDemoEntity; }
        }
    
        public CustomerCustomerDemoServiceRepository()
        {
            OnCreateRepository();
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(CustomerCustomerDemoDataTableRequest request)
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
CustomerCustomerDemoFieldIndex));
            if(iSelectColumns != null && iSelectColumns.Length > 0){
                try { request.Select = string.Join(",", iSelectColumns.Select(c => columnFieldIndexNames[c]).ToArray()); } catch {}
            }
                
            var entities = Fetch(new CustomerCustomerDemoQueryCollectionRequest
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
            var includeCustomer = ((request.Include ?? "").IndexOf("customer", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeCustomerDemographic = ((request.Include ?? "").IndexOf("customerdemographic", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/customers?filter=customerid:eq:{2}"">{1} Customer</a></div>",
                            includeCustomer ? (item.Customer==null?"0":"1"): "", "",
                            item.CustomerId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/customerdemographics?filter=customertypeid:eq:{2}"">{1} Customer Demographic</a></div>",
                            includeCustomerDemographic ? (item.CustomerDemographic==null?"0":"1"): "", "",
                            item.CustomerTypeId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.CustomerId,
                        item.CustomerTypeId,

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
    
        public CustomerCustomerDemoCollectionResponse Fetch(CustomerCustomerDemoQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var sortExpression = RepositoryHelper.ConvertStringToSortExpression(EntityType, request.Sort);
            var includeFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);
            var predicateBucket = RepositoryHelper.ConvertStringToRelationPredicateBucket(EntityType, request.Filter, request.Relations);

            EntityCollection<CustomerCustomerDemoEntity> entities;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchCustomerCustomerDemoQueryCollectionRequest(adapter, request, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                entities = base.Fetch(adapter, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, request.RCache, out totalItemCount);
                OnAfterFetchCustomerCustomerDemoQueryCollectionRequest(adapter, request, entities, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }
            var response = new CustomerCustomerDemoCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;            
        }


        public CustomerCustomerDemoResponse Fetch(CustomerCustomerDemoPkRequest request)
        {
            var entity = new CustomerCustomerDemoEntity();
            entity.CustomerId = request.CustomerId;
            entity.CustomerTypeId = request.CustomerTypeId;

            var excludedIncludedFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchCustomerCustomerDemoPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);

                var pkPredicate = adapter.CreatePrimaryKeyFilter(entity.Fields.PrimaryKeyFields);
                entity = base.Fetch(adapter, pkPredicate, prefetchPath, excludedIncludedFields, request.RCache);
                if (entity != null)
                {
                    OnAfterFetchCustomerCustomerDemoPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);
                    return new CustomerCustomerDemoResponse(entity.ToDto());
                }
            }
            return new CustomerCustomerDemoResponse(null);
        }

        public CustomerCustomerDemoResponse Create(CustomerCustomerDemoAddRequest request)
        {
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCustomerCustomerDemoAddRequest(adapter, request);
                
                var entity = request.FromDto();
                entity.IsNew = true;
            
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterCustomerCustomerDemoAddRequest(adapter, request);
                    return new CustomerCustomerDemoResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public CustomerCustomerDemoResponse Update(CustomerCustomerDemoUpdateRequest request)
        {
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCustomerCustomerDemoUpdateRequest(adapter, request);
                
                var entity = request.FromDto();
                entity.IsNew = false;
                entity.IsDirty = true;
            
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterCustomerCustomerDemoUpdateRequest(adapter, request);
                    return new CustomerCustomerDemoResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }
        
        public SimpleResponse<bool> Delete(CustomerCustomerDemoDeleteRequest request)
        {
            var entity = new CustomerCustomerDemoEntity();
            entity.CustomerId = request.CustomerId;
            entity.CustomerTypeId = request.CustomerTypeId;


            var deleted = false;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCustomerCustomerDemoDeleteRequest(adapter, request, entity);
                deleted = adapter.DeleteEntity(entity);
                OnAfterCustomerCustomerDemoDeleteRequest(adapter, request, entity, ref deleted);
            }
            return new SimpleResponse<bool> { Result = deleted };
        }

        private const string UcMapCacheKey = "customercustomerdemo-uc-map";
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

    internal static partial class CustomerCustomerDemoEntityDtoMapperExtensions
    {
        static partial void OnBeforeEntityToDto(CustomerCustomerDemoEntity entity, Hashtable seenObjects, Hashtable parents);
        static partial void OnAfterEntityToDto(CustomerCustomerDemoEntity entity, Hashtable seenObjects, Hashtable parents, CustomerCustomerDemo dto);
        static partial void OnBeforeEntityCollectionToDtoCollection(EntityCollection<CustomerCustomerDemoEntity> entities);
        static partial void OnAfterEntityCollectionToDtoCollection(EntityCollection<CustomerCustomerDemoEntity> entities, CustomerCustomerDemoCollection dtos);
        static partial void OnBeforeDtoToEntity(CustomerCustomerDemo dto);
        static partial void OnAfterDtoToEntity(CustomerCustomerDemo dto, CustomerCustomerDemoEntity entity);
        
        public static CustomerCustomerDemo ToDto(this CustomerCustomerDemoEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static CustomerCustomerDemo ToDto(this CustomerCustomerDemoEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            OnBeforeEntityToDto(entity, seenObjects, parents);
            var dto = new CustomerCustomerDemo();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

                // Map dto properties
                dto.CustomerId = entity.CustomerId;
                dto.CustomerTypeId = entity.CustomerTypeId;


                // Map dto associations
                // n:1 Customer association
                if (entity.Customer != null)
                {
                  dto.Customer = entity.Customer.RelatedObject(seenObjects, parents);
                }
                // n:1 CustomerDemographic association
                if (entity.CustomerDemographic != null)
                {
                  dto.CustomerDemographic = entity.CustomerDemographic.RelatedObject(seenObjects, parents);
                }

            }
            
            OnAfterEntityToDto(entity, seenObjects, parents, dto);
            return dto;
        }
        
        public static CustomerCustomerDemoCollection ToDtoCollection(this EntityCollection<CustomerCustomerDemoEntity> entities)
        {
            OnBeforeEntityCollectionToDtoCollection(entities);
            var seenObjects = new Hashtable();
            var collection = new CustomerCustomerDemoCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            OnAfterEntityCollectionToDtoCollection(entities, collection);
            return collection;
        }

        public static CustomerCustomerDemoEntity FromDto(this CustomerCustomerDemo dto)
        {
            OnBeforeDtoToEntity(dto);
            var entity = new CustomerCustomerDemoEntity();

            // Map entity properties
            entity.CustomerId = dto.CustomerId;
            entity.CustomerTypeId = dto.CustomerTypeId;


            // Map entity associations
            // n:1 Customer association
            if (dto.Customer != null)
            {
                entity.Customer = dto.Customer.FromDto();
            }
            // n:1 CustomerDemographic association
            if (dto.CustomerDemographic != null)
            {
                entity.CustomerDemographic = dto.CustomerDemographic.FromDto();
            }

            OnAfterDtoToEntity(dto, entity);
            return entity;
        }

        public static CustomerCustomerDemo[] RelatedArray(this EntityCollection<CustomerCustomerDemoEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new CustomerCustomerDemo[entities.Count];
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
                    arr[i++] = seenObjects[entity] as CustomerCustomerDemo;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static CustomerCustomerDemo RelatedObject(this CustomerCustomerDemoEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as CustomerCustomerDemo;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
