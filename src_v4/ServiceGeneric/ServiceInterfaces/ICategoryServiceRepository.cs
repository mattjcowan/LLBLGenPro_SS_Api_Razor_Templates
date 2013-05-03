using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface ICategoryServiceRepository: IEntityServiceRepository<Category>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CategoryDataTableRequest request);

        CategoryCollectionResponse Fetch(CategoryQueryCollectionRequest request);
        CategoryResponse Fetch(CategoryPkRequest request);

        CategoryResponse Fetch(CategoryUcCategoryNameRequest request);

        CategoryResponse Create(CategoryAddRequest request);
        CategoryResponse Update(CategoryUpdateRequest request);
        SimpleResponse<bool> Delete(CategoryDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
