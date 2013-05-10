using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;

namespace Northwind.Data.Dtos.TypedViewDtos
{ 
    public partial class OrdersQryCollection : CommonTypedViewDtoBaseCollection<OrdersQry>
    {
        public OrdersQryCollection(){}
        public OrdersQryCollection(IEnumerable<OrdersQry> collection): base(collection ?? new List<OrdersQry>()){}
        public OrdersQryCollection(List<OrdersQry> list): base(list ?? new List<OrdersQry>()){}
    }

    public partial class OrdersQry: CommonTypedViewDtoBase<OrdersQry>
    {
      /// <summary>Gets or sets the Address field. </summary>
        public virtual System.String Address { get; set; }
      /// <summary>Gets or sets the City field. </summary>
        public virtual System.String City { get; set; }
      /// <summary>Gets or sets the CompanyName field. </summary>
        public virtual System.String CompanyName { get; set; }
      /// <summary>Gets or sets the Country field. </summary>
        public virtual System.String Country { get; set; }
      /// <summary>Gets or sets the CustomerId field. </summary>
        public virtual System.String CustomerId { get; set; }
      /// <summary>Gets or sets the EmployeeId field. </summary>
        public virtual Nullable<System.Int32> EmployeeId { get; set; }
      /// <summary>Gets or sets the Freight field. </summary>
        public virtual Nullable<System.Decimal> Freight { get; set; }
      /// <summary>Gets or sets the OrderDate field. </summary>
        public virtual Nullable<System.DateTime> OrderDate { get; set; }
      /// <summary>Gets or sets the OrderId field. </summary>
        public virtual System.Int32 OrderId { get; set; }
      /// <summary>Gets or sets the PostalCode field. </summary>
        public virtual System.String PostalCode { get; set; }
      /// <summary>Gets or sets the Region field. </summary>
        public virtual System.String Region { get; set; }
      /// <summary>Gets or sets the RequiredDate field. </summary>
        public virtual Nullable<System.DateTime> RequiredDate { get; set; }
      /// <summary>Gets or sets the ShipAddress field. </summary>
        public virtual System.String ShipAddress { get; set; }
      /// <summary>Gets or sets the ShipCity field. </summary>
        public virtual System.String ShipCity { get; set; }
      /// <summary>Gets or sets the ShipCountry field. </summary>
        public virtual System.String ShipCountry { get; set; }
      /// <summary>Gets or sets the ShipName field. </summary>
        public virtual System.String ShipName { get; set; }
      /// <summary>Gets or sets the ShippedDate field. </summary>
        public virtual Nullable<System.DateTime> ShippedDate { get; set; }
      /// <summary>Gets or sets the ShipPostalCode field. </summary>
        public virtual System.String ShipPostalCode { get; set; }
      /// <summary>Gets or sets the ShipRegion field. </summary>
        public virtual System.String ShipRegion { get; set; }
      /// <summary>Gets or sets the ShipVia field. </summary>
        public virtual Nullable<System.Int32> ShipVia { get; set; }

    }
}
