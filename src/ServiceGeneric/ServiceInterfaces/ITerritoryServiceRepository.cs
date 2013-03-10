using Northwind.Data.Dtos;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceInterfaces
{ 
  public interface ITerritoryServiceRepository: IEntityServiceRepository<Territory>
    {
        EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service);
        DataTableResponse GetDataTableResponse(TerritoryDataTableRequest request);

        TerritoryCollectionResponse Fetch(TerritoryQueryCollectionRequest request);
        TerritoryResponse Fetch(TerritoryPkRequest request);


        TerritoryResponse Create(TerritoryAddRequest request);
        TerritoryResponse Update(TerritoryUpdateRequest request);
        bool Delete(TerritoryDeleteRequest request);
    } 
}
