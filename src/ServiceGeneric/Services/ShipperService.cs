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
    public partial class ShipperService : ServiceBase<Shipper, IShipperServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(ShipperMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(ShipperDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public ShipperCollectionResponse Get(ShipperQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        public ShipperResponse Get(ShipperUcShipperNameRequest request)
        {
            return Repository.Fetch(request);
        }


        //Pk request
        public ShipperResponse Get(ShipperPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public ShipperResponse Any(ShipperAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public ShipperResponse Any(ShipperUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(ShipperDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("shippers/meta", Verbs = "GET")] // unique constraint filter
    public partial class ShipperMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("shippers/datatable", Verbs = "POST")] // general query
    public partial class ShipperDataTableRequest : GetCollectionRequest<Shipper, ShipperCollectionResponse>
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

    }

    [Route("shippers/uc/shippername/{CompanyName}", Verbs = "GET")] // unique constraint filter
    public partial class ShipperUcShipperNameRequest : GetRequest<Shipper, ShipperResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CompanyName { get; set; }

    }


    [Route("shippers/{ShipperId}", Verbs = "GET")] // primary key filter
    public partial class ShipperPkRequest: GetRequest<Shipper, ShipperResponse>
    {
        public System.Int32 ShipperId { get; set; }

    }

    [Route("shippers", Verbs = "GET")] // general query
    [DefaultView("ShipperView")]
    public partial class ShipperQueryCollectionRequest : GetCollectionRequest<Shipper, ShipperCollectionResponse>
    {
    }

    [Route("shippers", Verbs = "POST")] // add item
    public partial class ShipperAddRequest : Shipper, IReturn<ShipperResponse>
    {

    }

    [Route("shippers/{ShipperId}", Verbs = "PUT")] // update item
    [Route("shippers/{ShipperId}/update", Verbs = "POST")] // delete item
    public partial class ShipperUpdateRequest : Shipper, IReturn<ShipperResponse>
    {

    }

    [Route("shippers/{ShipperId}", Verbs = "DELETE")] // delete item
    [Route("shippers/{ShipperId}/delete", Verbs = "POST")] // delete item
    public partial class ShipperDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 ShipperId { get; set; }

    }
    #endregion

    #region Responses
    public partial class ShipperResponse : GetResponse<Shipper>
    {
        public ShipperResponse() : base() { }
        public ShipperResponse(Shipper category) : base(category) { }
    }

    public partial class ShipperCollectionResponse : GetCollectionResponse<Shipper>
    {
        public ShipperCollectionResponse(): base(){}
        public ShipperCollectionResponse(IEnumerable<Shipper> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
