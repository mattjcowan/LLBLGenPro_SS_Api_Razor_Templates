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
    /// <summary>Service class for the typed view 'OrderSubtotal'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END             
    public partial class OrderSubtotalTypedViewService : TypedViewServiceBase<OrderSubtotal, IOrderSubtotalTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetOrderSubtotalMetaRequest(OrderSubtotalMetaRequest request);
        partial void OnAfterGetOrderSubtotalMetaRequest(OrderSubtotalMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostOrderSubtotalDataTableRequest(OrderSubtotalDataTableRequest request);
        partial void OnAfterPostOrderSubtotalDataTableRequest(OrderSubtotalDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetOrderSubtotalQueryCollectionRequest(OrderSubtotalQueryCollectionRequest request);
        partial void OnAfterGetOrderSubtotalQueryCollectionRequest(OrderSubtotalQueryCollectionRequest request, OrderSubtotalCollectionResponse response);
        #endregion
    
        public OrderSubtotalTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'OrderSubtotal' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(OrderSubtotalMetaRequest request)
        {
            OnBeforeGetOrderSubtotalMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetOrderSubtotalMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'OrderSubtotal' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(OrderSubtotalDataTableRequest request)
        {
            OnBeforePostOrderSubtotalDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostOrderSubtotalDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'OrderSubtotal' typed view records using sorting, filtering, paging and more.</summary>
        public OrderSubtotalCollectionResponse Get(OrderSubtotalQueryCollectionRequest request)
        {
            OnBeforeGetOrderSubtotalQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetOrderSubtotalQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/ordersubtotal/meta", Verbs = "GET")]
    public partial class OrderSubtotalMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/ordersubtotal/datatable", Verbs = "POST")] // general query
    public partial class OrderSubtotalDataTableRequest : GetTypedViewCollectionRequest<OrderSubtotal, OrderSubtotalCollectionResponse>
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

    }

    [Route("/views/ordersubtotal", Verbs = "GET")] // general query
    [DefaultView("OrderSubtotalTypedView")]
    public partial class OrderSubtotalQueryCollectionRequest : GetTypedViewCollectionRequest<OrderSubtotal, OrderSubtotalCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class OrderSubtotalCollectionResponse : GetTypedViewCollectionResponse<OrderSubtotal>
    {
        public OrderSubtotalCollectionResponse(): base(){}
        public OrderSubtotalCollectionResponse(IEnumerable<OrderSubtotal> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                         
    }
    #endregion
}
