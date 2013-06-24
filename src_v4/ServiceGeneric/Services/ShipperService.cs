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
    /// <summary>Service class for the entity 'Shipper'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END            
    public partial class ShipperService : ServiceBase<Shipper, IShipperServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetShipperMetaRequest(ShipperMetaRequest request);
        partial void OnAfterGetShipperMetaRequest(ShipperMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostShipperDataTableRequest(ShipperDataTableRequest request);
        partial void OnAfterPostShipperDataTableRequest(ShipperDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetShipperQueryCollectionRequest(ShipperQueryCollectionRequest request);
        partial void OnAfterGetShipperQueryCollectionRequest(ShipperQueryCollectionRequest request, ShipperCollectionResponse response);
        partial void OnBeforeGetShipperUcShipperNameRequest(ShipperUcShipperNameRequest request);
        partial void OnAfterGetShipperUcShipperNameRequest(ShipperUcShipperNameRequest request, ShipperResponse response);
        partial void OnBeforeGetShipperPkRequest(ShipperPkRequest request);
        partial void OnAfterGetShipperPkRequest(ShipperPkRequest request, ShipperResponse response);

        partial void OnBeforeShipperAddRequest(ShipperAddRequest request);
        partial void OnAfterShipperAddRequest(ShipperAddRequest request, ShipperResponse response);
        partial void OnBeforeShipperUpdateRequest(ShipperUpdateRequest request);
        partial void OnAfterShipperUpdateRequest(ShipperUpdateRequest request, ShipperResponse response);
        partial void OnBeforeShipperDeleteRequest(ShipperDeleteRequest request);
        partial void OnAfterShipperDeleteRequest(ShipperDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<Shipper> Validator { get; set; }
    
        public ShipperService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Shipper' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(ShipperMetaRequest request)
        {
            OnBeforeGetShipperMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetShipperMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Shipper' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(ShipperDataTableRequest request)
        {
            OnBeforePostShipperDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostShipperDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Shipper' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public ShipperCollectionResponse Get(ShipperQueryCollectionRequest request)
        {
            OnBeforeGetShipperQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetShipperQueryCollectionRequest(request, output);
            return output;
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        /// <summary>Gets a specific 'Shipper' based on the 'UcShipperName' unique constraint.</summary>
        public ShipperResponse Get(ShipperUcShipperNameRequest request)
        {
            if(Validator != null)
                Validator.ValidateAndThrow(new Shipper { CompanyName = request.CompanyName }, "UcShipperName");
                
            OnBeforeGetShipperUcShipperNameRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetShipperUcShipperNameRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Shipper matching [CompanyName = {0}]  does not exist".Fmt(request.CompanyName));
            return output;
        }


        /// <summary>Gets a specific 'Shipper' based on it's primary key.</summary>
        public ShipperResponse Get(ShipperPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Shipper { ShipperId = request.ShipperId }, "PkRequest");

            OnBeforeGetShipperPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetShipperPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Shipper matching [ShipperId = {0}]  does not exist".Fmt(request.ShipperId));
            return output;
        }

        [Authenticate]
        public ShipperResponse Any(ShipperAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeShipperAddRequest(request);

            var output = Repository.Create(request);
            OnAfterShipperAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public ShipperResponse Any(ShipperUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeShipperUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterShipperUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(ShipperDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Shipper { ShipperId = request.ShipperId }, ApplyTo.Delete);
                
            OnBeforeShipperDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterShipperDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Shipper matching [ShipperId = {0}]  does not exist".Fmt(request.ShipperId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/shippers/meta", Verbs = "GET")]
    public partial class ShipperMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/shippers/datatable", Verbs = "POST")] // general query
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
        public int[] iSelectColumns { get; set; }

        public int iSortCol_0 { get; set; } //Field: ShipperId
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; } //Field: CompanyName
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; } //Field: Phone
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }

    }

    [Route("/shippers/uc/shippername/{CompanyName}", Verbs = "GET")] // unique constraint filter
    public partial class ShipperUcShipperNameRequest : GetRequest<Shipper, ShipperResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CompanyName { get; set; }

    }


    [Route("/shippers/{ShipperId}", Verbs = "GET")] // primary key filter
    public partial class ShipperPkRequest: GetRequest<Shipper, ShipperResponse>
    {
        public System.Int32 ShipperId { get; set; }

    }

    [Route("/shippers", Verbs = "GET")] // general query
    [DefaultView("ShipperView")]
    public partial class ShipperQueryCollectionRequest : GetCollectionRequest<Shipper, ShipperCollectionResponse>
    {
    }

    [Route("/shippers", Verbs = "POST")] // add item
    public partial class ShipperAddRequest : Shipper, IReturn<ShipperResponse>
    {

    }

    [Route("/shippers/{ShipperId}", Verbs = "PUT")] // update item
    [Route("/shippers/{ShipperId}/update", Verbs = "POST")] // delete item
    public partial class ShipperUpdateRequest : Shipper, IReturn<ShipperResponse>
    {

    }

    [Route("/shippers/{ShipperId}", Verbs = "DELETE")] // delete item
    [Route("/shippers/{ShipperId}/delete", Verbs = "POST")] // delete item
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
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }

    public partial class ShipperCollectionResponse : GetCollectionResponse<Shipper>
    {
        public ShipperCollectionResponse(): base(){}
        public ShipperCollectionResponse(IEnumerable<Shipper> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }
    #endregion
}
