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
  public partial class OrderCollection : CommonDtoBaseCollection<Order>
  {
      public OrderCollection(){}
      public OrderCollection(IEnumerable<Order> collection): base(collection ?? new List<Order>()){}
      public OrderCollection(List<Order> list): base(list ?? new List<Order>()){}
  }

  //[Serializable]
  public partial class Order : CommonDtoBase<Order>
  {
    public Order()
    {
      this.OrderDetails = new OrderDetailCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Order' (includes only required properties)</summary>
    /// <param name="orderId">The initial value for the field 'OrderId'</param>  
    public static Order Create(System.Int32 orderId)
    {
      var entity = new Order();
      entity.OrderId = orderId;
      return entity;
    }

    /// <summary>Factory method to create a new instance of the type 'Order' (includes optional properties)</summary>
    /// <param name="orderId">The initial value for the field 'OrderId'</param>  
    /// <param name="customerId">The initial value for the field 'CustomerId'</param>  
    /// <param name="employeeId">The initial value for the field 'EmployeeId'</param>  
    /// <param name="orderDate">The initial value for the field 'OrderDate'</param>  
    /// <param name="requiredDate">The initial value for the field 'RequiredDate'</param>  
    /// <param name="shippedDate">The initial value for the field 'ShippedDate'</param>  
    /// <param name="shipVia">The initial value for the field 'ShipVia'</param>  
    /// <param name="freight">The initial value for the field 'Freight'</param>  
    /// <param name="shipName">The initial value for the field 'ShipName'</param>  
    /// <param name="shipAddress">The initial value for the field 'ShipAddress'</param>  
    /// <param name="shipCity">The initial value for the field 'ShipCity'</param>  
    /// <param name="shipRegion">The initial value for the field 'ShipRegion'</param>  
    /// <param name="shipPostalCode">The initial value for the field 'ShipPostalCode'</param>  
    /// <param name="shipCountry">The initial value for the field 'ShipCountry'</param>  
    public static Order Create(System.Int32 orderId, System.String customerId, Nullable<System.Int32> employeeId, Nullable<System.DateTime> orderDate, Nullable<System.DateTime> requiredDate, Nullable<System.DateTime> shippedDate, Nullable<System.Int32> shipVia, Nullable<System.Decimal> freight, System.String shipName, System.String shipAddress, System.String shipCity, System.String shipRegion, System.String shipPostalCode, System.String shipCountry)
    {
      var entity = new Order();
      entity.OrderId = orderId;
      entity.CustomerId = customerId;
      entity.EmployeeId = employeeId;
      entity.OrderDate = orderDate;
      entity.RequiredDate = requiredDate;
      entity.ShippedDate = shippedDate;
      entity.ShipVia = shipVia;
      entity.Freight = freight;
      entity.ShipName = shipName;
      entity.ShipAddress = shipAddress;
      entity.ShipCity = shipCity;
      entity.ShipRegion = shipRegion;
      entity.ShipPostalCode = shipPostalCode;
      entity.ShipCountry = shipCountry;
      return entity;
    }

    #region Class Property Declarations
  
    /// <summary>Gets or sets the OrderId field. </summary>
    public virtual System.Int32 OrderId  { get; set; }

    /// <summary>Gets or sets the CustomerId field. </summary>
    public virtual System.String CustomerId { get; set; }  

    /// <summary>Gets or sets the EmployeeId field. </summary>
    public virtual Nullable<System.Int32> EmployeeId { get; set; }  

    /// <summary>Gets or sets the OrderDate field. </summary>
    public virtual Nullable<System.DateTime> OrderDate  { get; set; }

    /// <summary>Gets or sets the RequiredDate field. </summary>
    public virtual Nullable<System.DateTime> RequiredDate  { get; set; }

    /// <summary>Gets or sets the ShippedDate field. </summary>
    public virtual Nullable<System.DateTime> ShippedDate  { get; set; }

    /// <summary>Gets or sets the ShipVia field. </summary>
    public virtual Nullable<System.Int32> ShipVia { get; set; }  

    /// <summary>Gets or sets the Freight field. </summary>
    public virtual Nullable<System.Decimal> Freight  { get; set; }

    /// <summary>Gets or sets the ShipName field. </summary>
    public virtual System.String ShipName  { get; set; }

    /// <summary>Gets or sets the ShipAddress field. </summary>
    public virtual System.String ShipAddress  { get; set; }

    /// <summary>Gets or sets the ShipCity field. </summary>
    public virtual System.String ShipCity  { get; set; }

    /// <summary>Gets or sets the ShipRegion field. </summary>
    public virtual System.String ShipRegion  { get; set; }

    /// <summary>Gets or sets the ShipPostalCode field. </summary>
    public virtual System.String ShipPostalCode  { get; set; }

    /// <summary>Gets or sets the ShipCountry field. </summary>
    public virtual System.String ShipCountry  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Order.Customer - Customer.Orders (m:1)'</summary>
    [Browsable(false)]
    public virtual Customer Customer { get; set; } 

    /// <summary>Represents the navigator which is mapped onto the association 'Order.Employee - Employee.Orders (m:1)'</summary>
    [Browsable(false)]
    public virtual Employee Employee { get; set; } 

    /// <summary>Represents the navigator which is mapped onto the association 'OrderDetail.Order - Order.OrderDetails (m:1)'</summary>
    public virtual OrderDetailCollection OrderDetails { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Order.Shipper - Shipper.Orders (m:1)'</summary>
    [Browsable(false)]
    public virtual Shipper Shipper { get; set; } 

    #endregion

  }
}
