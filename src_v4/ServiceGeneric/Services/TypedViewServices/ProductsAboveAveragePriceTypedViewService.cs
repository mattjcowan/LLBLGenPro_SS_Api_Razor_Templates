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
    /// <summary>Service class for the typed view 'ProductsAboveAveragePrice'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                   
    public partial class ProductsAboveAveragePriceTypedViewService : TypedViewServiceBase<ProductsAboveAveragePrice, IProductsAboveAveragePriceTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetProductsAboveAveragePriceMetaRequest(ProductsAboveAveragePriceMetaRequest request);
        partial void OnAfterGetProductsAboveAveragePriceMetaRequest(ProductsAboveAveragePriceMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostProductsAboveAveragePriceDataTableRequest(ProductsAboveAveragePriceDataTableRequest request);
        partial void OnAfterPostProductsAboveAveragePriceDataTableRequest(ProductsAboveAveragePriceDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetProductsAboveAveragePriceQueryCollectionRequest(ProductsAboveAveragePriceQueryCollectionRequest request);
        partial void OnAfterGetProductsAboveAveragePriceQueryCollectionRequest(ProductsAboveAveragePriceQueryCollectionRequest request, ProductsAboveAveragePriceCollectionResponse response);
        #endregion
    
        public ProductsAboveAveragePriceTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'ProductsAboveAveragePrice' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(ProductsAboveAveragePriceMetaRequest request)
        {
            OnBeforeGetProductsAboveAveragePriceMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetProductsAboveAveragePriceMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'ProductsAboveAveragePrice' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(ProductsAboveAveragePriceDataTableRequest request)
        {
            OnBeforePostProductsAboveAveragePriceDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostProductsAboveAveragePriceDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'ProductsAboveAveragePrice' typed view records using sorting, filtering, paging and more.</summary>
        public ProductsAboveAveragePriceCollectionResponse Get(ProductsAboveAveragePriceQueryCollectionRequest request)
        {
            OnBeforeGetProductsAboveAveragePriceQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetProductsAboveAveragePriceQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/productsaboveaverageprice/meta", Verbs = "GET")]
    public partial class ProductsAboveAveragePriceMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/productsaboveaverageprice/datatable", Verbs = "POST")] // general query
    public partial class ProductsAboveAveragePriceDataTableRequest : GetTypedViewCollectionRequest<ProductsAboveAveragePrice, ProductsAboveAveragePriceCollectionResponse>
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

    [Route("/views/productsaboveaverageprice", Verbs = "GET")] // general query
    [DefaultView("ProductsAboveAveragePriceTypedView")]
    public partial class ProductsAboveAveragePriceQueryCollectionRequest : GetTypedViewCollectionRequest<ProductsAboveAveragePrice, ProductsAboveAveragePriceCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class ProductsAboveAveragePriceCollectionResponse : GetTypedViewCollectionResponse<ProductsAboveAveragePrice>
    {
        public ProductsAboveAveragePriceCollectionResponse(): base(){}
        public ProductsAboveAveragePriceCollectionResponse(IEnumerable<ProductsAboveAveragePrice> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                     
    }
    #endregion
}
