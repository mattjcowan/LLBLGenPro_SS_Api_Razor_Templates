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
    /// <summary>Service class for the entity 'Region'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END  
    public partial class RegionService : ServiceBase<Region, IRegionServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetRegionMetaRequest(RegionMetaRequest request);
        partial void OnAfterGetRegionMetaRequest(RegionMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostRegionDataTableRequest(RegionDataTableRequest request);
        partial void OnAfterPostRegionDataTableRequest(RegionDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetRegionQueryCollectionRequest(RegionQueryCollectionRequest request);
        partial void OnAfterGetRegionQueryCollectionRequest(RegionQueryCollectionRequest request, RegionCollectionResponse response);
        partial void OnBeforeGetRegionUcRegionDescriptionRequest(RegionUcRegionDescriptionRequest request);
        partial void OnAfterGetRegionUcRegionDescriptionRequest(RegionUcRegionDescriptionRequest request, RegionResponse response);
        partial void OnBeforeGetRegionPkRequest(RegionPkRequest request);
        partial void OnAfterGetRegionPkRequest(RegionPkRequest request, RegionResponse response);
        partial void OnBeforeRegionAddRequest(RegionAddRequest request);
        partial void OnAfterRegionAddRequest(RegionAddRequest request, RegionResponse response);
        partial void OnBeforeRegionUpdateRequest(RegionUpdateRequest request);
        partial void OnAfterRegionUpdateRequest(RegionUpdateRequest request, RegionResponse response);
        partial void OnBeforeRegionDeleteRequest(RegionDeleteRequest request);
        partial void OnAfterRegionDeleteRequest(RegionDeleteRequest request, SimpleResponse<bool> deleted);
        #endregion
    
        
        public IValidator<Region> Validator { get; set; }
    
        public RegionService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Region' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(RegionMetaRequest request)
        {
            OnBeforeGetRegionMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetRegionMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Region' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(RegionDataTableRequest request)
        {
            OnBeforePostRegionDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostRegionDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Region' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public RegionCollectionResponse Get(RegionQueryCollectionRequest request)
        {
            OnBeforeGetRegionQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetRegionQueryCollectionRequest(request, output);
            return output;
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        /// <summary>Gets a specific 'Region' based on the 'UcRegionDescription' unique constraint.</summary>
        public RegionResponse Get(RegionUcRegionDescriptionRequest request)
        {
            if(Validator != null)
                Validator.ValidateAndThrow(new Region { RegionDescription = request.RegionDescription }, "UcRegionDescription");
                
            OnBeforeGetRegionUcRegionDescriptionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetRegionUcRegionDescriptionRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Region matching [RegionDescription = {0}]  does not exist".Fmt(request.RegionDescription));
            return output;
        }


        /// <summary>Gets a specific 'Region' based on it's primary key.</summary>
        public RegionResponse Get(RegionPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Region { RegionId = request.RegionId }, "PkRequest");

            OnBeforeGetRegionPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetRegionPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Region matching [RegionId = {0}]  does not exist".Fmt(request.RegionId));
            return output;
        }

        [Authenticate]
        public RegionResponse Any(RegionAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeRegionAddRequest(request);

            var output = Repository.Create(request);
            OnAfterRegionAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public RegionResponse Any(RegionUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeRegionUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterRegionUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(RegionDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Region { RegionId = request.RegionId }, ApplyTo.Delete);
                
            OnBeforeRegionDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterRegionDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Region matching [RegionId = {0}]  does not exist".Fmt(request.RegionId));
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/regions/meta", Verbs = "GET")]
    public partial class RegionMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/regions/datatable", Verbs = "POST")] // general query
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

    [Route("/regions/uc/regiondescription/{RegionDescription}", Verbs = "GET")] // unique constraint filter
    public partial class RegionUcRegionDescriptionRequest : GetRequest<Region, RegionResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String RegionDescription { get; set; }

    }


    [Route("/regions/{RegionId}", Verbs = "GET")] // primary key filter
    public partial class RegionPkRequest: GetRequest<Region, RegionResponse>
    {
        public System.Int32 RegionId { get; set; }

    }

    [Route("/regions", Verbs = "GET")] // general query
    [DefaultView("RegionView")]
    public partial class RegionQueryCollectionRequest : GetCollectionRequest<Region, RegionCollectionResponse>
    {
    }

    [Route("/regions", Verbs = "POST")] // add item
    public partial class RegionAddRequest : Region, IReturn<RegionResponse>
    {

    }

    [Route("/regions/{RegionId}", Verbs = "PUT")] // update item
    [Route("/regions/{RegionId}/update", Verbs = "POST")] // delete item
    public partial class RegionUpdateRequest : Region, IReturn<RegionResponse>
    {

    }

    [Route("/regions/{RegionId}", Verbs = "DELETE")] // delete item
    [Route("/regions/{RegionId}/delete", Verbs = "POST")] // delete item
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
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END   
    }

    public partial class RegionCollectionResponse : GetCollectionResponse<Region>
    {
        public RegionCollectionResponse(): base(){}
        public RegionCollectionResponse(IEnumerable<Region> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END   
    }
    #endregion
}
