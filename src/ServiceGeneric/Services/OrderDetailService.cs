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
    public partial class OrderDetailService : ServiceBase<OrderDetail, IOrderDetailServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(OrderDetailMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(OrderDetailDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public OrderDetailCollectionResponse Get(OrderDetailQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }



        //Pk request
        public OrderDetailResponse Get(OrderDetailPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public OrderDetailResponse Any(OrderDetailAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public OrderDetailResponse Any(OrderDetailUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(OrderDetailDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("orderdetails/meta", Verbs = "GET")] // unique constraint filter
    public partial class OrderDetailMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("orderdetails/datatable", Verbs = "POST")] // general query
    public partial class OrderDetailDataTableRequest : GetCollectionRequest<OrderDetail, OrderDetailCollectionResponse>
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

    }



    [Route("orderdetails/{OrderId}/{ProductId}", Verbs = "GET")] // primary key filter
    public partial class OrderDetailPkRequest: GetRequest<OrderDetail, OrderDetailResponse>
    {
        public System.Int32 OrderId { get; set; }
        public System.Int32 ProductId { get; set; }

    }

    [Route("orderdetails", Verbs = "GET")] // general query
    [DefaultView("OrderDetailView")]
    public partial class OrderDetailQueryCollectionRequest : GetCollectionRequest<OrderDetail, OrderDetailCollectionResponse>
    {
    }

    [Route("orderdetails", Verbs = "POST")] // add item
    public partial class OrderDetailAddRequest : OrderDetail, IReturn<OrderDetailResponse>
    {

    }

    [Route("orderdetails/{OrderId}/{ProductId}", Verbs = "PUT")] // update item
    [Route("orderdetails/{OrderId}/{ProductId}/update", Verbs = "POST")] // delete item
    public partial class OrderDetailUpdateRequest : OrderDetail, IReturn<OrderDetailResponse>
    {

    }

    [Route("orderdetails/{OrderId}/{ProductId}", Verbs = "DELETE")] // delete item
    [Route("orderdetails/{OrderId}/{ProductId}/delete", Verbs = "POST")] // delete item
    public partial class OrderDetailDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 OrderId { get; set; }
        public System.Int32 ProductId { get; set; }

    }
    #endregion

    #region Responses
    public partial class OrderDetailResponse : GetResponse<OrderDetail>
    {
        public OrderDetailResponse() : base() { }
        public OrderDetailResponse(OrderDetail category) : base(category) { }
    }

    public partial class OrderDetailCollectionResponse : GetCollectionResponse<OrderDetail>
    {
        public OrderDetailCollectionResponse(): base(){}
        public OrderDetailCollectionResponse(IEnumerable<OrderDetail> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
