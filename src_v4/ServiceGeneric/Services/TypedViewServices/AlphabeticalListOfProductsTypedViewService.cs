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
    /// <summary>Service class for the typed view 'AlphabeticalListOfProducts'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END            
    public partial class AlphabeticalListOfProductsTypedViewService : TypedViewServiceBase<AlphabeticalListOfProducts, IAlphabeticalListOfProductsTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetAlphabeticalListOfProductsMetaRequest(AlphabeticalListOfProductsMetaRequest request);
        partial void OnAfterGetAlphabeticalListOfProductsMetaRequest(AlphabeticalListOfProductsMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostAlphabeticalListOfProductsDataTableRequest(AlphabeticalListOfProductsDataTableRequest request);
        partial void OnAfterPostAlphabeticalListOfProductsDataTableRequest(AlphabeticalListOfProductsDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetAlphabeticalListOfProductsQueryCollectionRequest(AlphabeticalListOfProductsQueryCollectionRequest request);
        partial void OnAfterGetAlphabeticalListOfProductsQueryCollectionRequest(AlphabeticalListOfProductsQueryCollectionRequest request, AlphabeticalListOfProductsCollectionResponse response);
        #endregion
    
        public AlphabeticalListOfProductsTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'AlphabeticalListOfProducts' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(AlphabeticalListOfProductsMetaRequest request)
        {
            OnBeforeGetAlphabeticalListOfProductsMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetAlphabeticalListOfProductsMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'AlphabeticalListOfProducts' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(AlphabeticalListOfProductsDataTableRequest request)
        {
            OnBeforePostAlphabeticalListOfProductsDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostAlphabeticalListOfProductsDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'AlphabeticalListOfProducts' typed view records using sorting, filtering, paging and more.</summary>
        public AlphabeticalListOfProductsCollectionResponse Get(AlphabeticalListOfProductsQueryCollectionRequest request)
        {
            OnBeforeGetAlphabeticalListOfProductsQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetAlphabeticalListOfProductsQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/alphabeticallistofproducts/meta", Verbs = "GET")]
    public partial class AlphabeticalListOfProductsMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/alphabeticallistofproducts/datatable", Verbs = "POST")] // general query
    public partial class AlphabeticalListOfProductsDataTableRequest : GetTypedViewCollectionRequest<AlphabeticalListOfProducts, AlphabeticalListOfProductsCollectionResponse>
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
        public int iSortCol_10 { get; set; }
        public string sSortDir_10 { get; set; }
        public string bSortable_10 { get; set; } 
        public string mDataProp_10 { get; set; } 
        public string bRegex_10 { get; set; }
        public string bSearchable_10 { get; set; }

    }

    [Route("/views/alphabeticallistofproducts", Verbs = "GET")] // general query
    [DefaultView("AlphabeticalListOfProductsTypedView")]
    public partial class AlphabeticalListOfProductsQueryCollectionRequest : GetTypedViewCollectionRequest<AlphabeticalListOfProducts, AlphabeticalListOfProductsCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class AlphabeticalListOfProductsCollectionResponse : GetTypedViewCollectionResponse<AlphabeticalListOfProducts>
    {
        public AlphabeticalListOfProductsCollectionResponse(): base(){}
        public AlphabeticalListOfProductsCollectionResponse(IEnumerable<AlphabeticalListOfProducts> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }
    #endregion
}
