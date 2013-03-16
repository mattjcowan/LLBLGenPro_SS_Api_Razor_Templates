using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;

namespace Northwind.Data.Dtos
{ 
  //[Serializable]
  public partial class OrderDetailCollection : CommonDtoBaseCollection<OrderDetail>
  {
      public OrderDetailCollection(){}
      public OrderDetailCollection(IEnumerable<OrderDetail> collection): base(collection ?? new List<OrderDetail>()){}
      public OrderDetailCollection(List<OrderDetail> list): base(list ?? new List<OrderDetail>()){}
  }

  //[Serializable]
  public partial class OrderDetail : CommonDtoBase<OrderDetail>
  {
    public OrderDetail()
    {
    }

    /// <summary>Factory method to create a new instance of the type 'OrderDetail' (includes only required properties)</summary>
    /// <param name="orderId">The initial value for the field 'OrderId'</param>  
    /// <param name="productId">The initial value for the field 'ProductId'</param>  
    /// <param name="unitPrice">The initial value for the field 'UnitPrice'</param>  
    /// <param name="quantity">The initial value for the field 'Quantity'</param>  
    /// <param name="discount">The initial value for the field 'Discount'</param>  
    public static OrderDetail Create(System.Int32 orderId, System.Int32 productId, System.Decimal unitPrice, System.Int16 quantity, System.Single discount)
    {
      var entity = new OrderDetail();
      entity.OrderId = orderId;
      entity.ProductId = productId;
      entity.UnitPrice = unitPrice;
      entity.Quantity = quantity;
      entity.Discount = discount;
      return entity;
    }


    #region Class Property Declarations
  
    /// <summary>Gets or sets the OrderId field. </summary>
    public virtual System.Int32 OrderId { get; set; }  

    /// <summary>Gets or sets the ProductId field. </summary>
    public virtual System.Int32 ProductId { get; set; }  

    /// <summary>Gets or sets the UnitPrice field. </summary>
    public virtual System.Decimal UnitPrice  { get; set; }

    /// <summary>Gets or sets the Quantity field. </summary>
    public virtual System.Int16 Quantity  { get; set; }

    /// <summary>Gets or sets the Discount field. </summary>
    public virtual System.Single Discount  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'OrderDetail.Order - Order.OrderDetails (m:1)'</summary>
    [Browsable(false)]
    public virtual Order Order { get; set; } 

    /// <summary>Represents the navigator which is mapped onto the association 'OrderDetail.Product - Product.OrderDetails (m:1)'</summary>
    [Browsable(false)]
    public virtual Product Product { get; set; } 

    #endregion

  }
}
