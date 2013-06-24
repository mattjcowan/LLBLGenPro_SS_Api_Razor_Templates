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
    /// <summary>Service class for the typed view 'CategorySalesFor1997'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                                
    public partial class CategorySalesFor1997TypedViewService : TypedViewServiceBase<CategorySalesFor1997, ICategorySalesFor1997TypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetCategorySalesFor1997MetaRequest(CategorySalesFor1997MetaRequest request);
        partial void OnAfterGetCategorySalesFor1997MetaRequest(CategorySalesFor1997MetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostCategorySalesFor1997DataTableRequest(CategorySalesFor1997DataTableRequest request);
        partial void OnAfterPostCategorySalesFor1997DataTableRequest(CategorySalesFor1997DataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetCategorySalesFor1997QueryCollectionRequest(CategorySalesFor1997QueryCollectionRequest request);
        partial void OnAfterGetCategorySalesFor1997QueryCollectionRequest(CategorySalesFor1997QueryCollectionRequest request, CategorySalesFor1997CollectionResponse response);
        #endregion
    
        public CategorySalesFor1997TypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'CategorySalesFor1997' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(CategorySalesFor1997MetaRequest request)
        {
            OnBeforeGetCategorySalesFor1997MetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetCategorySalesFor1997MetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'CategorySalesFor1997' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(CategorySalesFor1997DataTableRequest request)
        {
            OnBeforePostCategorySalesFor1997DataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostCategorySalesFor1997DataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'CategorySalesFor1997' typed view records using sorting, filtering, paging and more.</summary>
        public CategorySalesFor1997CollectionResponse Get(CategorySalesFor1997QueryCollectionRequest request)
        {
            OnBeforeGetCategorySalesFor1997QueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCategorySalesFor1997QueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/categorysalesfor1997/meta", Verbs = "GET")]
    public partial class CategorySalesFor1997MetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/categorysalesfor1997/datatable", Verbs = "POST")] // general query
    public partial class CategorySalesFor1997DataTableRequest : GetTypedViewCollectionRequest<CategorySalesFor1997, CategorySalesFor1997CollectionResponse>
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

    [Route("/views/categorysalesfor1997", Verbs = "GET")] // general query
    [DefaultView("CategorySalesFor1997TypedView")]
    public partial class CategorySalesFor1997QueryCollectionRequest : GetTypedViewCollectionRequest<CategorySalesFor1997, CategorySalesFor1997CollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class CategorySalesFor1997CollectionResponse : GetTypedViewCollectionResponse<CategorySalesFor1997>
    {
        public CategorySalesFor1997CollectionResponse(): base(){}
        public CategorySalesFor1997CollectionResponse(IEnumerable<CategorySalesFor1997> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                               
    }
    #endregion
}
