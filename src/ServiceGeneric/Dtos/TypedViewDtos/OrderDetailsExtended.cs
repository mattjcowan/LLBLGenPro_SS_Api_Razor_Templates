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
    public partial class OrderDetailsExtendedCollection : CommonTypedViewDtoBaseCollection<OrderDetailsExtended>
    {
        public OrderDetailsExtendedCollection(){}
        public OrderDetailsExtendedCollection(IEnumerable<OrderDetailsExtended> collection): base(collection ?? new List<OrderDetailsExtended>()){}
        public OrderDetailsExtendedCollection(List<OrderDetailsExtended> list): base(list ?? new List<OrderDetailsExtended>()){}
    }

    public partial class OrderDetailsExtended: CommonTypedViewDtoBase<OrderDetailsExtended>
    {
      /// <summary>Gets or sets the OrderId field. </summary>
        public virtual System.Int32 OrderId { get; set; }
      /// <summary>Gets or sets the ProductId field. </summary>
        public virtual System.Int32 ProductId { get; set; }
      /// <summary>Gets or sets the ProductName field. </summary>
        public virtual System.String ProductName { get; set; }
      /// <summary>Gets or sets the UnitPrice field. </summary>
        public virtual System.Decimal UnitPrice { get; set; }
      /// <summary>Gets or sets the Quantity field. </summary>
        public virtual System.Int16 Quantity { get; set; }
      /// <summary>Gets or sets the Discount field. </summary>
        public virtual System.Single Discount { get; set; }
      /// <summary>Gets or sets the ExtendedPrice field. </summary>
        public virtual Nullable<System.Decimal> ExtendedPrice { get; set; }

    }
}
