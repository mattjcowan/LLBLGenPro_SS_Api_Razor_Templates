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
    /// <summary>Service class for the typed view 'ProductsByCategory'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END 
 
    public partial class ProductsByCategoryTypedViewService : TypedViewServiceBase<ProductsByCategory, IProductsByCategoryTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetProductsByCategoryMetaRequest(ProductsByCategoryMetaRequest request);
        partial void OnAfterGetProductsByCategoryMetaRequest(ProductsByCategoryMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostProductsByCategoryDataTableRequest(ProductsByCategoryDataTableRequest request);
        partial void OnAfterPostProductsByCategoryDataTableRequest(ProductsByCategoryDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetProductsByCategoryQueryCollectionRequest(ProductsByCategoryQueryCollectionRequest request);
        partial void OnAfterGetProductsByCategoryQueryCollectionRequest(ProductsByCategoryQueryCollectionRequest request, ProductsByCategoryCollectionResponse response);
        #endregion
    
        public ProductsByCategoryTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'ProductsByCategory' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(ProductsByCategoryMetaRequest request)
        {
            OnBeforeGetProductsByCategoryMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetProductsByCategoryMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'ProductsByCategory' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(ProductsByCategoryDataTableRequest request)
        {
            OnBeforePostProductsByCategoryDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostProductsByCategoryDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'ProductsByCategory' typed view records using sorting, filtering, paging and more.</summary>
        public ProductsByCategoryCollectionResponse Get(ProductsByCategoryQueryCollectionRequest request)
        {
            OnBeforeGetProductsByCategoryQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetProductsByCategoryQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 


    }
    #endregion

    #region Requests
    [Route("/views/productsbycategory/meta", Verbs = "GET")]
    public partial class ProductsByCategoryMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/productsbycategory/datatable", Verbs = "POST")] // general query
    public partial class ProductsByCategoryDataTableRequest : GetTypedViewCollectionRequest<ProductsByCategory, ProductsByCategoryCollectionResponse>
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

    }

    [Route("/views/productsbycategory", Verbs = "GET")] // general query
    [DefaultView("ProductsByCategoryTypedView")]
    public partial class ProductsByCategoryQueryCollectionRequest : GetTypedViewCollectionRequest<ProductsByCategory, ProductsByCategoryCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class ProductsByCategoryCollectionResponse : GetTypedViewCollectionResponse<ProductsByCategory>
    {
        public ProductsByCategoryCollectionResponse(): base(){}
        public ProductsByCategoryCollectionResponse(IEnumerable<ProductsByCategory> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 
  
    }
    #endregion
}
