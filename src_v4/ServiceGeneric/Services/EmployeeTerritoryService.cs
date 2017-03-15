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
    /// <summary>Service class for the entity 'EmployeeTerritory'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                   
    public partial class EmployeeTerritoryService : ServiceBase<EmployeeTerritory, IEmployeeTerritoryServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetEmployeeTerritoryMetaRequest(EmployeeTerritoryMetaRequest request);
        partial void OnAfterGetEmployeeTerritoryMetaRequest(EmployeeTerritoryMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostEmployeeTerritoryDataTableRequest(EmployeeTerritoryDataTableRequest request);
        partial void OnAfterPostEmployeeTerritoryDataTableRequest(EmployeeTerritoryDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetEmployeeTerritoryQueryCollectionRequest(EmployeeTerritoryQueryCollectionRequest request);
        partial void OnAfterGetEmployeeTerritoryQueryCollectionRequest(EmployeeTerritoryQueryCollectionRequest request, EmployeeTerritoryCollectionResponse response);
        partial void OnBeforeGetEmployeeTerritoryPkRequest(EmployeeTerritoryPkRequest request);
        partial void OnAfterGetEmployeeTerritoryPkRequest(EmployeeTerritoryPkRequest request, EmployeeTerritoryResponse response);

        partial void OnBeforeEmployeeTerritoryAddRequest(EmployeeTerritoryAddRequest request);
        partial void OnAfterEmployeeTerritoryAddRequest(EmployeeTerritoryAddRequest request, EmployeeTerritoryResponse response);
        partial void OnBeforeEmployeeTerritoryUpdateRequest(EmployeeTerritoryUpdateRequest request);
        partial void OnAfterEmployeeTerritoryUpdateRequest(EmployeeTerritoryUpdateRequest request, EmployeeTerritoryResponse response);
        partial void OnBeforeEmployeeTerritoryDeleteRequest(EmployeeTerritoryDeleteRequest request);
        partial void OnAfterEmployeeTerritoryDeleteRequest(EmployeeTerritoryDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<EmployeeTerritory> Validator { get; set; }
    
        public EmployeeTerritoryService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'EmployeeTerritory' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(EmployeeTerritoryMetaRequest request)
        {
            OnBeforeGetEmployeeTerritoryMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetEmployeeTerritoryMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'EmployeeTerritory' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(EmployeeTerritoryDataTableRequest request)
        {
            OnBeforePostEmployeeTerritoryDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostEmployeeTerritoryDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'EmployeeTerritory' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public EmployeeTerritoryCollectionResponse Get(EmployeeTerritoryQueryCollectionRequest request)
        {
            OnBeforeGetEmployeeTerritoryQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetEmployeeTerritoryQueryCollectionRequest(request, output);
            return output;
        }



        /// <summary>Gets a specific 'EmployeeTerritory' based on it's primary key.</summary>
        public EmployeeTerritoryResponse Get(EmployeeTerritoryPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new EmployeeTerritory { EmployeeId = request.EmployeeId, TerritoryId = request.TerritoryId }, "PkRequest");

            OnBeforeGetEmployeeTerritoryPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetEmployeeTerritoryPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "EmployeeTerritory matching [EmployeeId = {0}, TerritoryId = {1}]  does not exist".Fmt(request.EmployeeId, request.TerritoryId));
            return output;
        }

        [Authenticate]
        public EmployeeTerritoryResponse Any(EmployeeTerritoryAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeEmployeeTerritoryAddRequest(request);

            var output = Repository.Create(request);
            OnAfterEmployeeTerritoryAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public EmployeeTerritoryResponse Any(EmployeeTerritoryUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeEmployeeTerritoryUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterEmployeeTerritoryUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(EmployeeTerritoryDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new EmployeeTerritory { EmployeeId = request.EmployeeId, TerritoryId = request.TerritoryId }, ApplyTo.Delete);
                
            OnBeforeEmployeeTerritoryDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterEmployeeTerritoryDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "EmployeeTerritory matching [EmployeeId = {0}, TerritoryId = {1}]  does not exist".Fmt(request.EmployeeId, request.TerritoryId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/employeeterritories/meta", Verbs = "GET")]
    public partial class EmployeeTerritoryMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/employeeterritories/datatable", Verbs = "POST")] // general query
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
        public int[] iSelectColumns { get; set; }

        public int iSortCol_0 { get; set; } //Field: EmployeeId
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; } //Field: TerritoryId
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }

    }



    [Route("/employeeterritories/{EmployeeId}/{TerritoryId}", Verbs = "GET")] // primary key filter
    public partial class EmployeeTerritoryPkRequest: GetRequest<EmployeeTerritory, EmployeeTerritoryResponse>
    {
        public System.Int32 EmployeeId { get; set; }
        public System.String TerritoryId { get; set; }

    }

    [Route("/employeeterritories", Verbs = "GET")] // general query
    [DefaultView("EmployeeTerritoryView")]
    public partial class EmployeeTerritoryQueryCollectionRequest : GetCollectionRequest<EmployeeTerritory, EmployeeTerritoryCollectionResponse>
    {
    }

    [Route("/employeeterritories", Verbs = "POST")] // add item
    public partial class EmployeeTerritoryAddRequest : EmployeeTerritory, IReturn<EmployeeTerritoryResponse>
    {

    }

    [Route("/employeeterritories/{EmployeeId}/{TerritoryId}", Verbs = "PUT")] // update item
    [Route("/employeeterritories/{EmployeeId}/{TerritoryId}/update", Verbs = "POST")] // delete item
    public partial class EmployeeTerritoryUpdateRequest : EmployeeTerritory, IReturn<EmployeeTerritoryResponse>
    {

    }

    [Route("/employeeterritories/{EmployeeId}/{TerritoryId}", Verbs = "DELETE")] // delete item
    [Route("/employeeterritories/{EmployeeId}/{TerritoryId}/delete", Verbs = "POST")] // delete item
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
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                     
    }

    public partial class EmployeeTerritoryCollectionResponse : GetCollectionResponse<EmployeeTerritory>
    {
        public EmployeeTerritoryCollectionResponse(): base(){}
        public EmployeeTerritoryCollectionResponse(IEnumerable<EmployeeTerritory> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                     
    }
    #endregion
}
