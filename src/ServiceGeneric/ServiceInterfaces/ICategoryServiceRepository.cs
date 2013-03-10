using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface ICategoryServiceRepository: IEntityServiceRepository<Category>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(CategoryDataTableRequest request);

        CategoryCollectionResponse Fetch(CategoryQueryCollectionRequest request);
        CategoryResponse Fetch(CategoryPkRequest request);

        CategoryResponse Fetch(CategoryUcCategoryNameRequest request);

        CategoryResponse Create(CategoryAddRequest request);
        CategoryResponse Update(CategoryUpdateRequest request);
        bool Delete(CategoryDeleteRequest request);
    } 
}
