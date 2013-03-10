using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface ICustomerServiceRepository: IEntityServiceRepository<Customer>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CustomerDataTableRequest request);

        CustomerCollectionResponse Fetch(CustomerQueryCollectionRequest request);
        CustomerResponse Fetch(CustomerPkRequest request);

        CustomerResponse Fetch(CustomerUcCompanyNameRequest request);

        CustomerResponse Create(CustomerAddRequest request);
        CustomerResponse Update(CustomerUpdateRequest request);
        bool Delete(CustomerDeleteRequest request);
    } 
}
