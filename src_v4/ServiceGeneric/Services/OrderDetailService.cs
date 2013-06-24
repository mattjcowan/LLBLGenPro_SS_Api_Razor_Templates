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
    /// <summary>Service class for the entity 'OrderDetail'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END            
    public partial class OrderDetailService : ServiceBase<OrderDetail, IOrderDetailServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetOrderDetailMetaRequest(OrderDetailMetaRequest request);
        partial void OnAfterGetOrderDetailMetaRequest(OrderDetailMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostOrderDetailDataTableRequest(OrderDetailDataTableRequest request);
        partial void OnAfterPostOrderDetailDataTableRequest(OrderDetailDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetOrderDetailQueryCollectionRequest(OrderDetailQueryCollectionRequest request);
        partial void OnAfterGetOrderDetailQueryCollectionRequest(OrderDetailQueryCollectionRequest request, OrderDetailCollectionResponse response);
        partial void OnBeforeGetOrderDetailPkRequest(OrderDetailPkRequest request);
        partial void OnAfterGetOrderDetailPkRequest(OrderDetailPkRequest request, OrderDetailResponse response);

        partial void OnBeforeOrderDetailAddRequest(OrderDetailAddRequest request);
        partial void OnAfterOrderDetailAddRequest(OrderDetailAddRequest request, OrderDetailResponse response);
        partial void OnBeforeOrderDetailUpdateRequest(OrderDetailUpdateRequest request);
        partial void OnAfterOrderDetailUpdateRequest(OrderDetailUpdateRequest request, OrderDetailResponse response);
        partial void OnBeforeOrderDetailDeleteRequest(OrderDetailDeleteRequest request);
        partial void OnAfterOrderDetailDeleteRequest(OrderDetailDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<OrderDetail> Validator { get; set; }
    
        public OrderDetailService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'OrderDetail' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(OrderDetailMetaRequest request)
        {
            OnBeforeGetOrderDetailMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetOrderDetailMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'OrderDetail' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(OrderDetailDataTableRequest request)
        {
            OnBeforePostOrderDetailDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostOrderDetailDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'OrderDetail' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public OrderDetailCollectionResponse Get(OrderDetailQueryCollectionRequest request)
        {
            OnBeforeGetOrderDetailQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetOrderDetailQueryCollectionRequest(request, output);
            return output;
        }



        /// <summary>Gets a specific 'OrderDetail' based on it's primary key.</summary>
        public OrderDetailResponse Get(OrderDetailPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new OrderDetail { OrderId = request.OrderId, ProductId = request.ProductId }, "PkRequest");

            OnBeforeGetOrderDetailPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetOrderDetailPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "OrderDetail matching [OrderId = {0}, ProductId = {1}]  does not exist".Fmt(request.OrderId, request.ProductId));
            return output;
        }

        [Authenticate]
        public OrderDetailResponse Any(OrderDetailAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeOrderDetailAddRequest(request);

            var output = Repository.Create(request);
            OnAfterOrderDetailAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public OrderDetailResponse Any(OrderDetailUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeOrderDetailUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterOrderDetailUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(OrderDetailDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new OrderDetail { OrderId = request.OrderId, ProductId = request.ProductId }, ApplyTo.Delete);
                
            OnBeforeOrderDetailDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterOrderDetailDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "OrderDetail matching [OrderId = {0}, ProductId = {1}]  does not exist".Fmt(request.OrderId, request.ProductId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/orderdetails/meta", Verbs = "GET")]
    public partial class OrderDetailMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/orderdetails/datatable", Verbs = "POST")] // general query
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
        public int[] iSelectColumns { get; set; }

        public int iSortCol_0 { get; set; } //Field: OrderId
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; } //Field: ProductId
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; } //Field: UnitPrice
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }
        public int iSortCol_3 { get; set; } //Field: Quantity
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }
        public int iSortCol_4 { get; set; } //Field: Discount
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }

    }



    [Route("/orderdetails/{OrderId}/{ProductId}", Verbs = "GET")] // primary key filter
    public partial class OrderDetailPkRequest: GetRequest<OrderDetail, OrderDetailResponse>
    {
        public System.Int32 OrderId { get; set; }
        public System.Int32 ProductId { get; set; }

    }

    [Route("/orderdetails", Verbs = "GET")] // general query
    [DefaultView("OrderDetailView")]
    public partial class OrderDetailQueryCollectionRequest : GetCollectionRequest<OrderDetail, OrderDetailCollectionResponse>
    {
    }

    [Route("/orderdetails", Verbs = "POST")] // add item
    public partial class OrderDetailAddRequest : OrderDetail, IReturn<OrderDetailResponse>
    {

    }

    [Route("/orderdetails/{OrderId}/{ProductId}", Verbs = "PUT")] // update item
    [Route("/orderdetails/{OrderId}/{ProductId}/update", Verbs = "POST")] // delete item
    public partial class OrderDetailUpdateRequest : OrderDetail, IReturn<OrderDetailResponse>
    {

    }

    [Route("/orderdetails/{OrderId}/{ProductId}", Verbs = "DELETE")] // delete item
    [Route("/orderdetails/{OrderId}/{ProductId}/delete", Verbs = "POST")] // delete item
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
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }

    public partial class OrderDetailCollectionResponse : GetCollectionResponse<OrderDetail>
    {
        public OrderDetailCollectionResponse(): base(){}
        public OrderDetailCollectionResponse(IEnumerable<OrderDetail> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }
    #endregion
}
