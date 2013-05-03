using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface ICustomerDemographicServiceRepository: IEntityServiceRepository<CustomerDemographic>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CustomerDemographicDataTableRequest request);

        CustomerDemographicCollectionResponse Fetch(CustomerDemographicQueryCollectionRequest request);
        CustomerDemographicResponse Fetch(CustomerDemographicPkRequest request);


        CustomerDemographicResponse Create(CustomerDemographicAddRequest request);
        CustomerDemographicResponse Update(CustomerDemographicUpdateRequest request);
        SimpleResponse<bool> Delete(CustomerDemographicDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
