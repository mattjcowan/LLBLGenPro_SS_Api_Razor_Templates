using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface IProductServiceRepository: IEntityServiceRepository<Product>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(ProductDataTableRequest request);

        ProductCollectionResponse Fetch(ProductQueryCollectionRequest request);
        ProductResponse Fetch(ProductPkRequest request);

        ProductResponse Fetch(ProductUcProductNameRequest request);

        ProductResponse Create(ProductAddRequest request);
        ProductResponse Update(ProductUpdateRequest request);
        bool Delete(ProductDeleteRequest request);
    } 
}
