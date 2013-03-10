using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface IEmployeeTerritoryServiceRepository: IEntityServiceRepository<EmployeeTerritory>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(EmployeeTerritoryDataTableRequest request);

        EmployeeTerritoryCollectionResponse Fetch(EmployeeTerritoryQueryCollectionRequest request);
        EmployeeTerritoryResponse Fetch(EmployeeTerritoryPkRequest request);


        EmployeeTerritoryResponse Create(EmployeeTerritoryAddRequest request);
        EmployeeTerritoryResponse Update(EmployeeTerritoryUpdateRequest request);
        bool Delete(EmployeeTerritoryDeleteRequest request);
    } 
}
