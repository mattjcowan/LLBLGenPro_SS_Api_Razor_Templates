using System;
using System.Collections.Generic;
using System.Net;
using ServiceStack.Common.Web;
using ServiceStack.FluentValidation;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.Dtos.TypedListDtos;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceInterfaces.TypedListServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services.TypedListServices
{
    #region Service
    /// <summary>Service class for the typed list 'EmployeesByRegionAndTerritory'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                             
    public partial class EmployeesByRegionAndTerritoryTypedListService : TypedListServiceBase<EmployeesByRegionAndTerritory, IEmployeesByRegionAndTerritoryTypedListServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetEmployeesByRegionAndTerritoryMetaRequest(EmployeesByRegionAndTerritoryMetaRequest request);
        partial void OnAfterGetEmployeesByRegionAndTerritoryMetaRequest(EmployeesByRegionAndTerritoryMetaRequest request, TypedListMetaDetailsResponse response);
        partial void OnBeforePostEmployeesByRegionAndTerritoryDataTableRequest(EmployeesByRegionAndTerritoryDataTableRequest request);
        partial void OnAfterPostEmployeesByRegionAndTerritoryDataTableRequest(EmployeesByRegionAndTerritoryDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetEmployeesByRegionAndTerritoryQueryCollectionRequest(EmployeesByRegionAndTerritoryQueryCollectionRequest request);
        partial void OnAfterGetEmployeesByRegionAndTerritoryQueryCollectionRequest(EmployeesByRegionAndTerritoryQueryCollectionRequest request, EmployeesByRegionAndTerritoryCollectionResponse response);
        #endregion
    
        public EmployeesByRegionAndTerritoryTypedListService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed list 'EmployeesByRegionAndTerritory' including field metadata.</summary>
        public TypedListMetaDetailsResponse Get(EmployeesByRegionAndTerritoryMetaRequest request)
        {
            OnBeforeGetEmployeesByRegionAndTerritoryMetaRequest(request);
            var output = Repository.GetTypedListMetaDetails(this);
            OnAfterGetEmployeesByRegionAndTerritoryMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'EmployeesByRegionAndTerritory' typed list records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(EmployeesByRegionAndTerritoryDataTableRequest request)
        {
            OnBeforePostEmployeesByRegionAndTerritoryDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostEmployeesByRegionAndTerritoryDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'EmployeesByRegionAndTerritory' typed list records using sorting, filtering, paging and more.</summary>
        public EmployeesByRegionAndTerritoryCollectionResponse Get(EmployeesByRegionAndTerritoryQueryCollectionRequest request)
        {
            OnBeforeGetEmployeesByRegionAndTerritoryQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetEmployeesByRegionAndTerritoryQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedListSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/lists/employeesbyregionandterritory/meta", Verbs = "GET")]
    public partial class EmployeesByRegionAndTerritoryMetaRequest : IReturn<TypedListMetaDetailsResponse>
    {
    }

    [Route("/lists/employeesbyregionandterritory/datatable", Verbs = "POST")] // general query
    public partial class EmployeesByRegionAndTerritoryDataTableRequest : GetTypedListCollectionRequest<EmployeesByRegionAndTerritory, EmployeesByRegionAndTerritoryCollectionResponse>
    {
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sSearch { get; set; }
        public bool bEscapeRegex { get; set; }
        public int iColumns { get; set; }
        public int iSortingCols { get; set; }
        public string sEcho { get; set; }
        public string bRegex { get; set; }

        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; }
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; }
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }
        public int iSortCol_3 { get; set; }
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }
        public int iSortCol_4 { get; set; }
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }
        public int iSortCol_5 { get; set; }
        public string sSortDir_5 { get; set; }
        public string bSortable_5 { get; set; } 
        public string mDataProp_5 { get; set; } 
        public string bRegex_5 { get; set; }
        public string bSearchable_5 { get; set; }
        public int iSortCol_6 { get; set; }
        public string sSortDir_6 { get; set; }
        public string bSortable_6 { get; set; } 
        public string mDataProp_6 { get; set; } 
        public string bRegex_6 { get; set; }
        public string bSearchable_6 { get; set; }
        public int iSortCol_7 { get; set; }
        public string sSortDir_7 { get; set; }
        public string bSortable_7 { get; set; } 
        public string mDataProp_7 { get; set; } 
        public string bRegex_7 { get; set; }
        public string bSearchable_7 { get; set; }
        public int iSortCol_8 { get; set; }
        public string sSortDir_8 { get; set; }
        public string bSortable_8 { get; set; } 
        public string mDataProp_8 { get; set; } 
        public string bRegex_8 { get; set; }
        public string bSearchable_8 { get; set; }
        public int iSortCol_9 { get; set; }
        public string sSortDir_9 { get; set; }
        public string bSortable_9 { get; set; } 
        public string mDataProp_9 { get; set; } 
        public string bRegex_9 { get; set; }
        public string bSearchable_9 { get; set; }

    }

    [Route("/lists/employeesbyregionandterritory", Verbs = "GET")] // general query
    [DefaultView("EmployeesByRegionAndTerritoryTypedList")]
    public partial class EmployeesByRegionAndTerritoryQueryCollectionRequest : GetTypedListCollectionRequest<EmployeesByRegionAndTerritory, EmployeesByRegionAndTerritoryCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class EmployeesByRegionAndTerritoryCollectionResponse : GetTypedListCollectionResponse<EmployeesByRegionAndTerritory>
    {
        public EmployeesByRegionAndTerritoryCollectionResponse(): base(){}
        public EmployeesByRegionAndTerritoryCollectionResponse(IEnumerable<EmployeesByRegionAndTerritory> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedListCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                         
    }
    #endregion
}
