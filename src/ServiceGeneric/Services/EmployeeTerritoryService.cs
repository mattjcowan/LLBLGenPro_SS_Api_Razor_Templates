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
    public partial class EmployeeTerritoryService : ServiceBase<EmployeeTerritory, IEmployeeTerritoryServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(EmployeeTerritoryMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(EmployeeTerritoryDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public EmployeeTerritoryCollectionResponse Get(EmployeeTerritoryQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }



        //Pk request
        public EmployeeTerritoryResponse Get(EmployeeTerritoryPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public EmployeeTerritoryResponse Any(EmployeeTerritoryAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public EmployeeTerritoryResponse Any(EmployeeTerritoryUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(EmployeeTerritoryDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("employeeterritories/meta", Verbs = "GET")] // unique constraint filter
    public partial class EmployeeTerritoryMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("employeeterritories/datatable", Verbs = "POST")] // general query
    public partial class EmployeeTerritoryDataTableRequest : GetCollectionRequest<EmployeeTerritory, EmployeeTerritoryCollectionResponse>
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



    [Route("employeeterritories/{EmployeeId}/{TerritoryId}", Verbs = "GET")] // primary key filter
    public partial class EmployeeTerritoryPkRequest: GetRequest<EmployeeTerritory, EmployeeTerritoryResponse>
    {
        public System.Int32 EmployeeId { get; set; }
        public System.String TerritoryId { get; set; }

    }

    [Route("employeeterritories", Verbs = "GET")] // general query
    [DefaultView("EmployeeTerritoryView")]
    public partial class EmployeeTerritoryQueryCollectionRequest : GetCollectionRequest<EmployeeTerritory, EmployeeTerritoryCollectionResponse>
    {
    }

    [Route("employeeterritories", Verbs = "POST")] // add item
    public partial class EmployeeTerritoryAddRequest : EmployeeTerritory, IReturn<EmployeeTerritoryResponse>
    {

    }

    [Route("employeeterritories/{EmployeeId}/{TerritoryId}", Verbs = "PUT")] // update item
    [Route("employeeterritories/{EmployeeId}/{TerritoryId}/update", Verbs = "POST")] // delete item
    public partial class EmployeeTerritoryUpdateRequest : EmployeeTerritory, IReturn<EmployeeTerritoryResponse>
    {

    }

    [Route("employeeterritories/{EmployeeId}/{TerritoryId}", Verbs = "DELETE")] // delete item
    [Route("employeeterritories/{EmployeeId}/{TerritoryId}/delete", Verbs = "POST")] // delete item
    public partial class EmployeeTerritoryDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 EmployeeId { get; set; }
        public System.String TerritoryId { get; set; }

    }
    #endregion

    #region Responses
    public partial class EmployeeTerritoryResponse : GetResponse<EmployeeTerritory>
    {
        public EmployeeTerritoryResponse() : base() { }
        public EmployeeTerritoryResponse(EmployeeTerritory category) : base(category) { }
    }

    public partial class EmployeeTerritoryCollectionResponse : GetCollectionResponse<EmployeeTerritory>
    {
        public EmployeeTerritoryCollectionResponse(): base(){}
        public EmployeeTerritoryCollectionResponse(IEnumerable<EmployeeTerritory> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
