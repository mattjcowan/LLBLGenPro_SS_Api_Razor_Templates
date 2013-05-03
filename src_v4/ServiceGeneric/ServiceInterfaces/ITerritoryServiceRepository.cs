using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface ITerritoryServiceRepository: IEntityServiceRepository<Territory>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(TerritoryDataTableRequest request);

        TerritoryCollectionResponse Fetch(TerritoryQueryCollectionRequest request);
        TerritoryResponse Fetch(TerritoryPkRequest request);


        TerritoryResponse Create(TerritoryAddRequest request);
        TerritoryResponse Update(TerritoryUpdateRequest request);
        SimpleResponse<bool> Delete(TerritoryDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
