using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface IOrderDetailServiceRepository: IEntityServiceRepository<OrderDetail>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(OrderDetailDataTableRequest request);

        OrderDetailCollectionResponse Fetch(OrderDetailQueryCollectionRequest request);
        OrderDetailResponse Fetch(OrderDetailPkRequest request);


        OrderDetailResponse Create(OrderDetailAddRequest request);
        OrderDetailResponse Update(OrderDetailUpdateRequest request);
        bool Delete(OrderDetailDeleteRequest request);
    } 
}
