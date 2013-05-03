using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface IRegionServiceRepository: IEntityServiceRepository<Region>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(RegionDataTableRequest request);

        RegionCollectionResponse Fetch(RegionQueryCollectionRequest request);
        RegionResponse Fetch(RegionPkRequest request);

        RegionResponse Fetch(RegionUcRegionDescriptionRequest request);

        RegionResponse Create(RegionAddRequest request);
        RegionResponse Update(RegionUpdateRequest request);
        SimpleResponse<bool> Delete(RegionDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
