using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface ICustomerCustomerDemoServiceRepository: IEntityServiceRepository<CustomerCustomerDemo>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CustomerCustomerDemoDataTableRequest request);

        CustomerCustomerDemoCollectionResponse Fetch(CustomerCustomerDemoQueryCollectionRequest request);
        CustomerCustomerDemoResponse Fetch(CustomerCustomerDemoPkRequest request);


        CustomerCustomerDemoResponse Create(CustomerCustomerDemoAddRequest request);
        CustomerCustomerDemoResponse Update(CustomerCustomerDemoUpdateRequest request);
        bool Delete(CustomerCustomerDemoDeleteRequest request);
    } 
}
