///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Saturday, March 09, 2013 5:47:50 PM
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif

namespace Northwind.Data.Dtos
{ 
  /// <summary>An System.Collections.ObjectModel.ObservableCollection that raises individual item removal notifications on clear and prevents adding duplicates.</summary>
  /// <typeparam name="T"></typeparam>
  public class CommonDtoBaseCollection<T> : ObservableCollection<T>
  {
      public CommonDtoBaseCollection() {}
      public CommonDtoBaseCollection(IEnumerable<T> collection) : base(collection) {}
      public CommonDtoBaseCollection(List<T> list) : base(list) {}

      /// <summary>clears the items.</summary>
      protected override void ClearItems()
      {
          new List<T>(this).ForEach(t => Remove(t));
      }

      /// <summary>Inserts the item.</summary>
      /// <param name="index">The index.</param>
      /// <param name="item">The item.</param>
      protected override void InsertItem(int index, T item)
      {
          if (!this.Contains(item))
          {
              base.InsertItem(index, item);
          }
      }
  }
  
  /// <summary>Common base class which is the base class for all generated dtos which aren't a subtype of another dto.</summary>
  [Serializable]
  public abstract partial class CommonDtoBase
  {
    /// <summary>Method called from the constructor</summary>
    partial void OnCreated();
  
    /// <summary>Initializes a new instance of the <see cref="CommonDtoBase"/> class.</summary>
    protected CommonDtoBase() : base()
    {
      OnCreated();
    }

    
    // __LLBLGENPRO_USER_CODE_REGION_START CustomDtoCode
    // __LLBLGENPRO_USER_CODE_REGION_END
    

  }
  
  /// <summary>Common base class which is the base class for all generated dtos which aren't a subtype of another dto.</summary>
  [Serializable]
  public abstract partial class CommonDtoBase<TDto>: CommonDtoBase
  {   
    /// <summary>Initializes a new instance of the <see cref="CommonDtoBase"/> class.</summary>
    protected CommonDtoBase() : base()
    {
    }
    
    
    // __LLBLGENPRO_USER_CODE_REGION_START CustomGenericDtoCode
    // __LLBLGENPRO_USER_CODE_REGION_END
    

  }
}
