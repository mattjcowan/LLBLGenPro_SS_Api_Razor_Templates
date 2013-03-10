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
    public partial class CustomerService : ServiceBase<Customer, ICustomerServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(CustomerMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(CustomerDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public CustomerCollectionResponse Get(CustomerQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        public CustomerResponse Get(CustomerUcCompanyNameRequest request)
        {
            return Repository.Fetch(request);
        }


        //Pk request
        public CustomerResponse Get(CustomerPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public CustomerResponse Any(CustomerAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public CustomerResponse Any(CustomerUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(CustomerDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("customers/meta", Verbs = "GET")] // unique constraint filter
    public partial class CustomerMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("customers/datatable", Verbs = "POST")] // general query
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

    }

    [Route("customers/uc/companyname/{CompanyName}", Verbs = "GET")] // unique constraint filter
    public partial class CustomerUcCompanyNameRequest : GetRequest<Customer, CustomerResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CompanyName { get; set; }

    }


    [Route("customers/{CustomerId}", Verbs = "GET")] // primary key filter
    public partial class CustomerPkRequest: GetRequest<Customer, CustomerResponse>
    {
        public System.String CustomerId { get; set; }

    }

    [Route("customers", Verbs = "GET")] // general query
    [DefaultView("CustomerView")]
    public partial class CustomerQueryCollectionRequest : GetCollectionRequest<Customer, CustomerCollectionResponse>
    {
    }

    [Route("customers", Verbs = "POST")] // add item
    public partial class CustomerAddRequest : Customer, IReturn<CustomerResponse>
    {

    }

    [Route("customers/{CustomerId}", Verbs = "PUT")] // update item
    [Route("customers/{CustomerId}/update", Verbs = "POST")] // delete item
    public partial class CustomerUpdateRequest : Customer, IReturn<CustomerResponse>
    {

    }

    [Route("customers/{CustomerId}", Verbs = "DELETE")] // delete item
    [Route("customers/{CustomerId}/delete", Verbs = "POST")] // delete item
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
    }

    public partial class CustomerCollectionResponse : GetCollectionResponse<Customer>
    {
        public CustomerCollectionResponse(): base(){}
        public CustomerCollectionResponse(IEnumerable<Customer> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
