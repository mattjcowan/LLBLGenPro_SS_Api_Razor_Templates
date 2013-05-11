using Northwind.Data.Dtos.TypedViewDtos;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcServiceRepositoryAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces.TypedViewServiceInterfaces
{
    public interface ITypedViewServiceRepository<TDto>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcServiceRepositoryInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
        where TDto : CommonTypedViewDtoBase
    {
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcServiceRepositoryMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
}
