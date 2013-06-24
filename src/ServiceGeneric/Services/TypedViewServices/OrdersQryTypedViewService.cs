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
    /// <summary>Service class for the typed view 'OrdersQry'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                
    public partial class OrdersQryTypedViewService : TypedViewServiceBase<OrdersQry, IOrdersQryTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetOrdersQryMetaRequest(OrdersQryMetaRequest request);
        partial void OnAfterGetOrdersQryMetaRequest(OrdersQryMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostOrdersQryDataTableRequest(OrdersQryDataTableRequest request);
        partial void OnAfterPostOrdersQryDataTableRequest(OrdersQryDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetOrdersQryQueryCollectionRequest(OrdersQryQueryCollectionRequest request);
        partial void OnAfterGetOrdersQryQueryCollectionRequest(OrdersQryQueryCollectionRequest request, OrdersQryCollectionResponse response);
        #endregion
    
        public OrdersQryTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'OrdersQry' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(OrdersQryMetaRequest request)
        {
            OnBeforeGetOrdersQryMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetOrdersQryMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'OrdersQry' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(OrdersQryDataTableRequest request)
        {
            OnBeforePostOrdersQryDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostOrdersQryDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'OrdersQry' typed view records using sorting, filtering, paging and more.</summary>
        public OrdersQryCollectionResponse Get(OrdersQryQueryCollectionRequest request)
        {
            OnBeforeGetOrdersQryQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetOrdersQryQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/ordersqry/meta", Verbs = "GET")]
    public partial class OrdersQryMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/ordersqry/datatable", Verbs = "POST")] // general query
    public partial class OrdersQryDataTableRequest : GetTypedViewCollectionRequest<OrdersQry, OrdersQryCollectionResponse>
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

    }

    [Route("/views/ordersqry", Verbs = "GET")] // general query
    [DefaultView("OrdersQryTypedView")]
    public partial class OrdersQryQueryCollectionRequest : GetTypedViewCollectionRequest<OrdersQry, OrdersQryCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class OrdersQryCollectionResponse : GetTypedViewCollectionResponse<OrdersQry>
    {
        public OrdersQryCollectionResponse(): base(){}
        public OrdersQryCollectionResponse(IEnumerable<OrdersQry> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                               
    }
    #endregion
}
