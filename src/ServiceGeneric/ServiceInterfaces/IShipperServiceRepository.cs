using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface IShipperServiceRepository: IEntityServiceRepository<Shipper>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(ShipperDataTableRequest request);

        ShipperCollectionResponse Fetch(ShipperQueryCollectionRequest request);
        ShipperResponse Fetch(ShipperPkRequest request);

        ShipperResponse Fetch(ShipperUcShipperNameRequest request);

        ShipperResponse Create(ShipperAddRequest request);
        ShipperResponse Update(ShipperUpdateRequest request);
        SimpleResponse<bool> Delete(ShipperDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
