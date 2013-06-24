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
    /// <summary>Service class for the entity 'Supplier'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END            
    public partial class SupplierService : ServiceBase<Supplier, ISupplierServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetSupplierMetaRequest(SupplierMetaRequest request);
        partial void OnAfterGetSupplierMetaRequest(SupplierMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostSupplierDataTableRequest(SupplierDataTableRequest request);
        partial void OnAfterPostSupplierDataTableRequest(SupplierDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetSupplierQueryCollectionRequest(SupplierQueryCollectionRequest request);
        partial void OnAfterGetSupplierQueryCollectionRequest(SupplierQueryCollectionRequest request, SupplierCollectionResponse response);
        partial void OnBeforeGetSupplierUcSupplierNameRequest(SupplierUcSupplierNameRequest request);
        partial void OnAfterGetSupplierUcSupplierNameRequest(SupplierUcSupplierNameRequest request, SupplierResponse response);
        partial void OnBeforeGetSupplierPkRequest(SupplierPkRequest request);
        partial void OnAfterGetSupplierPkRequest(SupplierPkRequest request, SupplierResponse response);

        partial void OnBeforeSupplierAddRequest(SupplierAddRequest request);
        partial void OnAfterSupplierAddRequest(SupplierAddRequest request, SupplierResponse response);
        partial void OnBeforeSupplierUpdateRequest(SupplierUpdateRequest request);
        partial void OnAfterSupplierUpdateRequest(SupplierUpdateRequest request, SupplierResponse response);
        partial void OnBeforeSupplierDeleteRequest(SupplierDeleteRequest request);
        partial void OnAfterSupplierDeleteRequest(SupplierDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<Supplier> Validator { get; set; }
    
        public SupplierService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Supplier' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(SupplierMetaRequest request)
        {
            OnBeforeGetSupplierMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetSupplierMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Supplier' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(SupplierDataTableRequest request)
        {
            OnBeforePostSupplierDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostSupplierDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Supplier' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public SupplierCollectionResponse Get(SupplierQueryCollectionRequest request)
        {
            OnBeforeGetSupplierQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetSupplierQueryCollectionRequest(request, output);
            return output;
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        /// <summary>Gets a specific 'Supplier' based on the 'UcSupplierName' unique constraint.</summary>
        public SupplierResponse Get(SupplierUcSupplierNameRequest request)
        {
            if(Validator != null)
                Validator.ValidateAndThrow(new Supplier { CompanyName = request.CompanyName }, "UcSupplierName");
                
            OnBeforeGetSupplierUcSupplierNameRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetSupplierUcSupplierNameRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Supplier matching [CompanyName = {0}]  does not exist".Fmt(request.CompanyName));
            return output;
        }


        /// <summary>Gets a specific 'Supplier' based on it's primary key.</summary>
        public SupplierResponse Get(SupplierPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Supplier { SupplierId = request.SupplierId }, "PkRequest");

            OnBeforeGetSupplierPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetSupplierPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Supplier matching [SupplierId = {0}]  does not exist".Fmt(request.SupplierId));
            return output;
        }

        [Authenticate]
        public SupplierResponse Any(SupplierAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeSupplierAddRequest(request);

            var output = Repository.Create(request);
            OnAfterSupplierAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public SupplierResponse Any(SupplierUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeSupplierUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterSupplierUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(SupplierDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Supplier { SupplierId = request.SupplierId }, ApplyTo.Delete);
                
            OnBeforeSupplierDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterSupplierDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Supplier matching [SupplierId = {0}]  does not exist".Fmt(request.SupplierId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/suppliers/meta", Verbs = "GET")]
    public partial class SupplierMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/suppliers/datatable", Verbs = "POST")] // general query
    public partial class SupplierDataTableRequest : GetCollectionRequest<Supplier, SupplierCollectionResponse>
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

        public int iSortCol_0 { get; set; } //Field: SupplierId
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
        public int iSortCol_2 { get; set; } //Field: ContactName
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }
        public int iSortCol_3 { get; set; } //Field: ContactTitle
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }
        public int iSortCol_4 { get; set; } //Field: Address
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }
        public int iSortCol_5 { get; set; } //Field: City
        public string sSortDir_5 { get; set; }
        public string bSortable_5 { get; set; } 
        public string mDataProp_5 { get; set; } 
        public string bRegex_5 { get; set; }
        public string bSearchable_5 { get; set; }
        public int iSortCol_6 { get; set; } //Field: Region
        public string sSortDir_6 { get; set; }
        public string bSortable_6 { get; set; } 
        public string mDataProp_6 { get; set; } 
        public string bRegex_6 { get; set; }
        public string bSearchable_6 { get; set; }
        public int iSortCol_7 { get; set; } //Field: PostalCode
        public string sSortDir_7 { get; set; }
        public string bSortable_7 { get; set; } 
        public string mDataProp_7 { get; set; } 
        public string bRegex_7 { get; set; }
        public string bSearchable_7 { get; set; }
        public int iSortCol_8 { get; set; } //Field: Country
        public string sSortDir_8 { get; set; }
        public string bSortable_8 { get; set; } 
        public string mDataProp_8 { get; set; } 
        public string bRegex_8 { get; set; }
        public string bSearchable_8 { get; set; }
        public int iSortCol_9 { get; set; } //Field: Phone
        public string sSortDir_9 { get; set; }
        public string bSortable_9 { get; set; } 
        public string mDataProp_9 { get; set; } 
        public string bRegex_9 { get; set; }
        public string bSearchable_9 { get; set; }
        public int iSortCol_10 { get; set; } //Field: Fax
        public string sSortDir_10 { get; set; }
        public string bSortable_10 { get; set; } 
        public string mDataProp_10 { get; set; } 
        public string bRegex_10 { get; set; }
        public string bSearchable_10 { get; set; }
        public int iSortCol_11 { get; set; } //Field: HomePage
        public string sSortDir_11 { get; set; }
        public string bSortable_11 { get; set; } 
        public string mDataProp_11 { get; set; } 
        public string bRegex_11 { get; set; }
        public string bSearchable_11 { get; set; }

    }

    [Route("/suppliers/uc/suppliername/{CompanyName}", Verbs = "GET")] // unique constraint filter
    public partial class SupplierUcSupplierNameRequest : GetRequest<Supplier, SupplierResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CompanyName { get; set; }

    }


    [Route("/suppliers/{SupplierId}", Verbs = "GET")] // primary key filter
    public partial class SupplierPkRequest: GetRequest<Supplier, SupplierResponse>
    {
        public System.Int32 SupplierId { get; set; }

    }

    [Route("/suppliers", Verbs = "GET")] // general query
    [DefaultView("SupplierView")]
    public partial class SupplierQueryCollectionRequest : GetCollectionRequest<Supplier, SupplierCollectionResponse>
    {
    }

    [Route("/suppliers", Verbs = "POST")] // add item
    public partial class SupplierAddRequest : Supplier, IReturn<SupplierResponse>
    {

    }

    [Route("/suppliers/{SupplierId}", Verbs = "PUT")] // update item
    [Route("/suppliers/{SupplierId}/update", Verbs = "POST")] // delete item
    public partial class SupplierUpdateRequest : Supplier, IReturn<SupplierResponse>
    {

    }

    [Route("/suppliers/{SupplierId}", Verbs = "DELETE")] // delete item
    [Route("/suppliers/{SupplierId}/delete", Verbs = "POST")] // delete item
    public partial class SupplierDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 SupplierId { get; set; }

    }
    #endregion

    #region Responses
    public partial class SupplierResponse : GetResponse<Supplier>
    {
        public SupplierResponse() : base() { }
        public SupplierResponse(Supplier category) : base(category) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }

    public partial class SupplierCollectionResponse : GetCollectionResponse<Supplier>
    {
        public SupplierCollectionResponse(): base(){}
        public SupplierCollectionResponse(IEnumerable<Supplier> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }
    #endregion
}
