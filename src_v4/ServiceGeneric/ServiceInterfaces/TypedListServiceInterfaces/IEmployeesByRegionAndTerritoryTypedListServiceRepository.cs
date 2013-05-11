using Northwind.Data.Dtos;
using Northwind.Data.Dtos.TypedListDtos;
using Northwind.Data.Services.TypedListServices;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces.TypedListServiceInterfaces
{ 
    public interface IEmployeesByRegionAndTerritoryTypedListServiceRepository: ITypedListServiceRepository<EmployeesByRegionAndTerritory>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        TypedListMetaDetailsResponse GetTypedListMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(EmployeesByRegionAndTerritoryDataTableRequest request);
        EmployeesByRegionAndTerritoryCollectionResponse Fetch(EmployeesByRegionAndTerritoryQueryCollectionRequest request);
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsTypedListSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
