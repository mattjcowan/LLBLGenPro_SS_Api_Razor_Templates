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
    /// <summary>Service class for the entity 'CustomerDemographic'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END  
    public partial class CustomerDemographicService : ServiceBase<CustomerDemographic, ICustomerDemographicServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetCustomerDemographicMetaRequest(CustomerDemographicMetaRequest request);
        partial void OnAfterGetCustomerDemographicMetaRequest(CustomerDemographicMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostCustomerDemographicDataTableRequest(CustomerDemographicDataTableRequest request);
        partial void OnAfterPostCustomerDemographicDataTableRequest(CustomerDemographicDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetCustomerDemographicQueryCollectionRequest(CustomerDemographicQueryCollectionRequest request);
        partial void OnAfterGetCustomerDemographicQueryCollectionRequest(CustomerDemographicQueryCollectionRequest request, CustomerDemographicCollectionResponse response);
        partial void OnBeforeGetCustomerDemographicPkRequest(CustomerDemographicPkRequest request);
        partial void OnAfterGetCustomerDemographicPkRequest(CustomerDemographicPkRequest request, CustomerDemographicResponse response);
        partial void OnBeforeCustomerDemographicAddRequest(CustomerDemographicAddRequest request);
        partial void OnAfterCustomerDemographicAddRequest(CustomerDemographicAddRequest request, CustomerDemographicResponse response);
        partial void OnBeforeCustomerDemographicUpdateRequest(CustomerDemographicUpdateRequest request);
        partial void OnAfterCustomerDemographicUpdateRequest(CustomerDemographicUpdateRequest request, CustomerDemographicResponse response);
        partial void OnBeforeCustomerDemographicDeleteRequest(CustomerDemographicDeleteRequest request);
        partial void OnAfterCustomerDemographicDeleteRequest(CustomerDemographicDeleteRequest request, SimpleResponse<bool> deleted);
        #endregion
    
        
        public IValidator<CustomerDemographic> Validator { get; set; }
    
        public CustomerDemographicService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'CustomerDemographic' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(CustomerDemographicMetaRequest request)
        {
            OnBeforeGetCustomerDemographicMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetCustomerDemographicMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'CustomerDemographic' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(CustomerDemographicDataTableRequest request)
        {
            OnBeforePostCustomerDemographicDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostCustomerDemographicDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'CustomerDemographic' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public CustomerDemographicCollectionResponse Get(CustomerDemographicQueryCollectionRequest request)
        {
            OnBeforeGetCustomerDemographicQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerDemographicQueryCollectionRequest(request, output);
            return output;
        }



        /// <summary>Gets a specific 'CustomerDemographic' based on it's primary key.</summary>
        public CustomerDemographicResponse Get(CustomerDemographicPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new CustomerDemographic { CustomerTypeId = request.CustomerTypeId }, "PkRequest");

            OnBeforeGetCustomerDemographicPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerDemographicPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "CustomerDemographic matching [CustomerTypeId = {0}]  does not exist".Fmt(request.CustomerTypeId));
            return output;
        }

        [Authenticate]
        public CustomerDemographicResponse Any(CustomerDemographicAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeCustomerDemographicAddRequest(request);

            var output = Repository.Create(request);
            OnAfterCustomerDemographicAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public CustomerDemographicResponse Any(CustomerDemographicUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeCustomerDemographicUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterCustomerDemographicUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(CustomerDemographicDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new CustomerDemographic { CustomerTypeId = request.CustomerTypeId }, ApplyTo.Delete);
                
            OnBeforeCustomerDemographicDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterCustomerDemographicDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "CustomerDemographic matching [CustomerTypeId = {0}]  does not exist".Fmt(request.CustomerTypeId));
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/customerdemographics/meta", Verbs = "GET")]
    public partial class CustomerDemographicMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/customerdemographics/datatable", Verbs = "POST")] // general query
    public partial class CustomerDemographicDataTableRequest : GetCollectionRequest<CustomerDemographic, CustomerDemographicCollectionResponse>
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



    [Route("/customerdemographics/{CustomerTypeId}", Verbs = "GET")] // primary key filter
    public partial class CustomerDemographicPkRequest: GetRequest<CustomerDemographic, CustomerDemographicResponse>
    {
        public System.String CustomerTypeId { get; set; }

    }

    [Route("/customerdemographics", Verbs = "GET")] // general query
    [DefaultView("CustomerDemographicView")]
    public partial class CustomerDemographicQueryCollectionRequest : GetCollectionRequest<CustomerDemographic, CustomerDemographicCollectionResponse>
    {
    }

    [Route("/customerdemographics", Verbs = "POST")] // add item
    public partial class CustomerDemographicAddRequest : CustomerDemographic, IReturn<CustomerDemographicResponse>
    {

    }

    [Route("/customerdemographics/{CustomerTypeId}", Verbs = "PUT")] // update item
    [Route("/customerdemographics/{CustomerTypeId}/update", Verbs = "POST")] // delete item
    public partial class CustomerDemographicUpdateRequest : CustomerDemographic, IReturn<CustomerDemographicResponse>
    {

    }

    [Route("/customerdemographics/{CustomerTypeId}", Verbs = "DELETE")] // delete item
    [Route("/customerdemographics/{CustomerTypeId}/delete", Verbs = "POST")] // delete item
    public partial class CustomerDemographicDeleteRequest: SimpleRequest<bool>
    {
        public System.String CustomerTypeId { get; set; }

    }
    #endregion

    #region Responses
    public partial class CustomerDemographicResponse : GetResponse<CustomerDemographic>
    {
        public CustomerDemographicResponse() : base() { }
        public CustomerDemographicResponse(CustomerDemographic category) : base(category) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END   
    }

    public partial class CustomerDemographicCollectionResponse : GetCollectionResponse<CustomerDemographic>
    {
        public CustomerDemographicCollectionResponse(): base(){}
        public CustomerDemographicCollectionResponse(IEnumerable<CustomerDemographic> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END   
    }
    #endregion
}
