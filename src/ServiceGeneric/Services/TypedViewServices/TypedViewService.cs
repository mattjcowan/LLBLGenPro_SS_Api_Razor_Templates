using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.Dtos.TypedViewDtos;
using Northwind.Data.ServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services.TypedViewServices
{
    #region TypedViewService
    public partial class TypedViewService : TypedViewServiceBase
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        public TypedViewCollectionResponse Get(TypedViewsMetaRequest request)
        {
            return GetTypedViewsResponse();
        }

        public TypedViewCollectionResponse Get(TypedViewsRequest request)
        {
            return GetTypedViewsResponse();
        }

        private TypedViewCollectionResponse GetTypedViewsResponse()
        {
            const string cacheKey = "meta-typedviews";
            Func<TypedViewCollectionResponse> funcMethod = GetTypedViewsResponseInternal;
            var response = base.Cache.Get<TypedViewCollectionResponse>(cacheKey);
            if (response == null)
            {
                response = funcMethod();
                base.Cache.Set(cacheKey, response, TimeSpan.FromMinutes(2));
            }
            return response;
        }
        
        private TypedViewCollectionResponse GetTypedViewsResponseInternal()
        {
            var baseUri = base.BaseServiceUri;
      
            var items = new List<TypedView>();
            items.Add(new TypedView{ Name="AlphabeticalListOfProducts", MetaLink = GenerateTypedViewLink(baseUri, "AlphabeticalListOfProducts", "alphabeticallistofproducts") });
            items.Add(new TypedView{ Name="CategorySalesFor1997", MetaLink = GenerateTypedViewLink(baseUri, "CategorySalesFor1997", "categorysalesfor1997") });
            items.Add(new TypedView{ Name="CurrentProductList", MetaLink = GenerateTypedViewLink(baseUri, "CurrentProductList", "currentproductlist") });
            items.Add(new TypedView{ Name="CustomerAndSuppliersByCity", MetaLink = GenerateTypedViewLink(baseUri, "CustomerAndSuppliersByCity", "customerandsuppliersbycity") });
            items.Add(new TypedView{ Name="Invoices", MetaLink = GenerateTypedViewLink(baseUri, "Invoices", "invoices") });
            items.Add(new TypedView{ Name="OrderDetailsExtended", MetaLink = GenerateTypedViewLink(baseUri, "OrderDetailsExtended", "orderdetailsextended") });
            items.Add(new TypedView{ Name="OrdersQry", MetaLink = GenerateTypedViewLink(baseUri, "OrdersQry", "ordersqry") });
            items.Add(new TypedView{ Name="OrderSubtotal", MetaLink = GenerateTypedViewLink(baseUri, "OrderSubtotal", "ordersubtotal") });
            items.Add(new TypedView{ Name="ProductsAboveAveragePrice", MetaLink = GenerateTypedViewLink(baseUri, "ProductsAboveAveragePrice", "productsaboveaverageprice") });
            items.Add(new TypedView{ Name="ProductSalesFor1997", MetaLink = GenerateTypedViewLink(baseUri, "ProductSalesFor1997", "productsalesfor1997") });
            items.Add(new TypedView{ Name="ProductsByCategory", MetaLink = GenerateTypedViewLink(baseUri, "ProductsByCategory", "productsbycategory") });
            items.Add(new TypedView{ Name="QuarterlyOrder", MetaLink = GenerateTypedViewLink(baseUri, "QuarterlyOrder", "quarterlyorder") });
            items.Add(new TypedView{ Name="SalesByCategory", MetaLink = GenerateTypedViewLink(baseUri, "SalesByCategory", "salesbycategory") });
            items.Add(new TypedView{ Name="SalesTotalsByAmount", MetaLink = GenerateTypedViewLink(baseUri, "SalesTotalsByAmount", "salestotalsbyamount") });
            items.Add(new TypedView{ Name="SummaryOfSalesByQuarter", MetaLink = GenerateTypedViewLink(baseUri, "SummaryOfSalesByQuarter", "summaryofsalesbyquarter") });
            items.Add(new TypedView{ Name="SummaryOfSalesByYear", MetaLink = GenerateTypedViewLink(baseUri, "SummaryOfSalesByYear", "summaryofsalesbyyear") });

            return new TypedViewCollectionResponse(items, 1, items.Count, items.Count);
        }

        private static Link GenerateTypedViewLink(string baseUri, string typeViewName, string typeViewId)
        {
            var uri = string.Concat(baseUri, "/", typeViewId);
            return new Link
                {
                    Href = uri,
                    Id = typeViewId,
                    Rel = "self",
                    Type = typeViewName,
                    Properties = new Dictionary<string, string>
                        {
                            {"MetaUri", string.Concat(uri, "/meta")},
                            {"XmlUri", string.Concat(uri, "?format=xml")},
                            {"JsonUri", string.Concat(uri, "?format=json")},
                        }
                };
        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                                                 

    }
    #endregion

    #region Requests
    [Route("/views/meta")] // unique constraint filter
    public partial class TypedViewsMetaRequest : IReturn<TypedViewCollectionResponse>
    {
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewsMetaRequestAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                 

    }

    [Route("/views")]
    [DefaultView("TypedViews")]
    public partial class TypedViewsRequest : IReturn<TypedViewCollectionResponse>
    {
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewsRequestAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                 

    }
    #endregion

    #region Responses
    public partial class TypedViewCollectionResponse : GetTypedViewCollectionResponse<TypedView>
    {
        public TypedViewCollectionResponse() : base() { }
        public TypedViewCollectionResponse(IEnumerable<TypedView> collection, int pageNumber, int pageSize, int totalItemCount) :
            base(collection, pageNumber, pageSize, totalItemCount) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedViewCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                 

    }
    #endregion
}
