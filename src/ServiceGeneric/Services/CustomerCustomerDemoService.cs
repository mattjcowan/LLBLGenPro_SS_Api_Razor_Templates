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
    public partial class CustomerCustomerDemoService : ServiceBase<CustomerCustomerDemo, ICustomerCustomerDemoServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(CustomerCustomerDemoMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(CustomerCustomerDemoDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public CustomerCustomerDemoCollectionResponse Get(CustomerCustomerDemoQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }



        //Pk request
        public CustomerCustomerDemoResponse Get(CustomerCustomerDemoPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public CustomerCustomerDemoResponse Any(CustomerCustomerDemoAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public CustomerCustomerDemoResponse Any(CustomerCustomerDemoUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(CustomerCustomerDemoDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("customercustomerdemos/meta", Verbs = "GET")] // unique constraint filter
    public partial class CustomerCustomerDemoMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("customercustomerdemos/datatable", Verbs = "POST")] // general query
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



    [Route("customercustomerdemos/{CustomerId}/{CustomerTypeId}", Verbs = "GET")] // primary key filter
    public partial class CustomerCustomerDemoPkRequest: GetRequest<CustomerCustomerDemo, CustomerCustomerDemoResponse>
    {
        public System.String CustomerId { get; set; }
        public System.String CustomerTypeId { get; set; }

    }

    [Route("customercustomerdemos", Verbs = "GET")] // general query
    [DefaultView("CustomerCustomerDemoView")]
    public partial class CustomerCustomerDemoQueryCollectionRequest : GetCollectionRequest<CustomerCustomerDemo, CustomerCustomerDemoCollectionResponse>
    {
    }

    [Route("customercustomerdemos", Verbs = "POST")] // add item
    public partial class CustomerCustomerDemoAddRequest : CustomerCustomerDemo, IReturn<CustomerCustomerDemoResponse>
    {

    }

    [Route("customercustomerdemos/{CustomerId}/{CustomerTypeId}", Verbs = "PUT")] // update item
    [Route("customercustomerdemos/{CustomerId}/{CustomerTypeId}/update", Verbs = "POST")] // delete item
    public partial class CustomerCustomerDemoUpdateRequest : CustomerCustomerDemo, IReturn<CustomerCustomerDemoResponse>
    {

    }

    [Route("customercustomerdemos/{CustomerId}/{CustomerTypeId}", Verbs = "DELETE")] // delete item
    [Route("customercustomerdemos/{CustomerId}/{CustomerTypeId}/delete", Verbs = "POST")] // delete item
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
    }

    public partial class CustomerCustomerDemoCollectionResponse : GetCollectionResponse<CustomerCustomerDemo>
    {
        public CustomerCustomerDemoCollectionResponse(): base(){}
        public CustomerCustomerDemoCollectionResponse(IEnumerable<CustomerCustomerDemo> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
