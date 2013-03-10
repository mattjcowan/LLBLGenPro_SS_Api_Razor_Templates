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
    public partial class EmployeeServiceRepository : EntityServiceRepositoryBase<Employee, EmployeeEntity, EmployeeEntityFactory, EmployeeFieldIndex>, IEmployeeServiceRepository
    {
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected override EntityType EntityType
        {
            get { return EntityType.EmployeeEntity; }
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(EmployeeDataTableRequest request)
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
EmployeeQueryCollectionRequest
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
            var includeReportsTo = ((request.Include ?? "").IndexOf("reportsto", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeEmployees = ((request.Include ?? "").IndexOf("employees", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeEmployeeTerritories = ((request.Include ?? "").IndexOf("employeeterritories", StringComparison.InvariantCultureIgnoreCase)) >= 0;
            var includeOrders = ((request.Include ?? "").IndexOf("orders", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/employees?filter=employeeid:eq:{2}"">{1} Reports To</a></div>",
                            includeReportsTo ? (item.ReportsTo==null?"0":"1"): "",
                            includeReportsTo ? "": "",
                            item.ReportsToId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/employees?filter=reportstoid:eq:{2}"">{1} Employees</a></div>",
                            includeEmployees ? item.Employees.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeEmployees ? "": "",
                            item.EmployeeId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/employeeterritories?filter=employeeid:eq:{2}"">{1} Employee Territories</a></div>",
                            includeEmployeeTerritories ? item.EmployeeTerritories.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeEmployeeTerritories ? "": "",
                            item.EmployeeId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/orders?filter=employeeid:eq:{2}"">{1} Orders</a></div>",
                            includeOrders ? item.Orders.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeOrders ? "": "",
                            item.EmployeeId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.EmployeeId.ToString(),
                        item.LastName,
                        item.FirstName,
                        item.Title,
                        item.TitleOfCourtesy,
                        item.BirthDate.ToString(),
                        item.HireDate.ToString(),
                        item.Address,
                        item.City,
                        item.Region,
                        item.PostalCode,
                        item.Country,
                        item.HomePhone,
                        item.Extension,
                        string.Format("<ul class=\"thumbnails\"><li class=\"span12\"><div class=\"thumbnail\">{0}</div></li></ul>", item.Photo.ToImageSrc(null, 160)),                        item.Notes,
                        item.ReportsToId.ToString(),
                        item.PhotoPath,

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

        public EmployeeCollectionResponse Fetch(EmployeeQueryCollectionRequest request)
        {
            var totalItemCount = 0;
            var entities = base.Fetch(request.Sort, request.Include, request.Filter,
                                      request.Relations, request.Select, request.PageNumber,
                                      request.PageSize, out totalItemCount);
            var response = new EmployeeCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;
        }
    

        public EmployeeResponse Fetch(EmployeePkRequest request)
        {
            var entity = new EmployeeEntity();
            entity.EmployeeId = request.EmployeeId;

            var prefetchPath = ConvertStringToPrefetchPath(EntityType, request.Include);
            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    return new EmployeeResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public EmployeeResponse Create(EmployeeAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if(adapter.SaveEntity(entity, true))
                {
                    return new EmployeeResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public EmployeeResponse Update(EmployeeUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.SaveEntity(entity, true))
                {
                    return new EmployeeResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public bool Delete(EmployeeDeleteRequest request)
        {
            var entity = new EmployeeEntity();
            entity.EmployeeId = request.EmployeeId;


            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                return adapter.DeleteEntity(entity);
            }
        }

        private const string UcMapCacheKey = "employee-uc-map";
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

    internal static class EmployeeEntityDtoMapperExtensions
    {
        public static Employee ToDto(this EmployeeEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static Employee ToDto(this EmployeeEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            var dto = new Employee();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

              // Map dto properties
                dto.EmployeeId = entity.EmployeeId;
                dto.LastName = entity.LastName;
                dto.FirstName = entity.FirstName;
                dto.Title = entity.Title;
                dto.TitleOfCourtesy = entity.TitleOfCourtesy;
                dto.BirthDate = entity.BirthDate;
                dto.HireDate = entity.HireDate;
                dto.Address = entity.Address;
                dto.City = entity.City;
                dto.Region = entity.Region;
                dto.PostalCode = entity.PostalCode;
                dto.Country = entity.Country;
                dto.HomePhone = entity.HomePhone;
                dto.Extension = entity.Extension;
                dto.Photo = entity.Photo;
                dto.Notes = entity.Notes;
                dto.ReportsToId = entity.ReportsToId;
                dto.PhotoPath = entity.PhotoPath;


              // Map dto associations
              // n:1 ReportsTo association
              if (entity.ReportsTo != null)
              {
                dto.ReportsTo = entity.ReportsTo.RelatedObject(seenObjects, parents);
              }
              // 1:n Employees association of Employee entities
              if (entity.Employees != null && entity.Employees.Any())
              {
                dto.Employees = new EmployeeCollection(entity.Employees.RelatedArray(seenObjects, parents));
              }
              // 1:n EmployeeTerritories association of EmployeeTerritory entities
              if (entity.EmployeeTerritories != null && entity.EmployeeTerritories.Any())
              {
                dto.EmployeeTerritories = new EmployeeTerritoryCollection(entity.EmployeeTerritories.RelatedArray(seenObjects, parents));
              }
              // 1:n Orders association of Order entities
              if (entity.Orders != null && entity.Orders.Any())
              {
                dto.Orders = new OrderCollection(entity.Orders.RelatedArray(seenObjects, parents));
              }

            }
            return dto;
        }

        public static EmployeeCollection ToDtoCollection(this EntityCollection<EmployeeEntity> entities)
        {
            var seenObjects = new Hashtable();
            var collection = new EmployeeCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            return collection;
        }

        public static EmployeeEntity FromDto(this Employee dto)
        {
            var entity = new EmployeeEntity();

            // Map entity properties
            entity.EmployeeId = dto.EmployeeId;
            entity.LastName = dto.LastName;
            entity.FirstName = dto.FirstName;
            entity.Title = dto.Title;
            entity.TitleOfCourtesy = dto.TitleOfCourtesy;
            entity.BirthDate = dto.BirthDate;
            entity.HireDate = dto.HireDate;
            entity.Address = dto.Address;
            entity.City = dto.City;
            entity.Region = dto.Region;
            entity.PostalCode = dto.PostalCode;
            entity.Country = dto.Country;
            entity.HomePhone = dto.HomePhone;
            entity.Extension = dto.Extension;
            if (dto.Photo != null) entity.Photo = dto.Photo;
            entity.Notes = dto.Notes;
            entity.ReportsToId = dto.ReportsToId;
            entity.PhotoPath = dto.PhotoPath;


            // Map entity associations
            // n:1 ReportsTo association
            if (dto.ReportsTo != null)
            {
        entity.ReportsTo = dto.ReportsTo.FromDto();
            }
            // 1:n Employees association
            if (dto.Employees != null && dto.Employees.Any())
            {
                foreach (var relatedDto in dto.Employees)
                    entity.Employees.Add(relatedDto.FromDto());
            }
            // 1:n EmployeeTerritories association
            if (dto.EmployeeTerritories != null && dto.EmployeeTerritories.Any())
            {
                foreach (var relatedDto in dto.EmployeeTerritories)
                    entity.EmployeeTerritories.Add(relatedDto.FromDto());
            }
            // 1:n Orders association
            if (dto.Orders != null && dto.Orders.Any())
            {
                foreach (var relatedDto in dto.Orders)
                    entity.Orders.Add(relatedDto.FromDto());
            }

            return entity;
        }

        public static Employee[] RelatedArray(this EntityCollection<EmployeeEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new Employee[entities.Count];
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
                    arr[i++] = seenObjects[entity] as Employee;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static Employee RelatedObject(this EmployeeEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as Employee;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
