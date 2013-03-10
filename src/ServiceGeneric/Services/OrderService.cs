using System;
using System.Collections.Generic;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;

namespace Northwind.Data.Services
{
    #region Service
    public partial class OrderService : ServiceBase<Order, IOrderServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(OrderMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(OrderDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public OrderCollectionResponse Get(OrderQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }



        //Pk request
        public OrderResponse Get(OrderPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public OrderResponse Any(OrderAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public OrderResponse Any(OrderUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(OrderDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("orders/meta", Verbs = "GET")] // unique constraint filter
    public partial class OrderMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("orders/datatable", Verbs = "POST")] // general query
    public partial class OrderDataTableRequest : GetCollectionRequest<Order, OrderCollectionResponse>
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

    }



    [Route("orders/{OrderId}", Verbs = "GET")] // primary key filter
    public partial class OrderPkRequest: GetRequest<Order, OrderResponse>
    {
        public System.Int32 OrderId { get; set; }

    }

    [Route("orders", Verbs = "GET")] // general query
    [DefaultView("OrderView")]
    public partial class OrderQueryCollectionRequest : GetCollectionRequest<Order, OrderCollectionResponse>
    {
    }

    [Route("orders", Verbs = "POST")] // add item
    public partial class OrderAddRequest : Order, IReturn<OrderResponse>
    {

    }

    [Route("orders/{OrderId}", Verbs = "PUT")] // update item
    [Route("orders/{OrderId}/update", Verbs = "POST")] // delete item
    public partial class OrderUpdateRequest : Order, IReturn<OrderResponse>
    {

    }

    [Route("orders/{OrderId}", Verbs = "DELETE")] // delete item
    [Route("orders/{OrderId}/delete", Verbs = "POST")] // delete item
    public partial class OrderDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 OrderId { get; set; }

    }
    #endregion

    #region Responses
    public partial class OrderResponse : GetResponse<Order>
    {
        public OrderResponse() : base() { }
        public OrderResponse(Order category) : base(category) { }
    }

    public partial class OrderCollectionResponse : GetCollectionResponse<Order>
    {
        public OrderCollectionResponse(): base(){}
        public OrderCollectionResponse(IEnumerable<Order> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
