using Northwind.Data.Dtos;

namespace Northwind.Data.ServiceInterfaces
{
    public interface IEntityServiceRepository<TDto>
        where TDto : CommonDtoBase
    {
    }
}
