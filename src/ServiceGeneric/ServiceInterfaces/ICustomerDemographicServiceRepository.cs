using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface ICustomerDemographicServiceRepository: IEntityServiceRepository<CustomerDemographic>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CustomerDemographicDataTableRequest request);

        CustomerDemographicCollectionResponse Fetch(CustomerDemographicQueryCollectionRequest request);
        CustomerDemographicResponse Fetch(CustomerDemographicPkRequest request);


        CustomerDemographicResponse Create(CustomerDemographicAddRequest request);
        CustomerDemographicResponse Update(CustomerDemographicUpdateRequest request);
        bool Delete(CustomerDemographicDeleteRequest request);
    } 
}
