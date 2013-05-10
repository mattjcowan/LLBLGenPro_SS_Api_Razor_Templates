using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using ServiceStack.Text;
using Northwind.Data;
using Northwind.Data.Dtos;
using Northwind.Data.Dtos.TypedViewDtos;
using Northwind.Data.EntityClasses;
using Northwind.Data.FactoryClasses;
using Northwind.Data.Helpers;
using Northwind.Data.HelperClasses;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceInterfaces.TypedViewServiceInterfaces;
using Northwind.Data.Services;
using Northwind.Data.Services.TypedViewServices;
using Northwind.Data.TypedViewClasses;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceRepositories.TypedViewServiceRepositories
{ 
    public partial class OrdersQryTypedViewServiceRepository : TypedViewServiceRepositoryBase<OrdersQry>, IOrdersQryTypedViewServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeFetchOrdersQryQueryCollectionRequest(IDataAccessAdapter adapter, OrdersQryQueryCollectionRequest request, SortExpression sortExpression, string[] includedFieldNames, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchOrdersQryQueryCollectionRequest(IDataAccessAdapter adapter, OrdersQryQueryCollectionRequest request, OrdersQryTypedView typedView, SortExpression sortExpression, string[] includedFieldNames, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);
        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override TypedViewType TypedViewType
        {
            get { return TypedViewType.OrdersQryTypedView; }
        }
    
        public OrdersQryTypedViewServiceRepository()
        {
            OnCreateRepository();
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(OrdersQryDataTableRequest request)
        {
            //UrlDecode Request Properties
            request.sSearch = System.Web.HttpUtility.UrlDecode(request.sSearch);
            request.Sort = System.Web.HttpUtility.UrlDecode(request.Sort);
            request.Filter = System.Web.HttpUtility.UrlDecode(request.Filter);
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
OrdersQryQueryCollectionRequest
                {
                    Filter = filter, 
                    PageNumber = Convert.ToInt32(pageNumber),
                    PageSize = pageSize,
                    Sort = sort,
                    Select = request.Select,
                });
            var response = new DataTableResponse();
            foreach (var item in entities.Result)
            {
                response.aaData.Add(new string[]
                    {
                        item.Address,
                        item.City,
                        item.CompanyName,
                        item.Country,
                        item.CustomerId,
                        item.EmployeeId.ToString(),
                        item.Freight.ToString(),
                        item.OrderDate.ToString(),
                        item.OrderId.ToString(),
                        item.PostalCode,
                        item.Region,
                        item.RequiredDate.ToString(),
                        item.ShipAddress,
                        item.ShipCity,
                        item.ShipCountry,
                        item.ShipName,
                        item.ShippedDate.ToString(),
                        item.ShipPostalCode,
                        item.ShipRegion,
                        item.ShipVia.ToString()

                    });
            }
            response.sEcho = request.sEcho;
            // total records in the database before datatables search
            response.iTotalRecords = entities.Paging.TotalCount;
            // total records in the database after datatables search
            response.iTotalDisplayRecords = entities.Paging.TotalCount;
            return response;
        }
    
        public OrdersQryCollectionResponse Fetch(OrdersQryQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var sortExpression = RepositoryHelper.ConvertStringToSortExpression(TypedViewType, request.Sort);
            var includedFieldNames = RepositoryHelper.ConvertStringToExcludedIncludedFields(request.Select);
            var predicateBucket = RepositoryHelper.ConvertStringToRelationPredicateBucket(TypedViewType, request.Filter);

            var typedView = new OrdersQryTypedView();
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchOrdersQryQueryCollectionRequest(adapter, request, sortExpression, includedFieldNames, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                totalItemCount = (int)adapter.GetDbCount(typedView.GetFieldsInfo(), predicateBucket, null, false);
                adapter.FetchTypedView(typedView.GetFieldsInfo(), typedView, predicateBucket, request.Limit, sortExpression, true, null, request.PageNumber, request.PageSize);
                OnAfterFetchOrdersQryQueryCollectionRequest(adapter, request, typedView, sortExpression, includedFieldNames, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }

            var dtos = new OrdersQryCollection();
            var enumerator = typedView.GetEnumerator();
            while (enumerator.MoveNext())
            {
                dtos.Add(Map(enumerator.Current, includedFieldNames));
            }

            var response = new OrdersQryCollectionResponse(dtos, request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;       
        }

        private OrdersQry Map(OrdersQryRow row, string[] fieldNames)
        {
            var hasFn = fieldNames != null && fieldNames.Any();
            var item = new OrdersQry();
            if (!hasFn || fieldNames.Contains("Address", StringComparer.OrdinalIgnoreCase))
            	item.Address = row.Address;
            if (!hasFn || fieldNames.Contains("City", StringComparer.OrdinalIgnoreCase))
            	item.City = row.City;
            if (!hasFn || fieldNames.Contains("CompanyName", StringComparer.OrdinalIgnoreCase))
            	item.CompanyName = row.CompanyName;
            if (!hasFn || fieldNames.Contains("Country", StringComparer.OrdinalIgnoreCase))
            	item.Country = row.Country;
            if (!hasFn || fieldNames.Contains("CustomerId", StringComparer.OrdinalIgnoreCase))
            	item.CustomerId = row.CustomerId;
            if (!hasFn || fieldNames.Contains("EmployeeId", StringComparer.OrdinalIgnoreCase))
            	item.EmployeeId = row.EmployeeId;
            if (!hasFn || fieldNames.Contains("Freight", StringComparer.OrdinalIgnoreCase))
            	item.Freight = row.Freight;
            if (!hasFn || fieldNames.Contains("OrderDate", StringComparer.OrdinalIgnoreCase))
            	item.OrderDate = row.OrderDate;
            if (!hasFn || fieldNames.Contains("OrderId", StringComparer.OrdinalIgnoreCase))
            	item.OrderId = row.OrderId;
            if (!hasFn || fieldNames.Contains("PostalCode", StringComparer.OrdinalIgnoreCase))
            	item.PostalCode = row.PostalCode;
            if (!hasFn || fieldNames.Contains("Region", StringComparer.OrdinalIgnoreCase))
            	item.Region = row.Region;
            if (!hasFn || fieldNames.Contains("RequiredDate", StringComparer.OrdinalIgnoreCase))
            	item.RequiredDate = row.RequiredDate;
            if (!hasFn || fieldNames.Contains("ShipAddress", StringComparer.OrdinalIgnoreCase))
            	item.ShipAddress = row.ShipAddress;
            if (!hasFn || fieldNames.Contains("ShipCity", StringComparer.OrdinalIgnoreCase))
            	item.ShipCity = row.ShipCity;
            if (!hasFn || fieldNames.Contains("ShipCountry", StringComparer.OrdinalIgnoreCase))
            	item.ShipCountry = row.ShipCountry;
            if (!hasFn || fieldNames.Contains("ShipName", StringComparer.OrdinalIgnoreCase))
            	item.ShipName = row.ShipName;
            if (!hasFn || fieldNames.Contains("ShippedDate", StringComparer.OrdinalIgnoreCase))
            	item.ShippedDate = row.ShippedDate;
            if (!hasFn || fieldNames.Contains("ShipPostalCode", StringComparer.OrdinalIgnoreCase))
            	item.ShipPostalCode = row.ShipPostalCode;
            if (!hasFn || fieldNames.Contains("ShipRegion", StringComparer.OrdinalIgnoreCase))
            	item.ShipRegion = row.ShipRegion;
            if (!hasFn || fieldNames.Contains("ShipVia", StringComparer.OrdinalIgnoreCase))
            	item.ShipVia = row.ShipVia;


            return item;
        }
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
}
