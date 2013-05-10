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
    /// <summary>Service class for the entity 'Product'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END   
    public partial class ProductService : ServiceBase<Product, IProductServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetProductMetaRequest(ProductMetaRequest request);
        partial void OnAfterGetProductMetaRequest(ProductMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostProductDataTableRequest(ProductDataTableRequest request);
        partial void OnAfterPostProductDataTableRequest(ProductDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetProductQueryCollectionRequest(ProductQueryCollectionRequest request);
        partial void OnAfterGetProductQueryCollectionRequest(ProductQueryCollectionRequest request, ProductCollectionResponse response);
        partial void OnBeforeGetProductUcProductNameRequest(ProductUcProductNameRequest request);
        partial void OnAfterGetProductUcProductNameRequest(ProductUcProductNameRequest request, ProductResponse response);
        partial void OnBeforeGetProductPkRequest(ProductPkRequest request);
        partial void OnAfterGetProductPkRequest(ProductPkRequest request, ProductResponse response);
        partial void OnBeforeProductAddRequest(ProductAddRequest request);
        partial void OnAfterProductAddRequest(ProductAddRequest request, ProductResponse response);
        partial void OnBeforeProductUpdateRequest(ProductUpdateRequest request);
        partial void OnAfterProductUpdateRequest(ProductUpdateRequest request, ProductResponse response);
        partial void OnBeforeProductDeleteRequest(ProductDeleteRequest request);
        partial void OnAfterProductDeleteRequest(ProductDeleteRequest request, SimpleResponse<bool> deleted);
        #endregion
    
        
        public IValidator<Product> Validator { get; set; }
    
        public ProductService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Product' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(ProductMetaRequest request)
        {
            OnBeforeGetProductMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetProductMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Product' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(ProductDataTableRequest request)
        {
            OnBeforePostProductDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostProductDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Product' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public ProductCollectionResponse Get(ProductQueryCollectionRequest request)
        {
            OnBeforeGetProductQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetProductQueryCollectionRequest(request, output);
            return output;
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        /// <summary>Gets a specific 'Product' based on the 'UcProductName' unique constraint.</summary>
        public ProductResponse Get(ProductUcProductNameRequest request)
        {
            if(Validator != null)
                Validator.ValidateAndThrow(new Product { ProductName = request.ProductName }, "UcProductName");
                
            OnBeforeGetProductUcProductNameRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetProductUcProductNameRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Product matching [ProductName = {0}]  does not exist".Fmt(request.ProductName));
            return output;
        }


        /// <summary>Gets a specific 'Product' based on it's primary key.</summary>
        public ProductResponse Get(ProductPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Product { ProductId = request.ProductId }, "PkRequest");

            OnBeforeGetProductPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetProductPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Product matching [ProductId = {0}]  does not exist".Fmt(request.ProductId));
            return output;
        }

        [Authenticate]
        public ProductResponse Any(ProductAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeProductAddRequest(request);

            var output = Repository.Create(request);
            OnAfterProductAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public ProductResponse Any(ProductUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeProductUpdateRequest(request);

            var output = Repository.Update(request);
            OnAfterProductUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(ProductDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Product { ProductId = request.ProductId }, ApplyTo.Delete);
                
            OnBeforeProductDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterProductDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Product matching [ProductId = {0}]  does not exist".Fmt(request.ProductId));
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/products/meta", Verbs = "GET")]
    public partial class ProductMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/products/datatable", Verbs = "POST")] // general query
    public partial class ProductDataTableRequest : GetCollectionRequest<Product, ProductCollectionResponse>
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
        public int iSortCol_3 { get; set; }
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }
        public int iSortCol_4 { get; set; }
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }
        public int iSortCol_5 { get; set; }
        public string sSortDir_5 { get; set; }
        public string bSortable_5 { get; set; } 
        public string mDataProp_5 { get; set; } 
        public string bRegex_5 { get; set; }
        public string bSearchable_5 { get; set; }
        public int iSortCol_6 { get; set; }
        public string sSortDir_6 { get; set; }
        public string bSortable_6 { get; set; } 
        public string mDataProp_6 { get; set; } 
        public string bRegex_6 { get; set; }
        public string bSearchable_6 { get; set; }
        public int iSortCol_7 { get; set; }
        public string sSortDir_7 { get; set; }
        public string bSortable_7 { get; set; } 
        public string mDataProp_7 { get; set; } 
        public string bRegex_7 { get; set; }
        public string bSearchable_7 { get; set; }
        public int iSortCol_8 { get; set; }
        public string sSortDir_8 { get; set; }
        public string bSortable_8 { get; set; } 
        public string mDataProp_8 { get; set; } 
        public string bRegex_8 { get; set; }
        public string bSearchable_8 { get; set; }
        public int iSortCol_9 { get; set; }
        public string sSortDir_9 { get; set; }
        public string bSortable_9 { get; set; } 
        public string mDataProp_9 { get; set; } 
        public string bRegex_9 { get; set; }
        public string bSearchable_9 { get; set; }

    }

    [Route("/products/uc/productname/{ProductName}", Verbs = "GET")] // unique constraint filter
    public partial class ProductUcProductNameRequest : GetRequest<Product, ProductResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String ProductName { get; set; }

    }


    [Route("/products/{ProductId}", Verbs = "GET")] // primary key filter
    public partial class ProductPkRequest: GetRequest<Product, ProductResponse>
    {
        public System.Int32 ProductId { get; set; }

    }

    [Route("/products", Verbs = "GET")] // general query
    [DefaultView("ProductView")]
    public partial class ProductQueryCollectionRequest : GetCollectionRequest<Product, ProductCollectionResponse>
    {
    }

    [Route("/products", Verbs = "POST")] // add item
    public partial class ProductAddRequest : Product, IReturn<ProductResponse>
    {

    }

    [Route("/products/{ProductId}", Verbs = "PUT")] // update item
    [Route("/products/{ProductId}/update", Verbs = "POST")] // delete item
    public partial class ProductUpdateRequest : Product, IReturn<ProductResponse>
    {

    }

    [Route("/products/{ProductId}", Verbs = "DELETE")] // delete item
    [Route("/products/{ProductId}/delete", Verbs = "POST")] // delete item
    public partial class ProductDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 ProductId { get; set; }

    }
    #endregion

    #region Responses
    public partial class ProductResponse : GetResponse<Product>
    {
        public ProductResponse() : base() { }
        public ProductResponse(Product category) : base(category) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END     
    }

    public partial class ProductCollectionResponse : GetCollectionResponse<Product>
    {
        public ProductCollectionResponse(): base(){}
        public ProductCollectionResponse(IEnumerable<Product> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END     
    }
    #endregion
}
