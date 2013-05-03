using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface ICustomerCustomerDemoServiceRepository: IEntityServiceRepository<CustomerCustomerDemo>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CustomerCustomerDemoDataTableRequest request);

        CustomerCustomerDemoCollectionResponse Fetch(CustomerCustomerDemoQueryCollectionRequest request);
        CustomerCustomerDemoResponse Fetch(CustomerCustomerDemoPkRequest request);


        CustomerCustomerDemoResponse Create(CustomerCustomerDemoAddRequest request);
        CustomerCustomerDemoResponse Update(CustomerCustomerDemoUpdateRequest request);
        SimpleResponse<bool> Delete(CustomerCustomerDemoDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
