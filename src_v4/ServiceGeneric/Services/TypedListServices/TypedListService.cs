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
using Northwind.Data.Dtos.TypedListDtos;
using Northwind.Data.ServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services.TypedListServices
{
    #region TypedViewService
    public partial class TypedListService : TypedListServiceBase
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        public TypedListCollectionResponse Get(TypedListsMetaRequest request)
        {
            return GetTypedListsResponse();
        }

        public TypedListCollectionResponse Get(TypedListsRequest request)
        {
            return GetTypedListsResponse();
        }

        private TypedListCollectionResponse GetTypedListsResponse()
        {
            const string cacheKey = "meta-typedlists";
            Func<TypedListCollectionResponse> funcMethod = GetTypedListsResponseInternal;
            var response = base.Cache.Get<TypedListCollectionResponse>(cacheKey);
            if (response == null)
            {
                response = funcMethod();
                base.Cache.Set(cacheKey, response, TimeSpan.FromMinutes(2));
            }
            return response;
        }
        
        private TypedListCollectionResponse GetTypedListsResponseInternal()
        {
            var baseUri = base.BaseServiceUri;
      
            var items = new List<TypedList>();
            items.Add(new TypedList{ Name="EmployeesByRegionAndTerritory", MetaLink = GenerateTypedListLink(baseUri, "EmployeesByRegionAndTerritory", "employeesbyregionandterritory") });

            return new TypedListCollectionResponse(items, 1, items.Count, items.Count);
        }

        private static Link GenerateTypedListLink(string baseUri, string typeListName, string typeListId)
        {
            var uri = string.Concat(baseUri, "/", typeListId);
            return new Link
                {
                    Href = uri,
                    Id = typeListId,
                    Rel = "self",
                    Type = typeListName,
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
    [Route("/lists/meta")] // unique constraint filter
    public partial class TypedListsMetaRequest : IReturn<TypedListCollectionResponse>
    {
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedListsMetaRequestAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                         

    }

    [Route("/lists")]
    [DefaultView("TypedLists")]
    public partial class TypedListsRequest : IReturn<TypedListCollectionResponse>
    {
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedListsRequestAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                         

    }
    #endregion

    #region Responses
    public partial class TypedListCollectionResponse : GetTypedListCollectionResponse<TypedList>
    {
        public TypedListCollectionResponse() : base() { }
        public TypedListCollectionResponse(IEnumerable<TypedList> collection, int pageNumber, int pageSize, int totalItemCount) :
            base(collection, pageNumber, pageSize, totalItemCount) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcTypedListCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                         

    }
    #endregion
}
