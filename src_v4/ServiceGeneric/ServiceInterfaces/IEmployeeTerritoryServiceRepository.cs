using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface IEmployeeTerritoryServiceRepository: IEntityServiceRepository<EmployeeTerritory>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(EmployeeTerritoryDataTableRequest request);

        EmployeeTerritoryCollectionResponse Fetch(EmployeeTerritoryQueryCollectionRequest request);
        EmployeeTerritoryResponse Fetch(EmployeeTerritoryPkRequest request);


        EmployeeTerritoryResponse Create(EmployeeTerritoryAddRequest request);
        EmployeeTerritoryResponse Update(EmployeeTerritoryUpdateRequest request);
        SimpleResponse<bool> Delete(EmployeeTerritoryDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
