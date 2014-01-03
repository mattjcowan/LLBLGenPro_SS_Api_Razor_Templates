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
    public partial class InvoicesTypedViewServiceRepository : TypedViewServiceRepositoryBase<Invoices>, IInvoicesTypedViewServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeFetchInvoicesQueryCollectionRequest(IDataAccessAdapter adapter, InvoicesQueryCollectionRequest request, SortExpression sortExpression, string[] includedFieldNames, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchInvoicesQueryCollectionRequest(IDataAccessAdapter adapter, InvoicesQueryCollectionRequest request, InvoicesTypedView typedView, SortExpression sortExpression, string[] includedFieldNames, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);
        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override TypedViewType TypedViewType
        {
            get { return TypedViewType.InvoicesTypedView; }
        }
    
        public InvoicesTypedViewServiceRepository()
        {
            OnCreateRepository();
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(InvoicesDataTableRequest request)
        {
            var fieldMap = FieldMap;
            var fieldCount = fieldMap.Count;
        
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
                sort = string.Format("{0}:{1}", fieldMap.Keys.ElementAt(Convert.ToInt32(request.iSortCol_0)), request.sSortDir_0);
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
                    foreach (var fm in fieldMap)
                    {
                        if (fm.Value.DataType.IsNumericType())
                        {
                            n++;
                            searchStr += string.Format("({0}:eq:{1})", fm.Key, searchStrAsInt);
                        }
                    }
                }
                // process string field searches
                foreach (var fm in fieldMap)
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

            var entities = Fetch(new InvoicesQueryCollectionRequest
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
                        item.ShipName,
                        item.ShipAddress,
                        item.ShipCity,
                        item.ShipRegion,
                        item.ShipPostalCode,
                        item.ShipCountry,
                        item.CustomerId,
                        item.CustomerName,
                        item.Address,
                        item.City,
                        item.Region,
                        item.PostalCode,
                        item.Country,
                        item.Salesperson,
                        item.OrderId.ToString(),
                        item.OrderDate.ToString(),
                        item.RequiredDate.ToString(),
                        item.ShippedDate.ToString(),
                        item.ShipperName,
                        item.ProductId.ToString(),
                        item.ProductName,
                        item.UnitPrice.ToString(),
                        item.Quantity.ToString(),
                        item.Discount.ToString(),
                        item.ExtendedPrice.ToString(),
                        item.Freight.ToString()

                });
            }

            response.sEcho = request.sEcho;
            // total records in the database before datatables search
            response.iTotalRecords = entities.Paging.TotalCount;
            // total records in the database after datatables search
            response.iTotalDisplayRecords = entities.Paging.TotalCount;
            return response;
        }
    
        public InvoicesCollectionResponse Fetch(InvoicesQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var sortExpression = RepositoryHelper.ConvertStringToSortExpression(TypedViewType, request.Sort);
            var includedFieldNames = RepositoryHelper.ConvertStringToExcludedIncludedFields(request.Select);
            var predicateBucket = RepositoryHelper.ConvertStringToRelationPredicateBucket(TypedViewType, request.Filter);

            var typedView = new InvoicesTypedView();
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchInvoicesQueryCollectionRequest(adapter, request, sortExpression, includedFieldNames, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                totalItemCount = (int)adapter.GetDbCount(typedView.GetFieldsInfo(), predicateBucket, null, false);
                adapter.FetchTypedView(typedView.GetFieldsInfo(), typedView, predicateBucket, request.Limit, sortExpression, true, null, request.PageNumber, request.PageSize);
                OnAfterFetchInvoicesQueryCollectionRequest(adapter, request, typedView, sortExpression, includedFieldNames, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }

            var dtos = new InvoicesCollection();
            var enumerator = typedView.GetEnumerator();
            while (enumerator.MoveNext())
            {
                dtos.Add(Map(enumerator.Current, includedFieldNames));
            }

            var response = new InvoicesCollectionResponse(dtos, request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;       
        }

        private Invoices Map(InvoicesRow row, string[] fieldNames)
        {
            var hasFn = fieldNames != null && fieldNames.Any();
            var item = new Invoices();
            if (!hasFn || fieldNames.Contains("ShipName", StringComparer.OrdinalIgnoreCase))
                item.ShipName = row.ShipName;
            if (!hasFn || fieldNames.Contains("ShipAddress", StringComparer.OrdinalIgnoreCase))
                item.ShipAddress = row.ShipAddress;
            if (!hasFn || fieldNames.Contains("ShipCity", StringComparer.OrdinalIgnoreCase))
                item.ShipCity = row.ShipCity;
            if (!hasFn || fieldNames.Contains("ShipRegion", StringComparer.OrdinalIgnoreCase))
                item.ShipRegion = row.ShipRegion;
            if (!hasFn || fieldNames.Contains("ShipPostalCode", StringComparer.OrdinalIgnoreCase))
                item.ShipPostalCode = row.ShipPostalCode;
            if (!hasFn || fieldNames.Contains("ShipCountry", StringComparer.OrdinalIgnoreCase))
                item.ShipCountry = row.ShipCountry;
            if (!hasFn || fieldNames.Contains("CustomerId", StringComparer.OrdinalIgnoreCase))
                item.CustomerId = row.CustomerId;
            if (!hasFn || fieldNames.Contains("CustomerName", StringComparer.OrdinalIgnoreCase))
                item.CustomerName = row.CustomerName;
            if (!hasFn || fieldNames.Contains("Address", StringComparer.OrdinalIgnoreCase))
                item.Address = row.Address;
            if (!hasFn || fieldNames.Contains("City", StringComparer.OrdinalIgnoreCase))
                item.City = row.City;
            if (!hasFn || fieldNames.Contains("Region", StringComparer.OrdinalIgnoreCase))
                item.Region = row.Region;
            if (!hasFn || fieldNames.Contains("PostalCode", StringComparer.OrdinalIgnoreCase))
                item.PostalCode = row.PostalCode;
            if (!hasFn || fieldNames.Contains("Country", StringComparer.OrdinalIgnoreCase))
                item.Country = row.Country;
            if (!hasFn || fieldNames.Contains("Salesperson", StringComparer.OrdinalIgnoreCase))
                item.Salesperson = row.Salesperson;
            if (!hasFn || fieldNames.Contains("OrderId", StringComparer.OrdinalIgnoreCase))
                item.OrderId = row.OrderId;
            if (!hasFn || fieldNames.Contains("OrderDate", StringComparer.OrdinalIgnoreCase))
                item.OrderDate = row.OrderDate;
            if (!hasFn || fieldNames.Contains("RequiredDate", StringComparer.OrdinalIgnoreCase))
                item.RequiredDate = row.RequiredDate;
            if (!hasFn || fieldNames.Contains("ShippedDate", StringComparer.OrdinalIgnoreCase))
                item.ShippedDate = row.ShippedDate;
            if (!hasFn || fieldNames.Contains("ShipperName", StringComparer.OrdinalIgnoreCase))
                item.ShipperName = row.ShipperName;
            if (!hasFn || fieldNames.Contains("ProductId", StringComparer.OrdinalIgnoreCase))
                item.ProductId = row.ProductId;
            if (!hasFn || fieldNames.Contains("ProductName", StringComparer.OrdinalIgnoreCase))
                item.ProductName = row.ProductName;
            if (!hasFn || fieldNames.Contains("UnitPrice", StringComparer.OrdinalIgnoreCase))
                item.UnitPrice = row.UnitPrice;
            if (!hasFn || fieldNames.Contains("Quantity", StringComparer.OrdinalIgnoreCase))
                item.Quantity = row.Quantity;
            if (!hasFn || fieldNames.Contains("Discount", StringComparer.OrdinalIgnoreCase))
                item.Discount = row.Discount;
            if (!hasFn || fieldNames.Contains("ExtendedPrice", StringComparer.OrdinalIgnoreCase))
                item.ExtendedPrice = row.ExtendedPrice;
            if (!hasFn || fieldNames.Contains("Freight", StringComparer.OrdinalIgnoreCase))
                item.Freight = row.Freight;


            return item;
        }
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
}
