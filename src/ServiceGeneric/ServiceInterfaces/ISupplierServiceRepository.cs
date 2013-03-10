using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface ISupplierServiceRepository: IEntityServiceRepository<Supplier>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(SupplierDataTableRequest request);

        SupplierCollectionResponse Fetch(SupplierQueryCollectionRequest request);
        SupplierResponse Fetch(SupplierPkRequest request);

        SupplierResponse Fetch(SupplierUcSupplierNameRequest request);

        SupplierResponse Create(SupplierAddRequest request);
        SupplierResponse Update(SupplierUpdateRequest request);
        bool Delete(SupplierDeleteRequest request);
    } 
}
