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
    public partial class RegionService : ServiceBase<Region, IRegionServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(RegionMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(RegionDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public RegionCollectionResponse Get(RegionQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        public RegionResponse Get(RegionUcRegionDescriptionRequest request)
        {
            return Repository.Fetch(request);
        }


        //Pk request
        public RegionResponse Get(RegionPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public RegionResponse Any(RegionAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public RegionResponse Any(RegionUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(RegionDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("regions/meta", Verbs = "GET")] // unique constraint filter
    public partial class RegionMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("regions/datatable", Verbs = "POST")] // general query
    public partial class RegionDataTableRequest : GetCollectionRequest<Region, RegionCollectionResponse>
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

    [Route("regions/uc/regiondescription/{RegionDescription}", Verbs = "GET")] // unique constraint filter
    public partial class RegionUcRegionDescriptionRequest : GetRequest<Region, RegionResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String RegionDescription { get; set; }

    }


    [Route("regions/{RegionId}", Verbs = "GET")] // primary key filter
    public partial class RegionPkRequest: GetRequest<Region, RegionResponse>
    {
        public System.Int32 RegionId { get; set; }

    }

    [Route("regions", Verbs = "GET")] // general query
    [DefaultView("RegionView")]
    public partial class RegionQueryCollectionRequest : GetCollectionRequest<Region, RegionCollectionResponse>
    {
    }

    [Route("regions", Verbs = "POST")] // add item
    public partial class RegionAddRequest : Region, IReturn<RegionResponse>
    {

    }

    [Route("regions/{RegionId}", Verbs = "PUT")] // update item
    [Route("regions/{RegionId}/update", Verbs = "POST")] // delete item
    public partial class RegionUpdateRequest : Region, IReturn<RegionResponse>
    {

    }

    [Route("regions/{RegionId}", Verbs = "DELETE")] // delete item
    [Route("regions/{RegionId}/delete", Verbs = "POST")] // delete item
    public partial class RegionDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 RegionId { get; set; }

    }
    #endregion

    #region Responses
    public partial class RegionResponse : GetResponse<Region>
    {
        public RegionResponse() : base() { }
        public RegionResponse(Region category) : base(category) { }
    }

    public partial class RegionCollectionResponse : GetCollectionResponse<Region>
    {
        public RegionCollectionResponse(): base(){}
        public RegionCollectionResponse(IEnumerable<Region> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
