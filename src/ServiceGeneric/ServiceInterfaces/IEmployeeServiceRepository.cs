using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface IEmployeeServiceRepository: IEntityServiceRepository<Employee>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(EmployeeDataTableRequest request);

        EmployeeCollectionResponse Fetch(EmployeeQueryCollectionRequest request);
        EmployeeResponse Fetch(EmployeePkRequest request);


        EmployeeResponse Create(EmployeeAddRequest request);
        EmployeeResponse Update(EmployeeUpdateRequest request);
        bool Delete(EmployeeDeleteRequest request);
    } 
}
