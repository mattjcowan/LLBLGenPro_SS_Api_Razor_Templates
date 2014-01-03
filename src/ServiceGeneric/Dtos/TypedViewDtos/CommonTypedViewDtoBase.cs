///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Thursday, January 02, 2014 6:46:56 PM
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif

namespace Northwind.Data.Dtos.TypedViewDtos
{ 
  /// <summary>An System.Collections.ObjectModel.ObservableCollection that raises individual item removal notifications on clear and prevents adding duplicates.</summary>
  /// <typeparam name="T"></typeparam>
  public class CommonTypedViewDtoBaseCollection<T> : ObservableCollection<T>
  {
      public CommonTypedViewDtoBaseCollection() {}
      public CommonTypedViewDtoBaseCollection(IEnumerable<T> collection) : base(collection) {}
      public CommonTypedViewDtoBaseCollection(List<T> list) : base(list) {}

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
  public abstract partial class CommonTypedViewDtoBase
  {
    /// <summary>Method called from the constructor</summary>
    partial void OnCreated();
  
    /// <summary>Initializes a new instance of the <see cref="CommonDtoBase"/> class.</summary>
    protected CommonTypedViewDtoBase() : base()
    {
      OnCreated();
    }

    
        // __LLBLGENPRO_USER_CODE_REGION_START CustomDtoCode
        // __LLBLGENPRO_USER_CODE_REGION_END


  }
  
  /// <summary>Common base class which is the base class for all generated dtos which aren't a subtype of another dto.</summary>
  public abstract partial class CommonTypedViewDtoBase<TDto>: CommonTypedViewDtoBase
  {   
    /// <summary>Initializes a new instance of the <see cref="CommonDtoBase"/> class.</summary>
    protected CommonTypedViewDtoBase() : base()
    {
    }
    
    
        // __LLBLGENPRO_USER_CODE_REGION_START CustomGenericDtoCode
        // __LLBLGENPRO_USER_CODE_REGION_END


  }
}
