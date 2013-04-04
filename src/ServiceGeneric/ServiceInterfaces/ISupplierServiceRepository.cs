using Northwind.Data.Dtos;
using Northwind.Data.Services;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.ServiceInterfaces
{ 
    public interface ISupplierServiceRepository: IEntityServiceRepository<Supplier>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(SupplierDataTableRequest request);

        SupplierCollectionResponse Fetch(SupplierQueryCollectionRequest request);
        SupplierResponse Fetch(SupplierPkRequest request);

        SupplierResponse Fetch(SupplierUcSupplierNameRequest request);

        SupplierResponse Create(SupplierAddRequest request);
        SupplierResponse Update(SupplierUpdateRequest request);
        SimpleResponse<bool> Delete(SupplierDeleteRequest request);
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    } 
}
