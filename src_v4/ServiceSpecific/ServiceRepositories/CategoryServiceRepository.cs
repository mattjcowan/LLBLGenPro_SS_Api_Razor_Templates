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
    public partial class CategoryServiceRepository : EntityServiceRepositoryBase<Category, CategoryEntity, CategoryEntityFactory>, ICategoryServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeFetchCategoryPkRequest(IDataAccessAdapter adapter, CategoryPkRequest request, CategoryEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchCategoryPkRequest(IDataAccessAdapter adapter, CategoryPkRequest request, CategoryEntity entity, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnBeforeFetchCategoryUcCategoryNameRequest(IDataAccessAdapter adapter, CategoryUcCategoryNameRequest request, CategoryEntity entity, IPredicateExpression predicate, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
        partial void OnAfterFetchCategoryUcCategoryNameRequest(IDataAccessAdapter adapter, CategoryUcCategoryNameRequest request, CategoryEntity entity, IPredicateExpression predicate, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);

        partial void OnBeforeFetchCategoryQueryCollectionRequest(IDataAccessAdapter adapter, CategoryQueryCollectionRequest request, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchCategoryQueryCollectionRequest(IDataAccessAdapter adapter, CategoryQueryCollectionRequest request, EntityCollection<CategoryEntity> entities, SortExpression sortExpression, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath2 prefetchPath, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);

        partial void OnBeforeCategoryDeleteRequest(IDataAccessAdapter adapter, CategoryDeleteRequest request, CategoryEntity entity);
        partial void OnAfterCategoryDeleteRequest(IDataAccessAdapter adapter, CategoryDeleteRequest request, CategoryEntity entity, ref bool deleted);
        partial void OnBeforeCategoryUpdateRequest(IDataAccessAdapter adapter, CategoryUpdateRequest request);
        partial void OnAfterCategoryUpdateRequest(IDataAccessAdapter adapter, CategoryUpdateRequest request);
        partial void OnBeforeCategoryAddRequest(IDataAccessAdapter adapter, CategoryAddRequest request);
        partial void OnAfterCategoryAddRequest(IDataAccessAdapter adapter, CategoryAddRequest request);

        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override EntityType EntityType
        {
            get { return EntityType.CategoryEntity; }
        }
    
        public CategoryServiceRepository()
        {
            OnCreateRepository();
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(CategoryDataTableRequest request)
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
CategoryFieldIndex));
            if(iSelectColumns != null && iSelectColumns.Length > 0){
                try { request.Select = string.Join(",", iSelectColumns.Select(c => columnFieldIndexNames[c]).ToArray()); } catch {}
            }
                
            var entities = Fetch(new CategoryQueryCollectionRequest
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
            var includeProducts = ((request.Include ?? "").IndexOf("products", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/products?filter=categoryid:eq:{2}"">{1} Products</a></div>",
                            includeProducts ? item.Products.Count.ToString(CultureInfo.InvariantCulture): "", "",
                            item.CategoryId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.CategoryId.ToString(),
                        item.CategoryName,
                        item.Description,
                        (item.Picture == null ? null: string.Format("<ul class=\"thumbnails\"><li class=\"span12\"><div class=\"thumbnail\">{0}</div></li></ul>", item.Picture.ToImageSrc(null, 160))),
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
    
        public CategoryCollectionResponse Fetch(CategoryQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var sortExpression = RepositoryHelper.ConvertStringToSortExpression(EntityType, request.Sort);
            var includeFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);
            var predicateBucket = RepositoryHelper.ConvertStringToRelationPredicateBucket(EntityType, request.Filter, request.Relations);

            EntityCollection<CategoryEntity> entities;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchCategoryQueryCollectionRequest(adapter, request, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                entities = base.Fetch(adapter, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, request.RCache, out totalItemCount);
                OnAfterFetchCategoryQueryCollectionRequest(adapter, request, entities, sortExpression, includeFields, prefetchPath, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }
            var response = new CategoryCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;            
        }

        public CategoryResponse Fetch(CategoryUcCategoryNameRequest request)
        {
            var entity = new CategoryEntity();
            entity.CategoryName = request.CategoryName;

            var excludedIncludedFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                var ucPredicate = entity.ConstructFilterForUCCategoryName();
                OnBeforeFetchCategoryUcCategoryNameRequest(adapter, request, entity, ucPredicate, prefetchPath, excludedIncludedFields);
                
                entity = base.Fetch(adapter, ucPredicate, prefetchPath, excludedIncludedFields, request.RCache);
                if (entity != null)
                {
                    OnAfterFetchCategoryUcCategoryNameRequest(adapter, request, entity, ucPredicate, prefetchPath, excludedIncludedFields);
                    return new CategoryResponse(entity.ToDto());
                }
            }
            return new CategoryResponse(null);
        }
        

        public CategoryResponse Fetch(CategoryPkRequest request)
        {
            var entity = new CategoryEntity();
            entity.CategoryId = request.CategoryId;

            var excludedIncludedFields = RepositoryHelper.ConvertStringToExcludedIncludedFields(EntityType, request.Select);
            var prefetchPath = RepositoryHelper.ConvertStringToPrefetchPath(EntityType, request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchCategoryPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);

                var pkPredicate = adapter.CreatePrimaryKeyFilter(entity.Fields.PrimaryKeyFields);
                entity = base.Fetch(adapter, pkPredicate, prefetchPath, excludedIncludedFields, request.RCache);
                if (entity != null)
                {
                    OnAfterFetchCategoryPkRequest(adapter, request, entity, prefetchPath, excludedIncludedFields);
                    return new CategoryResponse(entity.ToDto());
                }
            }
            return new CategoryResponse(null);
        }

        public CategoryResponse Create(CategoryAddRequest request)
        {
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCategoryAddRequest(adapter, request);
                
                var entity = request.FromDto();
                entity.IsNew = true;
            
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterCategoryAddRequest(adapter, request);
                    return new CategoryResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public CategoryResponse Update(CategoryUpdateRequest request)
        {
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCategoryUpdateRequest(adapter, request);
                
                var entity = request.FromDto();
                entity.IsNew = false;
                entity.IsDirty = true;
            
                if (adapter.SaveEntity(entity, true))
                {
                    OnAfterCategoryUpdateRequest(adapter, request);
                    return new CategoryResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }
        
        public SimpleResponse<bool> Delete(CategoryDeleteRequest request)
        {
            var entity = new CategoryEntity();
            entity.CategoryId = request.CategoryId;


            var deleted = false;
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeCategoryDeleteRequest(adapter, request, entity);
                deleted = adapter.DeleteEntity(entity);
                OnAfterCategoryDeleteRequest(adapter, request, entity, ref deleted);
            }
            return new SimpleResponse<bool> { Result = deleted };
        }

        private const string UcMapCacheKey = "category-uc-map";
        internal override IDictionary< string, IEntityField2[] > UniqueConstraintMap
        {
            get 
            { 
                var map = CacheClient.Get<IDictionary< string, IEntityField2[] >>(UcMapCacheKey);
                if (map == null)
                {
                    map = new Dictionary< string, IEntityField2[] >();
                    map.Add("categoryname", new IEntityField2[]
                        {
                            CategoryFields.CategoryName,                         
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

    internal static partial class CategoryEntityDtoMapperExtensions
    {
        static partial void OnBeforeEntityToDto(CategoryEntity entity, Hashtable seenObjects, Hashtable parents);
        static partial void OnAfterEntityToDto(CategoryEntity entity, Hashtable seenObjects, Hashtable parents, Category dto);
        static partial void OnBeforeEntityCollectionToDtoCollection(EntityCollection<CategoryEntity> entities);
        static partial void OnAfterEntityCollectionToDtoCollection(EntityCollection<CategoryEntity> entities, CategoryCollection dtos);
        static partial void OnBeforeDtoToEntity(Category dto);
        static partial void OnAfterDtoToEntity(Category dto, CategoryEntity entity);
        
        public static Category ToDto(this CategoryEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static Category ToDto(this CategoryEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            OnBeforeEntityToDto(entity, seenObjects, parents);
            var dto = new Category();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

                // Map dto properties
                dto.CategoryId = entity.CategoryId;
                dto.CategoryName = entity.CategoryName;
                dto.Description = entity.Description;
                dto.Picture = entity.Picture;


                // Map dto associations
                // 1:n Products association of Product entities
                if (entity.Products != null && entity.Products.Any())
                {
                  dto.Products = new ProductCollection(entity.Products.RelatedArray(seenObjects, parents));
                }

            }
            
            OnAfterEntityToDto(entity, seenObjects, parents, dto);
            return dto;
        }
        
        public static CategoryCollection ToDtoCollection(this EntityCollection<CategoryEntity> entities)
        {
            OnBeforeEntityCollectionToDtoCollection(entities);
            var seenObjects = new Hashtable();
            var collection = new CategoryCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            OnAfterEntityCollectionToDtoCollection(entities, collection);
            return collection;
        }

        public static CategoryEntity FromDto(this Category dto)
        {
            OnBeforeDtoToEntity(dto);
            var entity = new CategoryEntity();

            // Map entity properties
            entity.CategoryId = dto.CategoryId;
            entity.CategoryName = dto.CategoryName;
            entity.Description = dto.Description;
            if (dto.Picture != null) entity.Picture = dto.Picture;


            // Map entity associations
            // 1:n Products association
            if (dto.Products != null && dto.Products.Any())
            {
                foreach (var relatedDto in dto.Products)
                    entity.Products.Add(relatedDto.FromDto());
            }

            OnAfterDtoToEntity(dto, entity);
            return entity;
        }

        public static Category[] RelatedArray(this EntityCollection<CategoryEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new Category[entities.Count];
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
                    arr[i++] = seenObjects[entity] as Category;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static Category RelatedObject(this CategoryEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as Category;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
