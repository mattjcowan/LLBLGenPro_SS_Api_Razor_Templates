using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface IShipperServiceRepository: IEntityServiceRepository<Shipper>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(ShipperDataTableRequest request);

        ShipperCollectionResponse Fetch(ShipperQueryCollectionRequest request);
        ShipperResponse Fetch(ShipperPkRequest request);

        ShipperResponse Fetch(ShipperUcShipperNameRequest request);

        ShipperResponse Create(ShipperAddRequest request);
        ShipperResponse Update(ShipperUpdateRequest request);
        bool Delete(ShipperDeleteRequest request);
    } 
}
