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
    public partial class ProductService : ServiceBase<Product, IProductServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(ProductMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(ProductDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public ProductCollectionResponse Get(ProductQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        public ProductResponse Get(ProductUcProductNameRequest request)
        {
            return Repository.Fetch(request);
        }


        //Pk request
        public ProductResponse Get(ProductPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public ProductResponse Any(ProductAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public ProductResponse Any(ProductUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(ProductDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("products/meta", Verbs = "GET")] // unique constraint filter
    public partial class ProductMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("products/datatable", Verbs = "POST")] // general query
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

    [Route("products/uc/productname/{ProductName}", Verbs = "GET")] // unique constraint filter
    public partial class ProductUcProductNameRequest : GetRequest<Product, ProductResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String ProductName { get; set; }

    }


    [Route("products/{ProductId}", Verbs = "GET")] // primary key filter
    public partial class ProductPkRequest: GetRequest<Product, ProductResponse>
    {
        public System.Int32 ProductId { get; set; }

    }

    [Route("products", Verbs = "GET")] // general query
    [DefaultView("ProductView")]
    public partial class ProductQueryCollectionRequest : GetCollectionRequest<Product, ProductCollectionResponse>
    {
    }

    [Route("products", Verbs = "POST")] // add item
    public partial class ProductAddRequest : Product, IReturn<ProductResponse>
    {

    }

    [Route("products/{ProductId}", Verbs = "PUT")] // update item
    [Route("products/{ProductId}/update", Verbs = "POST")] // delete item
    public partial class ProductUpdateRequest : Product, IReturn<ProductResponse>
    {

    }

    [Route("products/{ProductId}", Verbs = "DELETE")] // delete item
    [Route("products/{ProductId}/delete", Verbs = "POST")] // delete item
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
    }

    public partial class ProductCollectionResponse : GetCollectionResponse<Product>
    {
        public ProductCollectionResponse(): base(){}
        public ProductCollectionResponse(IEnumerable<Product> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
