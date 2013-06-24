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
    /// <summary>Service class for the entity 'Customer'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                     
    public partial class CustomerService : ServiceBase<Customer, ICustomerServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetCustomerMetaRequest(CustomerMetaRequest request);
        partial void OnAfterGetCustomerMetaRequest(CustomerMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostCustomerDataTableRequest(CustomerDataTableRequest request);
        partial void OnAfterPostCustomerDataTableRequest(CustomerDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetCustomerQueryCollectionRequest(CustomerQueryCollectionRequest request);
        partial void OnAfterGetCustomerQueryCollectionRequest(CustomerQueryCollectionRequest request, CustomerCollectionResponse response);
        partial void OnBeforeGetCustomerUcCompanyNameRequest(CustomerUcCompanyNameRequest request);
        partial void OnAfterGetCustomerUcCompanyNameRequest(CustomerUcCompanyNameRequest request, CustomerResponse response);
        partial void OnBeforeGetCustomerPkRequest(CustomerPkRequest request);
        partial void OnAfterGetCustomerPkRequest(CustomerPkRequest request, CustomerResponse response);

        partial void OnBeforeCustomerAddRequest(CustomerAddRequest request);
        partial void OnAfterCustomerAddRequest(CustomerAddRequest request, CustomerResponse response);
        partial void OnBeforeCustomerUpdateRequest(CustomerUpdateRequest request);
        partial void OnAfterCustomerUpdateRequest(CustomerUpdateRequest request, CustomerResponse response);
        partial void OnBeforeCustomerDeleteRequest(CustomerDeleteRequest request);
        partial void OnAfterCustomerDeleteRequest(CustomerDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<Customer> Validator { get; set; }
    
        public CustomerService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Customer' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(CustomerMetaRequest request)
        {
            OnBeforeGetCustomerMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetCustomerMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Customer' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(CustomerDataTableRequest request)
        {
            OnBeforePostCustomerDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostCustomerDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Customer' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public CustomerCollectionResponse Get(CustomerQueryCollectionRequest request)
        {
            OnBeforeGetCustomerQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerQueryCollectionRequest(request, output);
            return output;
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        /// <summary>Gets a specific 'Customer' based on the 'UcCompanyName' unique constraint.</summary>
        public CustomerResponse Get(CustomerUcCompanyNameRequest request)
        {
            if(Validator != null)
                Validator.ValidateAndThrow(new Customer { CompanyName = request.CompanyName }, "UcCompanyName");
                
            OnBeforeGetCustomerUcCompanyNameRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerUcCompanyNameRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Customer matching [CompanyName = {0}]  does not exist".Fmt(request.CompanyName));
            return output;
        }


        /// <summary>Gets a specific 'Customer' based on it's primary key.</summary>
        public CustomerResponse Get(CustomerPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Customer { CustomerId = request.CustomerId }, "PkRequest");

            OnBeforeGetCustomerPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Customer matching [CustomerId = {0}]  does not exist".Fmt(request.CustomerId));
            return output;
        }

        [Authenticate]
        public CustomerResponse Any(CustomerAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeCustomerAddRequest(request);

            var output = Repository.Create(request);
            OnAfterCustomerAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public CustomerResponse Any(CustomerUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeCustomerUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterCustomerUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(CustomerDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Customer { CustomerId = request.CustomerId }, ApplyTo.Delete);
                
            OnBeforeCustomerDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterCustomerDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Customer matching [CustomerId = {0}]  does not exist".Fmt(request.CustomerId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/customers/meta", Verbs = "GET")]
    public partial class CustomerMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/customers/datatable", Verbs = "POST")] // general query
    public partial class CustomerDataTableRequest : GetCollectionRequest<Customer, CustomerCollectionResponse>
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

        public int iSortCol_0 { get; set; } //Field: CustomerId
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; } //Field: CompanyName
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; } //Field: ContactName
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }
        public int iSortCol_3 { get; set; } //Field: ContactTitle
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }
        public int iSortCol_4 { get; set; } //Field: Address
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }
        public int iSortCol_5 { get; set; } //Field: City
        public string sSortDir_5 { get; set; }
        public string bSortable_5 { get; set; } 
        public string mDataProp_5 { get; set; } 
        public string bRegex_5 { get; set; }
        public string bSearchable_5 { get; set; }
        public int iSortCol_6 { get; set; } //Field: Region
        public string sSortDir_6 { get; set; }
        public string bSortable_6 { get; set; } 
        public string mDataProp_6 { get; set; } 
        public string bRegex_6 { get; set; }
        public string bSearchable_6 { get; set; }
        public int iSortCol_7 { get; set; } //Field: PostalCode
        public string sSortDir_7 { get; set; }
        public string bSortable_7 { get; set; } 
        public string mDataProp_7 { get; set; } 
        public string bRegex_7 { get; set; }
        public string bSearchable_7 { get; set; }
        public int iSortCol_8 { get; set; } //Field: Country
        public string sSortDir_8 { get; set; }
        public string bSortable_8 { get; set; } 
        public string mDataProp_8 { get; set; } 
        public string bRegex_8 { get; set; }
        public string bSearchable_8 { get; set; }
        public int iSortCol_9 { get; set; } //Field: Phone
        public string sSortDir_9 { get; set; }
        public string bSortable_9 { get; set; } 
        public string mDataProp_9 { get; set; } 
        public string bRegex_9 { get; set; }
        public string bSearchable_9 { get; set; }
        public int iSortCol_10 { get; set; } //Field: Fax
        public string sSortDir_10 { get; set; }
        public string bSortable_10 { get; set; } 
        public string mDataProp_10 { get; set; } 
        public string bRegex_10 { get; set; }
        public string bSearchable_10 { get; set; }

    }

    [Route("/customers/uc/companyname/{CompanyName}", Verbs = "GET")] // unique constraint filter
    public partial class CustomerUcCompanyNameRequest : GetRequest<Customer, CustomerResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CompanyName { get; set; }

    }


    [Route("/customers/{CustomerId}", Verbs = "GET")] // primary key filter
    public partial class CustomerPkRequest: GetRequest<Customer, CustomerResponse>
    {
        public System.String CustomerId { get; set; }

    }

    [Route("/customers", Verbs = "GET")] // general query
    [DefaultView("CustomerView")]
    public partial class CustomerQueryCollectionRequest : GetCollectionRequest<Customer, CustomerCollectionResponse>
    {
    }

    [Route("/customers", Verbs = "POST")] // add item
    public partial class CustomerAddRequest : Customer, IReturn<CustomerResponse>
    {

    }

    [Route("/customers/{CustomerId}", Verbs = "PUT")] // update item
    [Route("/customers/{CustomerId}/update", Verbs = "POST")] // delete item
    public partial class CustomerUpdateRequest : Customer, IReturn<CustomerResponse>
    {

    }

    [Route("/customers/{CustomerId}", Verbs = "DELETE")] // delete item
    [Route("/customers/{CustomerId}/delete", Verbs = "POST")] // delete item
    public partial class CustomerDeleteRequest: SimpleRequest<bool>
    {
        public System.String CustomerId { get; set; }

    }
    #endregion

    #region Responses
    public partial class CustomerResponse : GetResponse<Customer>
    {
        public CustomerResponse() : base() { }
        public CustomerResponse(Customer category) : base(category) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                                                         
    }

    public partial class CustomerCollectionResponse : GetCollectionResponse<Customer>
    {
        public CustomerCollectionResponse(): base(){}
        public CustomerCollectionResponse(IEnumerable<Customer> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                                                         
    }
    #endregion
}
