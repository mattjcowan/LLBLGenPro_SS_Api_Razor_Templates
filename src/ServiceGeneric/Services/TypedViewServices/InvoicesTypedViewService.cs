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
    /// <summary>Service class for the typed view 'Invoices'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                   
    public partial class InvoicesTypedViewService : TypedViewServiceBase<Invoices, IInvoicesTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetInvoicesMetaRequest(InvoicesMetaRequest request);
        partial void OnAfterGetInvoicesMetaRequest(InvoicesMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostInvoicesDataTableRequest(InvoicesDataTableRequest request);
        partial void OnAfterPostInvoicesDataTableRequest(InvoicesDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetInvoicesQueryCollectionRequest(InvoicesQueryCollectionRequest request);
        partial void OnAfterGetInvoicesQueryCollectionRequest(InvoicesQueryCollectionRequest request, InvoicesCollectionResponse response);
        #endregion
    
        public InvoicesTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'Invoices' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(InvoicesMetaRequest request)
        {
            OnBeforeGetInvoicesMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetInvoicesMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Invoices' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(InvoicesDataTableRequest request)
        {
            OnBeforePostInvoicesDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostInvoicesDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Invoices' typed view records using sorting, filtering, paging and more.</summary>
        public InvoicesCollectionResponse Get(InvoicesQueryCollectionRequest request)
        {
            OnBeforeGetInvoicesQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetInvoicesQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/invoices/meta", Verbs = "GET")]
    public partial class InvoicesMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/invoices/datatable", Verbs = "POST")] // general query
    public partial class InvoicesDataTableRequest : GetTypedViewCollectionRequest<Invoices, InvoicesCollectionResponse>
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
        public int iSortCol_10 { get; set; }
        public string sSortDir_10 { get; set; }
        public string bSortable_10 { get; set; } 
        public string mDataProp_10 { get; set; } 
        public string bRegex_10 { get; set; }
        public string bSearchable_10 { get; set; }
        public int iSortCol_11 { get; set; }
        public string sSortDir_11 { get; set; }
        public string bSortable_11 { get; set; } 
        public string mDataProp_11 { get; set; } 
        public string bRegex_11 { get; set; }
        public string bSearchable_11 { get; set; }
        public int iSortCol_12 { get; set; }
        public string sSortDir_12 { get; set; }
        public string bSortable_12 { get; set; } 
        public string mDataProp_12 { get; set; } 
        public string bRegex_12 { get; set; }
        public string bSearchable_12 { get; set; }
        public int iSortCol_13 { get; set; }
        public string sSortDir_13 { get; set; }
        public string bSortable_13 { get; set; } 
        public string mDataProp_13 { get; set; } 
        public string bRegex_13 { get; set; }
        public string bSearchable_13 { get; set; }
        public int iSortCol_14 { get; set; }
        public string sSortDir_14 { get; set; }
        public string bSortable_14 { get; set; } 
        public string mDataProp_14 { get; set; } 
        public string bRegex_14 { get; set; }
        public string bSearchable_14 { get; set; }
        public int iSortCol_15 { get; set; }
        public string sSortDir_15 { get; set; }
        public string bSortable_15 { get; set; } 
        public string mDataProp_15 { get; set; } 
        public string bRegex_15 { get; set; }
        public string bSearchable_15 { get; set; }
        public int iSortCol_16 { get; set; }
        public string sSortDir_16 { get; set; }
        public string bSortable_16 { get; set; } 
        public string mDataProp_16 { get; set; } 
        public string bRegex_16 { get; set; }
        public string bSearchable_16 { get; set; }
        public int iSortCol_17 { get; set; }
        public string sSortDir_17 { get; set; }
        public string bSortable_17 { get; set; } 
        public string mDataProp_17 { get; set; } 
        public string bRegex_17 { get; set; }
        public string bSearchable_17 { get; set; }
        public int iSortCol_18 { get; set; }
        public string sSortDir_18 { get; set; }
        public string bSortable_18 { get; set; } 
        public string mDataProp_18 { get; set; } 
        public string bRegex_18 { get; set; }
        public string bSearchable_18 { get; set; }
        public int iSortCol_19 { get; set; }
        public string sSortDir_19 { get; set; }
        public string bSortable_19 { get; set; } 
        public string mDataProp_19 { get; set; } 
        public string bRegex_19 { get; set; }
        public string bSearchable_19 { get; set; }
        public int iSortCol_20 { get; set; }
        public string sSortDir_20 { get; set; }
        public string bSortable_20 { get; set; } 
        public string mDataProp_20 { get; set; } 
        public string bRegex_20 { get; set; }
        public string bSearchable_20 { get; set; }
        public int iSortCol_21 { get; set; }
        public string sSortDir_21 { get; set; }
        public string bSortable_21 { get; set; } 
        public string mDataProp_21 { get; set; } 
        public string bRegex_21 { get; set; }
        public string bSearchable_21 { get; set; }
        public int iSortCol_22 { get; set; }
        public string sSortDir_22 { get; set; }
        public string bSortable_22 { get; set; } 
        public string mDataProp_22 { get; set; } 
        public string bRegex_22 { get; set; }
        public string bSearchable_22 { get; set; }
        public int iSortCol_23 { get; set; }
        public string sSortDir_23 { get; set; }
        public string bSortable_23 { get; set; } 
        public string mDataProp_23 { get; set; } 
        public string bRegex_23 { get; set; }
        public string bSearchable_23 { get; set; }
        public int iSortCol_24 { get; set; }
        public string sSortDir_24 { get; set; }
        public string bSortable_24 { get; set; } 
        public string mDataProp_24 { get; set; } 
        public string bRegex_24 { get; set; }
        public string bSearchable_24 { get; set; }
        public int iSortCol_25 { get; set; }
        public string sSortDir_25 { get; set; }
        public string bSortable_25 { get; set; } 
        public string mDataProp_25 { get; set; } 
        public string bRegex_25 { get; set; }
        public string bSearchable_25 { get; set; }

    }

    [Route("/views/invoices", Verbs = "GET")] // general query
    [DefaultView("InvoicesTypedView")]
    public partial class InvoicesQueryCollectionRequest : GetTypedViewCollectionRequest<Invoices, InvoicesCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class InvoicesCollectionResponse : GetTypedViewCollectionResponse<Invoices>
    {
        public InvoicesCollectionResponse(): base(){}
        public InvoicesCollectionResponse(IEnumerable<Invoices> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                     
    }
    #endregion
}
