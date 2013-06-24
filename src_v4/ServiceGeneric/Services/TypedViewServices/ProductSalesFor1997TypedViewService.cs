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
using Northwind.Data.Dtos.TypedViewDtos;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceInterfaces.TypedViewServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services.TypedViewServices
{
    #region Service
    /// <summary>Service class for the typed view 'ProductSalesFor1997'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END            
    public partial class ProductSalesFor1997TypedViewService : TypedViewServiceBase<ProductSalesFor1997, IProductSalesFor1997TypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetProductSalesFor1997MetaRequest(ProductSalesFor1997MetaRequest request);
        partial void OnAfterGetProductSalesFor1997MetaRequest(ProductSalesFor1997MetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostProductSalesFor1997DataTableRequest(ProductSalesFor1997DataTableRequest request);
        partial void OnAfterPostProductSalesFor1997DataTableRequest(ProductSalesFor1997DataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetProductSalesFor1997QueryCollectionRequest(ProductSalesFor1997QueryCollectionRequest request);
        partial void OnAfterGetProductSalesFor1997QueryCollectionRequest(ProductSalesFor1997QueryCollectionRequest request, ProductSalesFor1997CollectionResponse response);
        #endregion
    
        public ProductSalesFor1997TypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'ProductSalesFor1997' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(ProductSalesFor1997MetaRequest request)
        {
            OnBeforeGetProductSalesFor1997MetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetProductSalesFor1997MetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'ProductSalesFor1997' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(ProductSalesFor1997DataTableRequest request)
        {
            OnBeforePostProductSalesFor1997DataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostProductSalesFor1997DataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'ProductSalesFor1997' typed view records using sorting, filtering, paging and more.</summary>
        public ProductSalesFor1997CollectionResponse Get(ProductSalesFor1997QueryCollectionRequest request)
        {
            OnBeforeGetProductSalesFor1997QueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetProductSalesFor1997QueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/productsalesfor1997/meta", Verbs = "GET")]
    public partial class ProductSalesFor1997MetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/productsalesfor1997/datatable", Verbs = "POST")] // general query
    public partial class ProductSalesFor1997DataTableRequest : GetTypedViewCollectionRequest<ProductSalesFor1997, ProductSalesFor1997CollectionResponse>
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

    [Route("/views/productsalesfor1997", Verbs = "GET")] // general query
    [DefaultView("ProductSalesFor1997TypedView")]
    public partial class ProductSalesFor1997QueryCollectionRequest : GetTypedViewCollectionRequest<ProductSalesFor1997, ProductSalesFor1997CollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class ProductSalesFor1997CollectionResponse : GetTypedViewCollectionResponse<ProductSalesFor1997>
    {
        public ProductSalesFor1997CollectionResponse(): base(){}
        public ProductSalesFor1997CollectionResponse(IEnumerable<ProductSalesFor1997> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }
    #endregion
}
