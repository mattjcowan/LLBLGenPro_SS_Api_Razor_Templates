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
    /// <summary>Service class for the entity 'CustomerCustomerDemo'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                      
    public partial class CustomerCustomerDemoService : ServiceBase<CustomerCustomerDemo, ICustomerCustomerDemoServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetCustomerCustomerDemoMetaRequest(CustomerCustomerDemoMetaRequest request);
        partial void OnAfterGetCustomerCustomerDemoMetaRequest(CustomerCustomerDemoMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostCustomerCustomerDemoDataTableRequest(CustomerCustomerDemoDataTableRequest request);
        partial void OnAfterPostCustomerCustomerDemoDataTableRequest(CustomerCustomerDemoDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetCustomerCustomerDemoQueryCollectionRequest(CustomerCustomerDemoQueryCollectionRequest request);
        partial void OnAfterGetCustomerCustomerDemoQueryCollectionRequest(CustomerCustomerDemoQueryCollectionRequest request, CustomerCustomerDemoCollectionResponse response);
        partial void OnBeforeGetCustomerCustomerDemoPkRequest(CustomerCustomerDemoPkRequest request);
        partial void OnAfterGetCustomerCustomerDemoPkRequest(CustomerCustomerDemoPkRequest request, CustomerCustomerDemoResponse response);
        partial void OnBeforeCustomerCustomerDemoAddRequest(CustomerCustomerDemoAddRequest request);
        partial void OnAfterCustomerCustomerDemoAddRequest(CustomerCustomerDemoAddRequest request, CustomerCustomerDemoResponse response);
        partial void OnBeforeCustomerCustomerDemoUpdateRequest(CustomerCustomerDemoUpdateRequest request);
        partial void OnAfterCustomerCustomerDemoUpdateRequest(CustomerCustomerDemoUpdateRequest request, CustomerCustomerDemoResponse response);
        partial void OnBeforeCustomerCustomerDemoDeleteRequest(CustomerCustomerDemoDeleteRequest request);
        partial void OnAfterCustomerCustomerDemoDeleteRequest(CustomerCustomerDemoDeleteRequest request, SimpleResponse<bool> deleted);
        #endregion
    
        
        public IValidator<CustomerCustomerDemo> Validator { get; set; }
    
        public CustomerCustomerDemoService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'CustomerCustomerDemo' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(CustomerCustomerDemoMetaRequest request)
        {
            OnBeforeGetCustomerCustomerDemoMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetCustomerCustomerDemoMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'CustomerCustomerDemo' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(CustomerCustomerDemoDataTableRequest request)
        {
            OnBeforePostCustomerCustomerDemoDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostCustomerCustomerDemoDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'CustomerCustomerDemo' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public CustomerCustomerDemoCollectionResponse Get(CustomerCustomerDemoQueryCollectionRequest request)
        {
            OnBeforeGetCustomerCustomerDemoQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerCustomerDemoQueryCollectionRequest(request, output);
            return output;
        }



        /// <summary>Gets a specific 'CustomerCustomerDemo' based on it's primary key.</summary>
        public CustomerCustomerDemoResponse Get(CustomerCustomerDemoPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new CustomerCustomerDemo { CustomerId = request.CustomerId, CustomerTypeId = request.CustomerTypeId }, "PkRequest");

            OnBeforeGetCustomerCustomerDemoPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerCustomerDemoPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "CustomerCustomerDemo matching [CustomerId = {0}, CustomerTypeId = {1}]  does not exist".Fmt(request.CustomerId, request.CustomerTypeId));
            return output;
        }

        [Authenticate]
        public CustomerCustomerDemoResponse Any(CustomerCustomerDemoAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeCustomerCustomerDemoAddRequest(request);

            var output = Repository.Create(request);
            OnAfterCustomerCustomerDemoAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public CustomerCustomerDemoResponse Any(CustomerCustomerDemoUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeCustomerCustomerDemoUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterCustomerCustomerDemoUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(CustomerCustomerDemoDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new CustomerCustomerDemo { CustomerId = request.CustomerId, CustomerTypeId = request.CustomerTypeId }, ApplyTo.Delete);
                
            OnBeforeCustomerCustomerDemoDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterCustomerCustomerDemoDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "CustomerCustomerDemo matching [CustomerId = {0}, CustomerTypeId = {1}]  does not exist".Fmt(request.CustomerId, request.CustomerTypeId));
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/customercustomerdemos/meta", Verbs = "GET")]
    public partial class CustomerCustomerDemoMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/customercustomerdemos/datatable", Verbs = "POST")] // general query
    public partial class CustomerCustomerDemoDataTableRequest : GetCollectionRequest<CustomerCustomerDemo, CustomerCustomerDemoCollectionResponse>
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



    [Route("/customercustomerdemos/{CustomerId}/{CustomerTypeId}", Verbs = "GET")] // primary key filter
    public partial class CustomerCustomerDemoPkRequest: GetRequest<CustomerCustomerDemo, CustomerCustomerDemoResponse>
    {
        public System.String CustomerId { get; set; }
        public System.String CustomerTypeId { get; set; }

    }

    [Route("/customercustomerdemos", Verbs = "GET")] // general query
    [DefaultView("CustomerCustomerDemoView")]
    public partial class CustomerCustomerDemoQueryCollectionRequest : GetCollectionRequest<CustomerCustomerDemo, CustomerCustomerDemoCollectionResponse>
    {
    }

    [Route("/customercustomerdemos", Verbs = "POST")] // add item
    public partial class CustomerCustomerDemoAddRequest : CustomerCustomerDemo, IReturn<CustomerCustomerDemoResponse>
    {

    }

    [Route("/customercustomerdemos/{CustomerId}/{CustomerTypeId}", Verbs = "PUT")] // update item
    [Route("/customercustomerdemos/{CustomerId}/{CustomerTypeId}/update", Verbs = "POST")] // delete item
    public partial class CustomerCustomerDemoUpdateRequest : CustomerCustomerDemo, IReturn<CustomerCustomerDemoResponse>
    {

    }

    [Route("/customercustomerdemos/{CustomerId}/{CustomerTypeId}", Verbs = "DELETE")] // delete item
    [Route("/customercustomerdemos/{CustomerId}/{CustomerTypeId}/delete", Verbs = "POST")] // delete item
    public partial class CustomerCustomerDemoDeleteRequest: SimpleRequest<bool>
    {
        public System.String CustomerId { get; set; }
        public System.String CustomerTypeId { get; set; }

    }
    #endregion

    #region Responses
    public partial class CustomerCustomerDemoResponse : GetResponse<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoResponse() : base() { }
        public CustomerCustomerDemoResponse(CustomerCustomerDemo category) : base(category) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                           
    }

    public partial class CustomerCustomerDemoCollectionResponse : GetCollectionResponse<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoCollectionResponse(): base(){}
        public CustomerCustomerDemoCollectionResponse(IEnumerable<CustomerCustomerDemo> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                           
    }
    #endregion
}
