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
    public partial class RegionServiceRepository : EntityServiceRepositoryBase<Region, RegionEntity, RegionEntityFactory>, IRegionServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeRegionDeleteRequest(IDataAccessAdapter adapter, RegionDeleteRequest request, RegionEntity entity);
        partial void OnAfterRegionDeleteRequest(IDataAccessAdapter adapter, RegionDeleteRequest request, RegionEntity entity, ref bool deleted);
        partial void OnBeforeRegionUpdateRequest(IDataAccessAdapter adapter, RegionUpdateRequest request);
        partial void OnAfterRegionUpdateRequest(IDataAccessAdapter adapter, RegionUpdateRequest request);
        partial void OnBeforeRegionAddRequest(IDataAccessAdapter adapter, RegionAddRequest request);
        partial void OnAfterRegionAddRequest(IDataAccessAdapter adapter, RegionAddRequest request);
        partial void OnBeforeFetchRegionPkRequest(IDataAccessAdapter adapter, RegionPkRequest request, RegionEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchRegionPkRequest(IDataAccessAdapter adapter, RegionPkRequest request, RegionEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnBeforeFetchRegionUcRegionDescriptionRequest(IDataAccessAdapter adapter, RegionUcRegionDescriptionRequest request, RegionEntity entity, IPredicateExpression predicate, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchRegionUcRegionDescriptionRequest(IDataAccessAdapter adapter, RegionUcRegionDescriptionRequest request, RegionEntity entity, IPredicateExpression predicate, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);

        partial void OnBeforeFetchRegionQueryCollectionRequest(IDataAccessAdapter adapter, RegionQueryCollectionRequest request, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchRegionQueryCollectionRequest(IDataAccessAdapter adapter, RegionQueryCollectionRequest request, EntityCollection<RegionEntity> entities, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);
        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override EntityType EntityType
        {
            get { return EntityType.RegionEntity; }
        }
    
        public RegionServiceRepository()
        {
            OnCreateRepository();
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(RegionDataTableRequest request)
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
RegionQueryCollectionRequest
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
            var includeTerritories = ((request.Include ?? "").IndexOf("territories", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/territories?filter=regionid:eq:{2}"">{1} Territories</a></div>",
                            includeTerritories ? item.Territories.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeTerritories ? "": "",
                            item.RegionId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.RegionId.ToString(),
                        item.RegionDescription,

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
    
        public RegionCollectionResponse Fetch(RegionQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var sortExpression = RepositoryHelper.ConvertStringToSortExpression(EntityType, request.Sort);
            var includeFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);
            var predicateBucket = RepositoryHelper.ConvertStringToRelationPredicateBucket(EntityType, request.Filter, request.Relations);

            EntityCollection<RegionEntity> entities;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchRegionQueryCollectionRequest(adapter, request, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                entities = base.Fetch(adapter, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, out totalItemCount);
                OnAfterFetchRegionQueryCollectionRequest(adapter, request, entities, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }
            var response = new RegionCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;            
        }

        public RegionResponse Fetch(RegionUcRegionDescriptionRequest request)
        {
            var entity = new RegionEntity();
            entity.RegionDescription = request.RegionDescription;

            var excludedIncludedFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                var predicate = entity.ConstructFilterForUCRegionDescription();
                OnBeforeFetchRegionUcRegionDescriptionRequest(adapter, request, entity, predicate, prefetchPath, excludedIncludedFields);
                if (adapter.FetchEntityUsingUniqueConstraint(entity, predicate, prefetchPath, null, excludedIncludedFields))
                {
                    OnAfterFetchRegionUcRegionDescriptionRequest(adapter, request, entity, predicate, prefetchPath, excludedIncludedFields);
                    return new RegionResponse(entity.ToDto());
                }
            }
            return new RegionResponse(null);
        }
        

        public RegionResponse Fetch(RegionPkRequest request)
        {
            var entity = new RegionEntity();
            entity.RegionId = request.RegionId;

            var excludedIncludedFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchRegionPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    OnAfterFetchRegionPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);
                    return new RegionResponse(entity.ToDto());
                }
            }
            return new RegionResponse(null);
        }

        public RegionResponse Create(RegionAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeRegionAddRequest(adapter, request);
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterRegionAddRequest(adapter, request);
                    return new RegionResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public RegionResponse Update(RegionUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeRegionUpdateRequest(adapter, request);
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterRegionUpdateRequest(adapter, request);
                    return new RegionResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }
        
        public SimpleResponse<bool> Delete(RegionDeleteRequest request)
        {
            var entity = new RegionEntity();
            entity.RegionId = request.RegionId;


            var deleted = false;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeRegionDeleteRequest(adapter, request, entity);
                deleted = adapter.DeleteEntity(entity);
                OnAfterRegionDeleteRequest(adapter, request, entity, ref deleted);
            }
            return new SimpleResponse<bool> { Result = deleted };
        }

        private const string UcMapCacheKey = "region-uc-map";
        internal override IDictionary< string, IEntityField2[] > UniqueConstraintMap
        {
            get 
            { 
                var map = CacheClient.Get<IDictionary< string, IEntityField2[] >>(UcMapCacheKey);
                if (map == null)
                {
                    map = new Dictionary< string, IEntityField2[] >();
                    map.Add("regiondescription", new IEntityField2[]
                        {
                            RegionFields.RegionDescription,                         
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

    internal static partial class RegionEntityDtoMapperExtensions
    {
        static partial void OnBeforeEntityToDto(RegionEntity entity, Hashtable seenObjects, Hashtable parents);
        static partial void OnAfterEntityToDto(RegionEntity entity, Hashtable seenObjects, Hashtable parents, Region dto);
        static partial void OnBeforeEntityCollectionToDtoCollection(EntityCollection<RegionEntity> entities);
        static partial void OnAfterEntityCollectionToDtoCollection(EntityCollection<RegionEntity> entities, RegionCollection dtos);
        static partial void OnBeforeDtoToEntity(Region dto);
        static partial void OnAfterDtoToEntity(Region dto, RegionEntity entity);
        
        public static Region ToDto(this RegionEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static Region ToDto(this RegionEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            OnBeforeEntityToDto(entity, seenObjects, parents);
            var dto = new Region();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

                // Map dto properties
                dto.RegionId = entity.RegionId;
                dto.RegionDescription = entity.RegionDescription;


                // Map dto associations
                // 1:n Territories association of Territory entities
                if (entity.Territories != null && entity.Territories.Any())
                {
                  dto.Territories = new TerritoryCollection(entity.Territories.RelatedArray(seenObjects, parents));
                }

            }
            
            OnAfterEntityToDto(entity, seenObjects, parents, dto);
            return dto;
        }
        
        public static RegionCollection ToDtoCollection(this EntityCollection<RegionEntity> entities)
        {
            OnBeforeEntityCollectionToDtoCollection(entities);
            var seenObjects = new Hashtable();
            var collection = new RegionCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            OnAfterEntityCollectionToDtoCollection(entities, collection);
            return collection;
        }

        public static RegionEntity FromDto(this Region dto)
        {
            OnBeforeDtoToEntity(dto);
            var entity = new RegionEntity();

            // Map entity properties
            entity.RegionId = dto.RegionId;
            entity.RegionDescription = dto.RegionDescription;


            // Map entity associations
            // 1:n Territories association
            if (dto.Territories != null && dto.Territories.Any())
            {
                foreach (var relatedDto in dto.Territories)
                    entity.Territories.Add(relatedDto.FromDto());
            }

            OnAfterDtoToEntity(dto, entity);
            return entity;
        }

        public static Region[] RelatedArray(this EntityCollection<RegionEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new Region[entities.Count];
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
                    arr[i++] = seenObjects[entity] as Region;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static Region RelatedObject(this RegionEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as Region;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
