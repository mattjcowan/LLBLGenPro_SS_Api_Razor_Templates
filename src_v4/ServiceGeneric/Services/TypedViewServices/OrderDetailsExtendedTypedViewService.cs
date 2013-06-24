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
    /// <summary>Service class for the typed view 'OrderDetailsExtended'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END             
    public partial class OrderDetailsExtendedTypedViewService : TypedViewServiceBase<OrderDetailsExtended, IOrderDetailsExtendedTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetOrderDetailsExtendedMetaRequest(OrderDetailsExtendedMetaRequest request);
        partial void OnAfterGetOrderDetailsExtendedMetaRequest(OrderDetailsExtendedMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostOrderDetailsExtendedDataTableRequest(OrderDetailsExtendedDataTableRequest request);
        partial void OnAfterPostOrderDetailsExtendedDataTableRequest(OrderDetailsExtendedDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetOrderDetailsExtendedQueryCollectionRequest(OrderDetailsExtendedQueryCollectionRequest request);
        partial void OnAfterGetOrderDetailsExtendedQueryCollectionRequest(OrderDetailsExtendedQueryCollectionRequest request, OrderDetailsExtendedCollectionResponse response);
        #endregion
    
        public OrderDetailsExtendedTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'OrderDetailsExtended' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(OrderDetailsExtendedMetaRequest request)
        {
            OnBeforeGetOrderDetailsExtendedMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetOrderDetailsExtendedMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'OrderDetailsExtended' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(OrderDetailsExtendedDataTableRequest request)
        {
            OnBeforePostOrderDetailsExtendedDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostOrderDetailsExtendedDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'OrderDetailsExtended' typed view records using sorting, filtering, paging and more.</summary>
        public OrderDetailsExtendedCollectionResponse Get(OrderDetailsExtendedQueryCollectionRequest request)
        {
            OnBeforeGetOrderDetailsExtendedQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetOrderDetailsExtendedQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/orderdetailsextended/meta", Verbs = "GET")]
    public partial class OrderDetailsExtendedMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/orderdetailsextended/datatable", Verbs = "POST")] // general query
    public partial class OrderDetailsExtendedDataTableRequest : GetTypedViewCollectionRequest<OrderDetailsExtended, OrderDetailsExtendedCollectionResponse>
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

    }

    [Route("/views/orderdetailsextended", Verbs = "GET")] // general query
    [DefaultView("OrderDetailsExtendedTypedView")]
    public partial class OrderDetailsExtendedQueryCollectionRequest : GetTypedViewCollectionRequest<OrderDetailsExtended, OrderDetailsExtendedCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class OrderDetailsExtendedCollectionResponse : GetTypedViewCollectionResponse<OrderDetailsExtended>
    {
        public OrderDetailsExtendedCollectionResponse(): base(){}
        public OrderDetailsExtendedCollectionResponse(IEnumerable<OrderDetailsExtended> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                         
    }
    #endregion
}
