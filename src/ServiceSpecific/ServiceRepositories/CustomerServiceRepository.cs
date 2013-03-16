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
    public partial class CustomerServiceRepository : EntityServiceRepositoryBase<Customer, CustomerEntity, CustomerEntityFactory, CustomerFieldIndex>, ICustomerServiceRepository
    {
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected override EntityType EntityType
        {
            get { return EntityType.CustomerEntity; }
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(CustomerDataTableRequest request)
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
CustomerQueryCollectionRequest
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
            var includeOrders = ((request.Include ?? "").IndexOf("orders", StringComparison.InvariantCultureIgnoreCase)) >= 0;

            foreach (var item in entities.Result)
            {
                var relatedDivs = new List<string>();
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/customercustomerdemos?filter=customerid:eq:{2}"">{1} Customer Customer Demos</a></div>",
                            includeCustomerCustomerDemos ? item.CustomerCustomerDemos.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeCustomerCustomerDemos ? "": "",
                            item.CustomerId
                        ));
                relatedDivs.Add(string.Format(@"<div style=""display:block;""><span class=""badge badge-info"">{0}</span><a href=""/orders?filter=customerid:eq:{2}"">{1} Orders</a></div>",
                            includeOrders ? item.Orders.Count.ToString(CultureInfo.InvariantCulture): "",
                            includeOrders ? "": "",
                            item.CustomerId
                        ));

                response.aaData.Add(new string[]
                    {
                        item.CustomerId,
                        item.CompanyName,
                        item.ContactName,
                        item.ContactTitle,
                        item.Address,
                        item.City,
                        item.Region,
                        item.PostalCode,
                        item.Country,
                        item.Phone,
                        item.Fax,

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

        public CustomerCollectionResponse Fetch(CustomerQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var entities = base.Fetch(request.Sort, request.Include, request.Filter,
                                      request.Relations, request.Select, request.PageNumber,
                                      request.PageSize, request.Limit, out totalItemCount);
            var response = new CustomerCollectionResponse(entities.ToDtoCollection(), request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;
        }
    
        public CustomerResponse Fetch(CustomerUcCompanyNameRequest request)
        {
            var entity = new CustomerEntity();
            entity.CompanyName = request.CompanyName;

            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntityUsingUniqueConstraint(entity, entity.ConstructFilterForUCCompanyName(), prefetchPath, null, excludedIncludedFields))
                {
                    return new CustomerResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public CustomerResponse Fetch(CustomerPkRequest request)
        {
            var entity = new CustomerEntity();
            entity.CustomerId = request.CustomerId;

            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(request.Select);
            var prefetchPath = ConvertStringToPrefetchPath(request.Include, request.Select);

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.FetchEntity(entity, prefetchPath, null, excludedIncludedFields))
                {
                    return new CustomerResponse(entity.ToDto());
                }
            }

            throw new NullReferenceException();
        }

        public CustomerResponse Create(CustomerAddRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if(adapter.SaveEntity(entity, true))
                {
                    return new CustomerResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public CustomerResponse Update(CustomerUpdateRequest request)
        {
            var entity = request.FromDto();
            entity.IsNew = false;
            entity.IsDirty = true;

            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                if (adapter.SaveEntity(entity, true))
                {
                    return new CustomerResponse(entity.ToDto());
                }
            }

            throw new InvalidOperationException();
        }

        public bool Delete(CustomerDeleteRequest request)
        {
            var entity = new CustomerEntity();
            entity.CustomerId = request.CustomerId;


            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                return adapter.DeleteEntity(entity);
            }
        }

        private const string UcMapCacheKey = "customer-uc-map";
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
                            CustomerFields.CompanyName,                         
                        });
                    CacheClient.Set(UcMapCacheKey, map);
                }
                return map;
            }
            set { }
        }
    }

    internal static class CustomerEntityDtoMapperExtensions
    {
        public static Customer ToDto(this CustomerEntity entity)
        {
            return entity.ToDto(new Hashtable(), new Hashtable());
        }

        public static Customer ToDto(this CustomerEntity entity, Hashtable seenObjects, Hashtable parents)
        {
            var dto = new Customer();
            if (entity != null)
            {
                if (seenObjects == null)
                    seenObjects = new Hashtable();
                seenObjects[entity] = dto;

                parents = new Hashtable(parents) { { entity, null } };

                // Map dto properties
                dto.CustomerId = entity.CustomerId;
                dto.CompanyName = entity.CompanyName;
                dto.ContactName = entity.ContactName;
                dto.ContactTitle = entity.ContactTitle;
                dto.Address = entity.Address;
                dto.City = entity.City;
                dto.Region = entity.Region;
                dto.PostalCode = entity.PostalCode;
                dto.Country = entity.Country;
                dto.Phone = entity.Phone;
                dto.Fax = entity.Fax;


                // Map dto associations
                // 1:n CustomerCustomerDemos association of CustomerCustomerDemo entities
                if (entity.CustomerCustomerDemos != null && entity.CustomerCustomerDemos.Any())
                {
                  dto.CustomerCustomerDemos = new CustomerCustomerDemoCollection(entity.CustomerCustomerDemos.RelatedArray(seenObjects, parents));
                }
                // 1:n Orders association of Order entities
                if (entity.Orders != null && entity.Orders.Any())
                {
                  dto.Orders = new OrderCollection(entity.Orders.RelatedArray(seenObjects, parents));
                }

            }
            return dto;
        }

        public static CustomerCollection ToDtoCollection(this EntityCollection<CustomerEntity> entities)
        {
            var seenObjects = new Hashtable();
            var collection = new CustomerCollection();
            foreach (var entity in entities)
            {
                collection.Add(entity.ToDto(seenObjects, new Hashtable()));
            }
            return collection;
        }

        public static CustomerEntity FromDto(this Customer dto)
        {
            var entity = new CustomerEntity();

            // Map entity properties
            entity.CustomerId = dto.CustomerId;
            entity.CompanyName = dto.CompanyName;
            entity.ContactName = dto.ContactName;
            entity.ContactTitle = dto.ContactTitle;
            entity.Address = dto.Address;
            entity.City = dto.City;
            entity.Region = dto.Region;
            entity.PostalCode = dto.PostalCode;
            entity.Country = dto.Country;
            entity.Phone = dto.Phone;
            entity.Fax = dto.Fax;


            // Map entity associations
            // 1:n CustomerCustomerDemos association
            if (dto.CustomerCustomerDemos != null && dto.CustomerCustomerDemos.Any())
            {
                foreach (var relatedDto in dto.CustomerCustomerDemos)
                    entity.CustomerCustomerDemos.Add(relatedDto.FromDto());
            }
            // 1:n Orders association
            if (dto.Orders != null && dto.Orders.Any())
            {
                foreach (var relatedDto in dto.Orders)
                    entity.Orders.Add(relatedDto.FromDto());
            }

            return entity;
        }

        public static Customer[] RelatedArray(this EntityCollection<CustomerEntity> entities, Hashtable seenObjects, Hashtable parents)
        {
            if (null == entities)
            {
                return null;
            }

            var arr = new Customer[entities.Count];
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
                    arr[i++] = seenObjects[entity] as Customer;
                }
                else
                {
                    arr[i++] = entity.ToDto(seenObjects, parents);
                }
            }
            return arr;
        }

        public static Customer RelatedObject(this CustomerEntity entity, Hashtable seenObjects, Hashtable parents)
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
                    return seenObjects[entity] as Customer;
                }
            }

            return entity.ToDto(seenObjects, parents);
        }
    }
}
