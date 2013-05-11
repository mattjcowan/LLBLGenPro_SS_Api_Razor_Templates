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
    /// <summary>Service class for the typed view 'CurrentProductList'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                             
    public partial class CurrentProductListTypedViewService : TypedViewServiceBase<CurrentProductList, ICurrentProductListTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetCurrentProductListMetaRequest(CurrentProductListMetaRequest request);
        partial void OnAfterGetCurrentProductListMetaRequest(CurrentProductListMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostCurrentProductListDataTableRequest(CurrentProductListDataTableRequest request);
        partial void OnAfterPostCurrentProductListDataTableRequest(CurrentProductListDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetCurrentProductListQueryCollectionRequest(CurrentProductListQueryCollectionRequest request);
        partial void OnAfterGetCurrentProductListQueryCollectionRequest(CurrentProductListQueryCollectionRequest request, CurrentProductListCollectionResponse response);
        #endregion
    
        public CurrentProductListTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'CurrentProductList' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(CurrentProductListMetaRequest request)
        {
            OnBeforeGetCurrentProductListMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetCurrentProductListMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'CurrentProductList' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(CurrentProductListDataTableRequest request)
        {
            OnBeforePostCurrentProductListDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostCurrentProductListDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'CurrentProductList' typed view records using sorting, filtering, paging and more.</summary>
        public CurrentProductListCollectionResponse Get(CurrentProductListQueryCollectionRequest request)
        {
            OnBeforeGetCurrentProductListQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCurrentProductListQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/currentproductlist/meta", Verbs = "GET")]
    public partial class CurrentProductListMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/currentproductlist/datatable", Verbs = "POST")] // general query
    public partial class CurrentProductListDataTableRequest : GetTypedViewCollectionRequest<CurrentProductList, CurrentProductListCollectionResponse>
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

    [Route("/views/currentproductlist", Verbs = "GET")] // general query
    [DefaultView("CurrentProductListTypedView")]
    public partial class CurrentProductListQueryCollectionRequest : GetTypedViewCollectionRequest<CurrentProductList, CurrentProductListCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class CurrentProductListCollectionResponse : GetTypedViewCollectionResponse<CurrentProductList>
    {
        public CurrentProductListCollectionResponse(): base(){}
        public CurrentProductListCollectionResponse(IEnumerable<CurrentProductList> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                         
    }
    #endregion
}
