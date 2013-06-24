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
    /// <summary>Service class for the entity 'Territory'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END             
    public partial class TerritoryService : ServiceBase<Territory, ITerritoryServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetTerritoryMetaRequest(TerritoryMetaRequest request);
        partial void OnAfterGetTerritoryMetaRequest(TerritoryMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostTerritoryDataTableRequest(TerritoryDataTableRequest request);
        partial void OnAfterPostTerritoryDataTableRequest(TerritoryDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetTerritoryQueryCollectionRequest(TerritoryQueryCollectionRequest request);
        partial void OnAfterGetTerritoryQueryCollectionRequest(TerritoryQueryCollectionRequest request, TerritoryCollectionResponse response);
        partial void OnBeforeGetTerritoryPkRequest(TerritoryPkRequest request);
        partial void OnAfterGetTerritoryPkRequest(TerritoryPkRequest request, TerritoryResponse response);

        partial void OnBeforeTerritoryAddRequest(TerritoryAddRequest request);
        partial void OnAfterTerritoryAddRequest(TerritoryAddRequest request, TerritoryResponse response);
        partial void OnBeforeTerritoryUpdateRequest(TerritoryUpdateRequest request);
        partial void OnAfterTerritoryUpdateRequest(TerritoryUpdateRequest request, TerritoryResponse response);
        partial void OnBeforeTerritoryDeleteRequest(TerritoryDeleteRequest request);
        partial void OnAfterTerritoryDeleteRequest(TerritoryDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<Territory> Validator { get; set; }
    
        public TerritoryService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Territory' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(TerritoryMetaRequest request)
        {
            OnBeforeGetTerritoryMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetTerritoryMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Territory' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(TerritoryDataTableRequest request)
        {
            OnBeforePostTerritoryDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostTerritoryDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Territory' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public TerritoryCollectionResponse Get(TerritoryQueryCollectionRequest request)
        {
            OnBeforeGetTerritoryQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetTerritoryQueryCollectionRequest(request, output);
            return output;
        }



        /// <summary>Gets a specific 'Territory' based on it's primary key.</summary>
        public TerritoryResponse Get(TerritoryPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Territory { TerritoryId = request.TerritoryId }, "PkRequest");

            OnBeforeGetTerritoryPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetTerritoryPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Territory matching [TerritoryId = {0}]  does not exist".Fmt(request.TerritoryId));
            return output;
        }

        [Authenticate]
        public TerritoryResponse Any(TerritoryAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeTerritoryAddRequest(request);

            var output = Repository.Create(request);
            OnAfterTerritoryAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public TerritoryResponse Any(TerritoryUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeTerritoryUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterTerritoryUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(TerritoryDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Territory { TerritoryId = request.TerritoryId }, ApplyTo.Delete);
                
            OnBeforeTerritoryDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterTerritoryDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Territory matching [TerritoryId = {0}]  does not exist".Fmt(request.TerritoryId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/territories/meta", Verbs = "GET")]
    public partial class TerritoryMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/territories/datatable", Verbs = "POST")] // general query
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
        public int[] iSelectColumns { get; set; }

        public int iSortCol_0 { get; set; } //Field: TerritoryId
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; } //Field: TerritoryDescription
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; } //Field: RegionId
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }

    }



    [Route("/territories/{TerritoryId}", Verbs = "GET")] // primary key filter
    public partial class TerritoryPkRequest: GetRequest<Territory, TerritoryResponse>
    {
        public System.String TerritoryId { get; set; }

    }

    [Route("/territories", Verbs = "GET")] // general query
    [DefaultView("TerritoryView")]
    public partial class TerritoryQueryCollectionRequest : GetCollectionRequest<Territory, TerritoryCollectionResponse>
    {
    }

    [Route("/territories", Verbs = "POST")] // add item
    public partial class TerritoryAddRequest : Territory, IReturn<TerritoryResponse>
    {

    }

    [Route("/territories/{TerritoryId}", Verbs = "PUT")] // update item
    [Route("/territories/{TerritoryId}/update", Verbs = "POST")] // delete item
    public partial class TerritoryUpdateRequest : Territory, IReturn<TerritoryResponse>
    {

    }

    [Route("/territories/{TerritoryId}", Verbs = "DELETE")] // delete item
    [Route("/territories/{TerritoryId}/delete", Verbs = "POST")] // delete item
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
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                         
    }

    public partial class TerritoryCollectionResponse : GetCollectionResponse<Territory>
    {
        public TerritoryCollectionResponse(): base(){}
        public TerritoryCollectionResponse(IEnumerable<Territory> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                         
    }
    #endregion
}
