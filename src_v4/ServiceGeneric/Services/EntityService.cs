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
using Northwind.Data.ServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services
{
    #region EntityService
    public partial class EntityService : ServiceBase
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        public EntityCollectionResponse Get(EntitiesMetaRequest request)
        {
            return GetEntitiesResponse();
        }

        public EntityCollectionResponse Get(EntitiesRequest request)
        {
            return GetEntitiesResponse();
        }

        private EntityCollectionResponse GetEntitiesResponse()
        {
            const string cacheKey = "meta-entities";
            Func<EntityCollectionResponse> funcMethod = GetEntitiesResponseInternal;
            var response = base.Cache.Get<EntityCollectionResponse>(cacheKey);
            if (response == null)
            {
                response = funcMethod();
                base.Cache.Set(cacheKey, response, TimeSpan.FromMinutes(2));
            }
            return response;
        }
        
        private EntityCollectionResponse GetEntitiesResponseInternal()
        {
            var baseUri = base.BaseServiceUri;
      
            var entities = new List<Entity>();
            entities.Add(new Entity{ Name="Category", MetaLink = GenerateEntityLink(baseUri, "Category", "categories") });
            entities.Add(new Entity{ Name="Customer", MetaLink = GenerateEntityLink(baseUri, "Customer", "customers") });
            entities.Add(new Entity{ Name="CustomerCustomerDemo", MetaLink = GenerateEntityLink(baseUri, "CustomerCustomerDemo", "customercustomerdemos") });
            entities.Add(new Entity{ Name="CustomerDemographic", MetaLink = GenerateEntityLink(baseUri, "CustomerDemographic", "customerdemographics") });
            entities.Add(new Entity{ Name="Employee", MetaLink = GenerateEntityLink(baseUri, "Employee", "employees") });
            entities.Add(new Entity{ Name="EmployeeTerritory", MetaLink = GenerateEntityLink(baseUri, "EmployeeTerritory", "employeeterritories") });
            entities.Add(new Entity{ Name="Order", MetaLink = GenerateEntityLink(baseUri, "Order", "orders") });
            entities.Add(new Entity{ Name="OrderDetail", MetaLink = GenerateEntityLink(baseUri, "OrderDetail", "orderdetails") });
            entities.Add(new Entity{ Name="Product", MetaLink = GenerateEntityLink(baseUri, "Product", "products") });
            entities.Add(new Entity{ Name="Region", MetaLink = GenerateEntityLink(baseUri, "Region", "regions") });
            entities.Add(new Entity{ Name="Shipper", MetaLink = GenerateEntityLink(baseUri, "Shipper", "shippers") });
            entities.Add(new Entity{ Name="Supplier", MetaLink = GenerateEntityLink(baseUri, "Supplier", "suppliers") });
            entities.Add(new Entity{ Name="Territory", MetaLink = GenerateEntityLink(baseUri, "Territory", "territories") });

            return new EntityCollectionResponse(entities, 1, entities.Count, entities.Count);
        }

        private static Link GenerateEntityLink(string baseUri, string entityName, string entityId)
        {
            var entityUri = string.Concat(baseUri, "/", entityId);
            return new Link
                {
                    Href = entityUri,
                    Id = entityId,
                    Rel = "self",
                    Type = entityName,
                    Properties = new Dictionary<string, string>
                        {
                            {"MetaUri", string.Concat(entityUri, "/meta")},
                            {"XmlUri", string.Concat(entityUri, "?format=xml")},
                            {"JsonUri", string.Concat(entityUri, "?format=json")},
                        }
                };
        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                                                                                                                                                                                 

    }
    #endregion

    #region Requests
    [Route("/entities/meta")] // unique constraint filter
    public partial class EntitiesMetaRequest : IReturn<EntityCollectionResponse>
    {
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcEntitiesMetaRequestAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                             

    }

    [Route("/entities")]
    [DefaultView("Entities")]
    public partial class EntitiesRequest : IReturn<EntityCollectionResponse>
    {
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcEntitiesRequestAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                             

    }
    #endregion

    #region Responses
    public partial class EntityResponse : GetResponse<Entity>
    {
        public EntityResponse() : base() { }
        public EntityResponse(Entity entity) : base(entity) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcEntityResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                             

    }

    public partial class EntityCollectionResponse : GetCollectionResponse<Entity>
    {
        public EntityCollectionResponse() : base() { }
        public EntityCollectionResponse(IEnumerable<Entity> collection, int pageNumber, int pageSize, int totalItemCount) :
            base(collection, pageNumber, pageSize, totalItemCount) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcEntityCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                             

    }
    #endregion
}
