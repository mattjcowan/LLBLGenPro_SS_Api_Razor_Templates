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
    /// <summary>Service class for the typed view 'QuarterlyOrder'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                   
    public partial class QuarterlyOrderTypedViewService : TypedViewServiceBase<QuarterlyOrder, IQuarterlyOrderTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetQuarterlyOrderMetaRequest(QuarterlyOrderMetaRequest request);
        partial void OnAfterGetQuarterlyOrderMetaRequest(QuarterlyOrderMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostQuarterlyOrderDataTableRequest(QuarterlyOrderDataTableRequest request);
        partial void OnAfterPostQuarterlyOrderDataTableRequest(QuarterlyOrderDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetQuarterlyOrderQueryCollectionRequest(QuarterlyOrderQueryCollectionRequest request);
        partial void OnAfterGetQuarterlyOrderQueryCollectionRequest(QuarterlyOrderQueryCollectionRequest request, QuarterlyOrderCollectionResponse response);
        #endregion
    
        public QuarterlyOrderTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'QuarterlyOrder' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(QuarterlyOrderMetaRequest request)
        {
            OnBeforeGetQuarterlyOrderMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetQuarterlyOrderMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'QuarterlyOrder' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(QuarterlyOrderDataTableRequest request)
        {
            OnBeforePostQuarterlyOrderDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostQuarterlyOrderDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'QuarterlyOrder' typed view records using sorting, filtering, paging and more.</summary>
        public QuarterlyOrderCollectionResponse Get(QuarterlyOrderQueryCollectionRequest request)
        {
            OnBeforeGetQuarterlyOrderQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetQuarterlyOrderQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/quarterlyorder/meta", Verbs = "GET")]
    public partial class QuarterlyOrderMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/quarterlyorder/datatable", Verbs = "POST")] // general query
    public partial class QuarterlyOrderDataTableRequest : GetTypedViewCollectionRequest<QuarterlyOrder, QuarterlyOrderCollectionResponse>
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

    [Route("/views/quarterlyorder", Verbs = "GET")] // general query
    [DefaultView("QuarterlyOrderTypedView")]
    public partial class QuarterlyOrderQueryCollectionRequest : GetTypedViewCollectionRequest<QuarterlyOrder, QuarterlyOrderCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class QuarterlyOrderCollectionResponse : GetTypedViewCollectionResponse<QuarterlyOrder>
    {
        public QuarterlyOrderCollectionResponse(): base(){}
        public QuarterlyOrderCollectionResponse(IEnumerable<QuarterlyOrder> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                     
    }
    #endregion
}
