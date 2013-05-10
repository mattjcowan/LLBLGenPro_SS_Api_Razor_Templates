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
    /// <summary>Service class for the typed view 'SummaryOfSalesByYear'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                 
    public partial class SummaryOfSalesByYearTypedViewService : TypedViewServiceBase<SummaryOfSalesByYear, ISummaryOfSalesByYearTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetSummaryOfSalesByYearMetaRequest(SummaryOfSalesByYearMetaRequest request);
        partial void OnAfterGetSummaryOfSalesByYearMetaRequest(SummaryOfSalesByYearMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostSummaryOfSalesByYearDataTableRequest(SummaryOfSalesByYearDataTableRequest request);
        partial void OnAfterPostSummaryOfSalesByYearDataTableRequest(SummaryOfSalesByYearDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetSummaryOfSalesByYearQueryCollectionRequest(SummaryOfSalesByYearQueryCollectionRequest request);
        partial void OnAfterGetSummaryOfSalesByYearQueryCollectionRequest(SummaryOfSalesByYearQueryCollectionRequest request, SummaryOfSalesByYearCollectionResponse response);
        #endregion
    
        public SummaryOfSalesByYearTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'SummaryOfSalesByYear' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(SummaryOfSalesByYearMetaRequest request)
        {
            OnBeforeGetSummaryOfSalesByYearMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetSummaryOfSalesByYearMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'SummaryOfSalesByYear' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(SummaryOfSalesByYearDataTableRequest request)
        {
            OnBeforePostSummaryOfSalesByYearDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostSummaryOfSalesByYearDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'SummaryOfSalesByYear' typed view records using sorting, filtering, paging and more.</summary>
        public SummaryOfSalesByYearCollectionResponse Get(SummaryOfSalesByYearQueryCollectionRequest request)
        {
            OnBeforeGetSummaryOfSalesByYearQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetSummaryOfSalesByYearQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/summaryofsalesbyyear/meta", Verbs = "GET")]
    public partial class SummaryOfSalesByYearMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/summaryofsalesbyyear/datatable", Verbs = "POST")] // general query
    public partial class SummaryOfSalesByYearDataTableRequest : GetTypedViewCollectionRequest<SummaryOfSalesByYear, SummaryOfSalesByYearCollectionResponse>
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

    [Route("/views/summaryofsalesbyyear", Verbs = "GET")] // general query
    [DefaultView("SummaryOfSalesByYearTypedView")]
    public partial class SummaryOfSalesByYearQueryCollectionRequest : GetTypedViewCollectionRequest<SummaryOfSalesByYear, SummaryOfSalesByYearCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class SummaryOfSalesByYearCollectionResponse : GetTypedViewCollectionResponse<SummaryOfSalesByYear>
    {
        public SummaryOfSalesByYearCollectionResponse(): base(){}
        public SummaryOfSalesByYearCollectionResponse(IEnumerable<SummaryOfSalesByYear> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                 
    }
    #endregion
}
