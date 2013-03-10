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
    public partial class CustomerDemographicService : ServiceBase<CustomerDemographic, ICustomerDemographicServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(CustomerDemographicMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(CustomerDemographicDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public CustomerDemographicCollectionResponse Get(CustomerDemographicQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }



        //Pk request
        public CustomerDemographicResponse Get(CustomerDemographicPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public CustomerDemographicResponse Any(CustomerDemographicAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public CustomerDemographicResponse Any(CustomerDemographicUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(CustomerDemographicDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("customerdemographics/meta", Verbs = "GET")] // unique constraint filter
    public partial class CustomerDemographicMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("customerdemographics/datatable", Verbs = "POST")] // general query
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



    [Route("customerdemographics/{CustomerTypeId}", Verbs = "GET")] // primary key filter
    public partial class CustomerDemographicPkRequest: GetRequest<CustomerDemographic, CustomerDemographicResponse>
    {
        public System.String CustomerTypeId { get; set; }

    }

    [Route("customerdemographics", Verbs = "GET")] // general query
    [DefaultView("CustomerDemographicView")]
    public partial class CustomerDemographicQueryCollectionRequest : GetCollectionRequest<CustomerDemographic, CustomerDemographicCollectionResponse>
    {
    }

    [Route("customerdemographics", Verbs = "POST")] // add item
    public partial class CustomerDemographicAddRequest : CustomerDemographic, IReturn<CustomerDemographicResponse>
    {

    }

    [Route("customerdemographics/{CustomerTypeId}", Verbs = "PUT")] // update item
    [Route("customerdemographics/{CustomerTypeId}/update", Verbs = "POST")] // delete item
    public partial class CustomerDemographicUpdateRequest : CustomerDemographic, IReturn<CustomerDemographicResponse>
    {

    }

    [Route("customerdemographics/{CustomerTypeId}", Verbs = "DELETE")] // delete item
    [Route("customerdemographics/{CustomerTypeId}/delete", Verbs = "POST")] // delete item
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
    }

    public partial class CustomerDemographicCollectionResponse : GetCollectionResponse<CustomerDemographic>
    {
        public CustomerDemographicCollectionResponse(): base(){}
        public CustomerDemographicCollectionResponse(IEnumerable<CustomerDemographic> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
