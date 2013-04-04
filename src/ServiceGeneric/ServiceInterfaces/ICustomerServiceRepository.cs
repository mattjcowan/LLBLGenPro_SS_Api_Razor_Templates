using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface ICustomerServiceRepository: IEntityServiceRepository<Customer>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CustomerDataTableRequest request);

        CustomerCollectionResponse Fetch(CustomerQueryCollectionRequest request);
        CustomerResponse Fetch(CustomerPkRequest request);

        CustomerResponse Fetch(CustomerUcCompanyNameRequest request);

        CustomerResponse Create(CustomerAddRequest request);
        CustomerResponse Update(CustomerUpdateRequest request);
        SimpleResponse<bool> Delete(CustomerDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
