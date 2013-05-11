using Northwind.Data.Dtos.TypedListDtos;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcServiceRepositoryAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces.TypedListServiceInterfaces
{
    public interface ITypedListServiceRepository<TDto>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcServiceRepositoryInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
        where TDto : CommonTypedListDtoBase
    {
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcServiceRepositoryMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
}
