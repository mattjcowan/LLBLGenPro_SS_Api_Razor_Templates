using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface IOrderServiceRepository: IEntityServiceRepository<Order>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(OrderDataTableRequest request);

        OrderCollectionResponse Fetch(OrderQueryCollectionRequest request);
        OrderResponse Fetch(OrderPkRequest request);


        OrderResponse Create(OrderAddRequest request);
        OrderResponse Update(OrderUpdateRequest request);
        SimpleResponse<bool> Delete(OrderDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
