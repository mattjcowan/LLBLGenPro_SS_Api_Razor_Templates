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
    public partial class ProductsByCategoryTypedViewServiceRepository : TypedViewServiceRepositoryBase<ProductsByCategory>, IProductsByCategoryTypedViewServiceRepository
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateRepository();
        partial void OnBeforeFetchProductsByCategoryQueryCollectionRequest(IDataAccessAdapter adapter, ProductsByCategoryQueryCollectionRequest request, SortExpression sortExpression, string[] includedFieldNames, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit);
        partial void OnAfterFetchProductsByCategoryQueryCollectionRequest(IDataAccessAdapter adapter, ProductsByCategoryQueryCollectionRequest request, ProductsByCategoryTypedView typedView, SortExpression sortExpression, string[] includedFieldNames, IRelationPredicateBucket predicateBucket, int pageNumber, int pageSize, int limit, int totalItemCount);
        #endregion
        
        public override IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        
        protected override TypedViewType TypedViewType
        {
            get { return TypedViewType.ProductsByCategoryTypedView; }
        }
    
        public ProductsByCategoryTypedViewServiceRepository()
        {
            OnCreateRepository();
        }

        // Description for parameters: http://datatables.net/usage/server-side
        public DataTableResponse GetDataTableResponse(ProductsByCategoryDataTableRequest request)
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

            var entities = Fetch(new 
ProductsByCategoryQueryCollectionRequest
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
                        item.CategoryName,
                        item.ProductName,
                        item.QuantityPerUnit,
                        item.UnitsInStock.ToString(),
                        item.Discontinued.ToString()

                });
            }

            response.sEcho = request.sEcho;
            // total records in the database before datatables search
            response.iTotalRecords = entities.Paging.TotalCount;
            // total records in the database after datatables search
            response.iTotalDisplayRecords = entities.Paging.TotalCount;
            return response;
        }
    
        public ProductsByCategoryCollectionResponse Fetch(ProductsByCategoryQueryCollectionRequest request)
        {
            base.FixupLimitAndPagingOnRequest(request);

            var totalItemCount = 0;
            var sortExpression = RepositoryHelper.ConvertStringToSortExpression(TypedViewType, request.Sort);
            var includedFieldNames = RepositoryHelper.ConvertStringToExcludedIncludedFields(request.Select);
            var predicateBucket = RepositoryHelper.ConvertStringToRelationPredicateBucket(TypedViewType, request.Filter);

            var typedView = new ProductsByCategoryTypedView();
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                OnBeforeFetchProductsByCategoryQueryCollectionRequest(adapter, request, sortExpression, includedFieldNames, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit);
                totalItemCount = (int)adapter.GetDbCount(typedView.GetFieldsInfo(), predicateBucket, null, false);
                adapter.FetchTypedView(typedView.GetFieldsInfo(), typedView, predicateBucket, request.Limit, sortExpression, true, null, request.PageNumber, request.PageSize);
                OnAfterFetchProductsByCategoryQueryCollectionRequest(adapter, request, typedView, sortExpression, includedFieldNames, predicateBucket,
                    request.PageNumber, request.PageSize, request.Limit, totalItemCount);
            }

            var dtos = new ProductsByCategoryCollection();
            var enumerator = typedView.GetEnumerator();
            while (enumerator.MoveNext())
            {
                dtos.Add(Map(enumerator.Current, includedFieldNames));
            }

            var response = new ProductsByCategoryCollectionResponse(dtos, request.PageNumber,
                                                          request.PageSize, totalItemCount);
            return response;       
        }

        private ProductsByCategory Map(ProductsByCategoryRow row, string[] fieldNames)
        {
            var hasFn = fieldNames != null && fieldNames.Any();
            var item = new ProductsByCategory();
            if (!hasFn || fieldNames.Contains("CategoryName", StringComparer.OrdinalIgnoreCase))
                item.CategoryName = row.CategoryName;
            if (!hasFn || fieldNames.Contains("ProductName", StringComparer.OrdinalIgnoreCase))
                item.ProductName = row.ProductName;
            if (!hasFn || fieldNames.Contains("QuantityPerUnit", StringComparer.OrdinalIgnoreCase))
                item.QuantityPerUnit = row.QuantityPerUnit;
            if (!hasFn || fieldNames.Contains("UnitsInStock", StringComparer.OrdinalIgnoreCase))
                item.UnitsInStock = row.UnitsInStock;
            if (!hasFn || fieldNames.Contains("Discontinued", StringComparer.OrdinalIgnoreCase))
                item.Discontinued = row.Discontinued;


            return item;
        }
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
}
