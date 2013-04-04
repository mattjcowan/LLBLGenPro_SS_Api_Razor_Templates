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
  public partial class ShipperCollection : CommonDtoBaseCollection<Shipper>
  {
      public ShipperCollection(){}
      public ShipperCollection(IEnumerable<Shipper> collection): base(collection ?? new List<Shipper>()){}
      public ShipperCollection(List<Shipper> list): base(list ?? new List<Shipper>()){}
  }

  public partial class Shipper : CommonDtoBase<Shipper>
  {
    public Shipper()
    {
      this.Orders = new OrderCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Shipper' (includes only required properties)</summary>
    /// <param name="shipperId">The initial value for the field 'ShipperId'</param>  
    /// <param name="companyName">The initial value for the field 'CompanyName'</param>  
    public static Shipper Create(System.Int32 shipperId, System.String companyName)
    {
      var entity = new Shipper();
      entity.ShipperId = shipperId;
      entity.CompanyName = companyName;
      return entity;
    }

    /// <summary>Factory method to create a new instance of the type 'Shipper' (includes optional properties)</summary>
    /// <param name="shipperId">The initial value for the field 'ShipperId'</param>  
    /// <param name="companyName">The initial value for the field 'CompanyName'</param>  
    /// <param name="phone">The initial value for the field 'Phone'</param>  
    public static Shipper Create(System.Int32 shipperId, System.String companyName, System.String phone)
    {
      var entity = new Shipper();
      entity.ShipperId = shipperId;
      entity.CompanyName = companyName;
      entity.Phone = phone;
      return entity;
    }

    #region Class Property Declarations
  
    /// <summary>Gets or sets the ShipperId field. </summary>
    public virtual System.Int32 ShipperId  { get; set; }

    /// <summary>Gets or sets the CompanyName field. </summary>
    public virtual System.String CompanyName  { get; set; }

    /// <summary>Gets or sets the Phone field. </summary>
    public virtual System.String Phone  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Order.Shipper - Shipper.Orders (m:1)'</summary>
    public virtual OrderCollection Orders { get; set; }

    #endregion

  }
}
