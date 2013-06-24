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
    /// <summary>Service class for the typed view 'SalesTotalsByAmount'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END            
    public partial class SalesTotalsByAmountTypedViewService : TypedViewServiceBase<SalesTotalsByAmount, ISalesTotalsByAmountTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetSalesTotalsByAmountMetaRequest(SalesTotalsByAmountMetaRequest request);
        partial void OnAfterGetSalesTotalsByAmountMetaRequest(SalesTotalsByAmountMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostSalesTotalsByAmountDataTableRequest(SalesTotalsByAmountDataTableRequest request);
        partial void OnAfterPostSalesTotalsByAmountDataTableRequest(SalesTotalsByAmountDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetSalesTotalsByAmountQueryCollectionRequest(SalesTotalsByAmountQueryCollectionRequest request);
        partial void OnAfterGetSalesTotalsByAmountQueryCollectionRequest(SalesTotalsByAmountQueryCollectionRequest request, SalesTotalsByAmountCollectionResponse response);
        #endregion
    
        public SalesTotalsByAmountTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'SalesTotalsByAmount' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(SalesTotalsByAmountMetaRequest request)
        {
            OnBeforeGetSalesTotalsByAmountMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetSalesTotalsByAmountMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'SalesTotalsByAmount' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(SalesTotalsByAmountDataTableRequest request)
        {
            OnBeforePostSalesTotalsByAmountDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostSalesTotalsByAmountDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'SalesTotalsByAmount' typed view records using sorting, filtering, paging and more.</summary>
        public SalesTotalsByAmountCollectionResponse Get(SalesTotalsByAmountQueryCollectionRequest request)
        {
            OnBeforeGetSalesTotalsByAmountQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetSalesTotalsByAmountQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/salestotalsbyamount/meta", Verbs = "GET")]
    public partial class SalesTotalsByAmountMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/salestotalsbyamount/datatable", Verbs = "POST")] // general query
    public partial class SalesTotalsByAmountDataTableRequest : GetTypedViewCollectionRequest<SalesTotalsByAmount, SalesTotalsByAmountCollectionResponse>
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

    }

    [Route("/views/salestotalsbyamount", Verbs = "GET")] // general query
    [DefaultView("SalesTotalsByAmountTypedView")]
    public partial class SalesTotalsByAmountQueryCollectionRequest : GetTypedViewCollectionRequest<SalesTotalsByAmount, SalesTotalsByAmountCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class SalesTotalsByAmountCollectionResponse : GetTypedViewCollectionResponse<SalesTotalsByAmount>
    {
        public SalesTotalsByAmountCollectionResponse(): base(){}
        public SalesTotalsByAmountCollectionResponse(IEnumerable<SalesTotalsByAmount> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }
    #endregion
}
