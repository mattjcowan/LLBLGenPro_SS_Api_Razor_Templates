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
    public partial class TerritoryService : ServiceBase<Territory, ITerritoryServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(TerritoryMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(TerritoryDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public TerritoryCollectionResponse Get(TerritoryQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }



        //Pk request
        public TerritoryResponse Get(TerritoryPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public TerritoryResponse Any(TerritoryAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public TerritoryResponse Any(TerritoryUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(TerritoryDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("territories/meta", Verbs = "GET")] // unique constraint filter
    public partial class TerritoryMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("territories/datatable", Verbs = "POST")] // general query
    public partial class TerritoryDataTableRequest : GetCollectionRequest<Territory, TerritoryCollectionResponse>
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



    [Route("territories/{TerritoryId}", Verbs = "GET")] // primary key filter
    public partial class TerritoryPkRequest: GetRequest<Territory, TerritoryResponse>
    {
        public System.String TerritoryId { get; set; }

    }

    [Route("territories", Verbs = "GET")] // general query
    [DefaultView("TerritoryView")]
    public partial class TerritoryQueryCollectionRequest : GetCollectionRequest<Territory, TerritoryCollectionResponse>
    {
    }

    [Route("territories", Verbs = "POST")] // add item
    public partial class TerritoryAddRequest : Territory, IReturn<TerritoryResponse>
    {

    }

    [Route("territories/{TerritoryId}", Verbs = "PUT")] // update item
    [Route("territories/{TerritoryId}/update", Verbs = "POST")] // delete item
    public partial class TerritoryUpdateRequest : Territory, IReturn<TerritoryResponse>
    {

    }

    [Route("territories/{TerritoryId}", Verbs = "DELETE")] // delete item
    [Route("territories/{TerritoryId}/delete", Verbs = "POST")] // delete item
    public partial class TerritoryDeleteRequest: SimpleRequest<bool>
    {
        public System.String TerritoryId { get; set; }

    }
    #endregion

    #region Responses
    public partial class TerritoryResponse : GetResponse<Territory>
    {
        public TerritoryResponse() : base() { }
        public TerritoryResponse(Territory category) : base(category) { }
    }

    public partial class TerritoryCollectionResponse : GetCollectionResponse<Territory>
    {
        public TerritoryCollectionResponse(): base(){}
        public TerritoryCollectionResponse(IEnumerable<Territory> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
