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
using Northwind.Data.ServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services
{
    #region Service
    /// <summary>Service class for the entity 'Order'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                   
    public partial class OrderService : ServiceBase<Order, IOrderServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetOrderMetaRequest(OrderMetaRequest request);
        partial void OnAfterGetOrderMetaRequest(OrderMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostOrderDataTableRequest(OrderDataTableRequest request);
        partial void OnAfterPostOrderDataTableRequest(OrderDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetOrderQueryCollectionRequest(OrderQueryCollectionRequest request);
        partial void OnAfterGetOrderQueryCollectionRequest(OrderQueryCollectionRequest request, OrderCollectionResponse response);
        partial void OnBeforeGetOrderPkRequest(OrderPkRequest request);
        partial void OnAfterGetOrderPkRequest(OrderPkRequest request, OrderResponse response);

        partial void OnBeforeOrderAddRequest(OrderAddRequest request);
        partial void OnAfterOrderAddRequest(OrderAddRequest request, OrderResponse response);
        partial void OnBeforeOrderUpdateRequest(OrderUpdateRequest request);
        partial void OnAfterOrderUpdateRequest(OrderUpdateRequest request, OrderResponse response);
        partial void OnBeforeOrderDeleteRequest(OrderDeleteRequest request);
        partial void OnAfterOrderDeleteRequest(OrderDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<Order> Validator { get; set; }
    
        public OrderService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Order' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(OrderMetaRequest request)
        {
            OnBeforeGetOrderMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetOrderMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Order' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(OrderDataTableRequest request)
        {
            OnBeforePostOrderDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostOrderDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Order' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public OrderCollectionResponse Get(OrderQueryCollectionRequest request)
        {
            OnBeforeGetOrderQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetOrderQueryCollectionRequest(request, output);
            return output;
        }



        /// <summary>Gets a specific 'Order' based on it's primary key.</summary>
        public OrderResponse Get(OrderPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Order { OrderId = request.OrderId }, "PkRequest");

            OnBeforeGetOrderPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetOrderPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Order matching [OrderId = {0}]  does not exist".Fmt(request.OrderId));
            return output;
        }

        [Authenticate]
        public OrderResponse Any(OrderAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeOrderAddRequest(request);

            var output = Repository.Create(request);
            OnAfterOrderAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public OrderResponse Any(OrderUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeOrderUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterOrderUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(OrderDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Order { OrderId = request.OrderId }, ApplyTo.Delete);
                
            OnBeforeOrderDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterOrderDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Order matching [OrderId = {0}]  does not exist".Fmt(request.OrderId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/orders/meta", Verbs = "GET")]
    public partial class OrderMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/orders/datatable", Verbs = "POST")] // general query
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
        public int[] iSelectColumns { get; set; }

        public int iSortCol_0 { get; set; } //Field: OrderId
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; } //Field: CustomerId
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; } //Field: EmployeeId
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }
        public int iSortCol_3 { get; set; } //Field: OrderDate
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }
        public int iSortCol_4 { get; set; } //Field: RequiredDate
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }
        public int iSortCol_5 { get; set; } //Field: ShippedDate
        public string sSortDir_5 { get; set; }
        public string bSortable_5 { get; set; } 
        public string mDataProp_5 { get; set; } 
        public string bRegex_5 { get; set; }
        public string bSearchable_5 { get; set; }
        public int iSortCol_6 { get; set; } //Field: ShipVia
        public string sSortDir_6 { get; set; }
        public string bSortable_6 { get; set; } 
        public string mDataProp_6 { get; set; } 
        public string bRegex_6 { get; set; }
        public string bSearchable_6 { get; set; }
        public int iSortCol_7 { get; set; } //Field: Freight
        public string sSortDir_7 { get; set; }
        public string bSortable_7 { get; set; } 
        public string mDataProp_7 { get; set; } 
        public string bRegex_7 { get; set; }
        public string bSearchable_7 { get; set; }
        public int iSortCol_8 { get; set; } //Field: ShipName
        public string sSortDir_8 { get; set; }
        public string bSortable_8 { get; set; } 
        public string mDataProp_8 { get; set; } 
        public string bRegex_8 { get; set; }
        public string bSearchable_8 { get; set; }
        public int iSortCol_9 { get; set; } //Field: ShipAddress
        public string sSortDir_9 { get; set; }
        public string bSortable_9 { get; set; } 
        public string mDataProp_9 { get; set; } 
        public string bRegex_9 { get; set; }
        public string bSearchable_9 { get; set; }
        public int iSortCol_10 { get; set; } //Field: ShipCity
        public string sSortDir_10 { get; set; }
        public string bSortable_10 { get; set; } 
        public string mDataProp_10 { get; set; } 
        public string bRegex_10 { get; set; }
        public string bSearchable_10 { get; set; }
        public int iSortCol_11 { get; set; } //Field: ShipRegion
        public string sSortDir_11 { get; set; }
        public string bSortable_11 { get; set; } 
        public string mDataProp_11 { get; set; } 
        public string bRegex_11 { get; set; }
        public string bSearchable_11 { get; set; }
        public int iSortCol_12 { get; set; } //Field: ShipPostalCode
        public string sSortDir_12 { get; set; }
        public string bSortable_12 { get; set; } 
        public string mDataProp_12 { get; set; } 
        public string bRegex_12 { get; set; }
        public string bSearchable_12 { get; set; }
        public int iSortCol_13 { get; set; } //Field: ShipCountry
        public string sSortDir_13 { get; set; }
        public string bSortable_13 { get; set; } 
        public string mDataProp_13 { get; set; } 
        public string bRegex_13 { get; set; }
        public string bSearchable_13 { get; set; }

    }



    [Route("/orders/{OrderId}", Verbs = "GET")] // primary key filter
    public partial class OrderPkRequest: GetRequest<Order, OrderResponse>
    {
        public System.Int32 OrderId { get; set; }

    }

    [Route("/orders", Verbs = "GET")] // general query
    [DefaultView("OrderView")]
    public partial class OrderQueryCollectionRequest : GetCollectionRequest<Order, OrderCollectionResponse>
    {
    }

    [Route("/orders", Verbs = "POST")] // add item
    public partial class OrderAddRequest : Order, IReturn<OrderResponse>
    {

    }

    [Route("/orders/{OrderId}", Verbs = "PUT")] // update item
    [Route("/orders/{OrderId}/update", Verbs = "POST")] // delete item
    public partial class OrderUpdateRequest : Order, IReturn<OrderResponse>
    {

    }

    [Route("/orders/{OrderId}", Verbs = "DELETE")] // delete item
    [Route("/orders/{OrderId}/delete", Verbs = "POST")] // delete item
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
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                     
    }

    public partial class OrderCollectionResponse : GetCollectionResponse<Order>
    {
        public OrderCollectionResponse(): base(){}
        public OrderCollectionResponse(IEnumerable<Order> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                     
    }
    #endregion
}
