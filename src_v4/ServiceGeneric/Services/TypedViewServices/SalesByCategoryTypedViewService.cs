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
    /// <summary>Service class for the typed view 'SalesByCategory'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END 
 
    public partial class SalesByCategoryTypedViewService : TypedViewServiceBase<SalesByCategory, ISalesByCategoryTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetSalesByCategoryMetaRequest(SalesByCategoryMetaRequest request);
        partial void OnAfterGetSalesByCategoryMetaRequest(SalesByCategoryMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostSalesByCategoryDataTableRequest(SalesByCategoryDataTableRequest request);
        partial void OnAfterPostSalesByCategoryDataTableRequest(SalesByCategoryDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetSalesByCategoryQueryCollectionRequest(SalesByCategoryQueryCollectionRequest request);
        partial void OnAfterGetSalesByCategoryQueryCollectionRequest(SalesByCategoryQueryCollectionRequest request, SalesByCategoryCollectionResponse response);
        #endregion
    
        public SalesByCategoryTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'SalesByCategory' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(SalesByCategoryMetaRequest request)
        {
            OnBeforeGetSalesByCategoryMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetSalesByCategoryMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'SalesByCategory' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(SalesByCategoryDataTableRequest request)
        {
            OnBeforePostSalesByCategoryDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostSalesByCategoryDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'SalesByCategory' typed view records using sorting, filtering, paging and more.</summary>
        public SalesByCategoryCollectionResponse Get(SalesByCategoryQueryCollectionRequest request)
        {
            OnBeforeGetSalesByCategoryQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetSalesByCategoryQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 


    }
    #endregion

    #region Requests
    [Route("/views/salesbycategory/meta", Verbs = "GET")]
    public partial class SalesByCategoryMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/salesbycategory/datatable", Verbs = "POST")] // general query
    public partial class SalesByCategoryDataTableRequest : GetTypedViewCollectionRequest<SalesByCategory, SalesByCategoryCollectionResponse>
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

    }

    [Route("/views/salesbycategory", Verbs = "GET")] // general query
    [DefaultView("SalesByCategoryTypedView")]
    public partial class SalesByCategoryQueryCollectionRequest : GetTypedViewCollectionRequest<SalesByCategory, SalesByCategoryCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class SalesByCategoryCollectionResponse : GetTypedViewCollectionResponse<SalesByCategory>
    {
        public SalesByCategoryCollectionResponse(): base(){}
        public SalesByCategoryCollectionResponse(IEnumerable<SalesByCategory> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 
  
    }
    #endregion
}
