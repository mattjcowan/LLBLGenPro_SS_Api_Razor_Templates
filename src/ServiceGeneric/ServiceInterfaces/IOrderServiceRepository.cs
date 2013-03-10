using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface IOrderServiceRepository: IEntityServiceRepository<Order>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(OrderDataTableRequest request);

        OrderCollectionResponse Fetch(OrderQueryCollectionRequest request);
        OrderResponse Fetch(OrderPkRequest request);


        OrderResponse Create(OrderAddRequest request);
        OrderResponse Update(OrderUpdateRequest request);
        bool Delete(OrderDeleteRequest request);
    } 
}
