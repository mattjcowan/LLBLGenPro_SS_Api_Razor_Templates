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
using Northwind.Data.Dtos.TypedViewDtos;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceInterfaces.TypedViewServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services.TypedViewServices
{
    #region Service
    /// <summary>Service class for the typed view 'SummaryOfSalesByQuarter'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                  
    public partial class SummaryOfSalesByQuarterTypedViewService : TypedViewServiceBase<SummaryOfSalesByQuarter, ISummaryOfSalesByQuarterTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetSummaryOfSalesByQuarterMetaRequest(SummaryOfSalesByQuarterMetaRequest request);
        partial void OnAfterGetSummaryOfSalesByQuarterMetaRequest(SummaryOfSalesByQuarterMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostSummaryOfSalesByQuarterDataTableRequest(SummaryOfSalesByQuarterDataTableRequest request);
        partial void OnAfterPostSummaryOfSalesByQuarterDataTableRequest(SummaryOfSalesByQuarterDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetSummaryOfSalesByQuarterQueryCollectionRequest(SummaryOfSalesByQuarterQueryCollectionRequest request);
        partial void OnAfterGetSummaryOfSalesByQuarterQueryCollectionRequest(SummaryOfSalesByQuarterQueryCollectionRequest request, SummaryOfSalesByQuarterCollectionResponse response);
        #endregion
    
        public SummaryOfSalesByQuarterTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'SummaryOfSalesByQuarter' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(SummaryOfSalesByQuarterMetaRequest request)
        {
            OnBeforeGetSummaryOfSalesByQuarterMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetSummaryOfSalesByQuarterMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'SummaryOfSalesByQuarter' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(SummaryOfSalesByQuarterDataTableRequest request)
        {
            OnBeforePostSummaryOfSalesByQuarterDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostSummaryOfSalesByQuarterDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'SummaryOfSalesByQuarter' typed view records using sorting, filtering, paging and more.</summary>
        public SummaryOfSalesByQuarterCollectionResponse Get(SummaryOfSalesByQuarterQueryCollectionRequest request)
        {
            OnBeforeGetSummaryOfSalesByQuarterQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetSummaryOfSalesByQuarterQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/summaryofsalesbyquarter/meta", Verbs = "GET")]
    public partial class SummaryOfSalesByQuarterMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/summaryofsalesbyquarter/datatable", Verbs = "POST")] // general query
    public partial class SummaryOfSalesByQuarterDataTableRequest : GetTypedViewCollectionRequest<SummaryOfSalesByQuarter, SummaryOfSalesByQuarterCollectionResponse>
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

    }

    [Route("/views/summaryofsalesbyquarter", Verbs = "GET")] // general query
    [DefaultView("SummaryOfSalesByQuarterTypedView")]
    public partial class SummaryOfSalesByQuarterQueryCollectionRequest : GetTypedViewCollectionRequest<SummaryOfSalesByQuarter, SummaryOfSalesByQuarterCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class SummaryOfSalesByQuarterCollectionResponse : GetTypedViewCollectionResponse<SummaryOfSalesByQuarter>
    {
        public SummaryOfSalesByQuarterCollectionResponse(): base(){}
        public SummaryOfSalesByQuarterCollectionResponse(IEnumerable<SummaryOfSalesByQuarter> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                   
    }
    #endregion
}
