using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface IRegionServiceRepository: IEntityServiceRepository<Region>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(RegionDataTableRequest request);

        RegionCollectionResponse Fetch(RegionQueryCollectionRequest request);
        RegionResponse Fetch(RegionPkRequest request);

        RegionResponse Fetch(RegionUcRegionDescriptionRequest request);

        RegionResponse Create(RegionAddRequest request);
        RegionResponse Update(RegionUpdateRequest request);
        bool Delete(RegionDeleteRequest request);
    } 
}
