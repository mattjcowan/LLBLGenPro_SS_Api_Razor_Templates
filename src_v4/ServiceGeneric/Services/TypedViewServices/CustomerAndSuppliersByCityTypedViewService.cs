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
    /// <summary>Service class for the typed view 'CustomerAndSuppliersByCity'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                   
    public partial class CustomerAndSuppliersByCityTypedViewService : TypedViewServiceBase<CustomerAndSuppliersByCity, ICustomerAndSuppliersByCityTypedViewServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetCustomerAndSuppliersByCityMetaRequest(CustomerAndSuppliersByCityMetaRequest request);
        partial void OnAfterGetCustomerAndSuppliersByCityMetaRequest(CustomerAndSuppliersByCityMetaRequest request, TypedViewMetaDetailsResponse response);
        partial void OnBeforePostCustomerAndSuppliersByCityDataTableRequest(CustomerAndSuppliersByCityDataTableRequest request);
        partial void OnAfterPostCustomerAndSuppliersByCityDataTableRequest(CustomerAndSuppliersByCityDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetCustomerAndSuppliersByCityQueryCollectionRequest(CustomerAndSuppliersByCityQueryCollectionRequest request);
        partial void OnAfterGetCustomerAndSuppliersByCityQueryCollectionRequest(CustomerAndSuppliersByCityQueryCollectionRequest request, CustomerAndSuppliersByCityCollectionResponse response);
        #endregion
    
        public CustomerAndSuppliersByCityTypedViewService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the typed view 'CustomerAndSuppliersByCity' including field metadata.</summary>
        public TypedViewMetaDetailsResponse Get(CustomerAndSuppliersByCityMetaRequest request)
        {
            OnBeforeGetCustomerAndSuppliersByCityMetaRequest(request);
            var output = Repository.GetTypedViewMetaDetails(this);
            OnAfterGetCustomerAndSuppliersByCityMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'CustomerAndSuppliersByCity' typed view records matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(CustomerAndSuppliersByCityDataTableRequest request)
        {
            OnBeforePostCustomerAndSuppliersByCityDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostCustomerAndSuppliersByCityDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'CustomerAndSuppliersByCity' typed view records using sorting, filtering, paging and more.</summary>
        public CustomerAndSuppliersByCityCollectionResponse Get(CustomerAndSuppliersByCityQueryCollectionRequest request)
        {
            OnBeforeGetCustomerAndSuppliersByCityQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCustomerAndSuppliersByCityQueryCollectionRequest(request, output);
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedViewSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/views/customerandsuppliersbycity/meta", Verbs = "GET")]
    public partial class CustomerAndSuppliersByCityMetaRequest : IReturn<TypedViewMetaDetailsResponse>
    {
    }

    [Route("/views/customerandsuppliersbycity/datatable", Verbs = "POST")] // general query
    public partial class CustomerAndSuppliersByCityDataTableRequest : GetTypedViewCollectionRequest<CustomerAndSuppliersByCity, CustomerAndSuppliersByCityCollectionResponse>
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

    [Route("/views/customerandsuppliersbycity", Verbs = "GET")] // general query
    [DefaultView("CustomerAndSuppliersByCityTypedView")]
    public partial class CustomerAndSuppliersByCityQueryCollectionRequest : GetTypedViewCollectionRequest<CustomerAndSuppliersByCity, CustomerAndSuppliersByCityCollectionResponse>
    {
    }
    #endregion

    #region Responses
    public partial class CustomerAndSuppliersByCityCollectionResponse : GetTypedViewCollectionResponse<CustomerAndSuppliersByCity>
    {
        public CustomerAndSuppliersByCityCollectionResponse(): base(){}
        public CustomerAndSuppliersByCityCollectionResponse(IEnumerable<CustomerAndSuppliersByCity> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                     
    }
    #endregion
}
