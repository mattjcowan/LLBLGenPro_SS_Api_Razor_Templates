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
    public partial class EmployeeTerritoryServiceRepository : EntityServiceRepositoryBase<EmployeeTerritory, EmployeeTerritoryEntity, EmployeeTerritoryEntityFactory, EmployeeTerritoryFieldIndex>, IEmployeeTerritoryServiceRepository
    {
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected override EntityType EntityType
        {
            get { return EntityType.EmployeeTerritoryEntity; }
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(EmployeeTerritoryDataTableRequest request)
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
EmployeeTerritoryQueryCollectionRequest
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
            var includeEmployee = ((request.Include ?? "").IndexOf("employee", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeTerritory = ((request.Include ?? "").IndexOf("territory", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/employees?filter=employeeid:eq:{2}"">{1} Employee</a></div>",
                            includeEmployee ? (item.Employee==null?"0":"1"): "",
                            includeEmployee ? "": "",
                            item.EmployeeId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/territories?filter=territoryid:eq:{2}"">{1} Territory</a></div>",
                            includeTerritory ? (item.Territory==null?"0":"1"): "",
                            includeTerritory ? "": "",
                            item.TerritoryId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.EmployeeId.ToString(),
                        item.TerritoryId,

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

        public EmployeeTerritoryCollectionResponse Fetch(EmployeeTerritoryQueryCollectionRequest request)
        {
            var totalItemCount = 0;
            var entities = base.Fetch(request.Sort, request.Include, request.Filter,
                                      request.Relations, request.Select, request.PageNumber,
                                      request.PageSize, out totalItemCount);
            var response = new EmployeeTerritoryCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;
        }
    

        public EmployeeTerritoryResponse Fetch(EmployeeTerritoryPkRequest request)
        {
            var entity = new EmployeeTerritoryEntity();
            entity.EmployeeId = request.EmployeeId;
            entity.TerritoryId = request.TerritoryId;

            var prefetchPath = ConvertStringToPrefetchPath(EntityType, request.Include);
            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    return new EmployeeTerritoryResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public EmployeeTerritoryResponse Create(EmployeeTerritoryAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if(adapter.SaveEntity(entity, true))
                {
                    return new EmployeeTerritoryResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public EmployeeTerritoryResponse Update(EmployeeTerritoryUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.SaveEntity(entity, true))
                {
                    return new EmployeeTerritoryResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public bool Delete(EmployeeTerritoryDeleteRequest request)
        {
            var entity = new EmployeeTerritoryEntity();
            entity.EmployeeId = request.EmployeeId;
            entity.TerritoryId = request.TerritoryId;


            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                return adapter.DeleteEntity(entity);
            }
        }

        private const string UcMapCacheKey = "employeeterritory-uc-map";
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

    internal static class EmployeeTerritoryEntityDtoMapperExtensions
    {
        public static EmployeeTerritory ToDto(this EmployeeTerritoryEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static EmployeeTerritory ToDto(this EmployeeTerritoryEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            var dto = new EmployeeTerritory();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

              // Map dto properties
                dto.EmployeeId = entity.EmployeeId;
                dto.TerritoryId = entity.TerritoryId;


              // Map dto associations
              // n:1 Employee association
              if (entity.Employee != null)
              {
                dto.Employee = entity.Employee.RelatedObject(seenObjects, parents);
              }
              // n:1 Territory association
              if (entity.Territory != null)
              {
                dto.Territory = entity.Territory.RelatedObject(seenObjects, parents);
              }

            }
            return dto;
        }

        public static EmployeeTerritoryCollection ToDtoCollection(this EntityCollection<EmployeeTerritoryEntity> entities)
        {
            var seenObjects = new Hashtable();
            var collection = new EmployeeTerritoryCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            return collection;
        }

        public static EmployeeTerritoryEntity FromDto(this EmployeeTerritory dto)
        {
            var entity = new EmployeeTerritoryEntity();

            // Map entity properties
            entity.EmployeeId = dto.EmployeeId;
            entity.TerritoryId = dto.TerritoryId;


            // Map entity associations
            // n:1 Employee association
            if (dto.Employee != null)
            {
        entity.Employee = dto.Employee.FromDto();
            }
            // n:1 Territory association
            if (dto.Territory != null)
            {
        entity.Territory = dto.Territory.FromDto();
            }

            return entity;
        }

        public static EmployeeTerritory[] RelatedArray(this EntityCollection<EmployeeTerritoryEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new EmployeeTerritory[entities.Count];
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
                    arr[i++] = seenObjects[entity] as EmployeeTerritory;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static EmployeeTerritory RelatedObject(this EmployeeTerritoryEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as EmployeeTerritory;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
