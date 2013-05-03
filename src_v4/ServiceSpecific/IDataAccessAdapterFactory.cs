using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Northwind.Data
{
    public interface IDataAccessAdapterFactory
    {
        IDataAccessAdapter NewDataAccessAdapter();
    }
}
