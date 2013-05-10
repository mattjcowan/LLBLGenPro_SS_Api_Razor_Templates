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
    public partial class OrderSubtotalCollection : CommonTypedViewDtoBaseCollection<OrderSubtotal>
    {
        public OrderSubtotalCollection(){}
        public OrderSubtotalCollection(IEnumerable<OrderSubtotal> collection): base(collection ?? new List<OrderSubtotal>()){}
        public OrderSubtotalCollection(List<OrderSubtotal> list): base(list ?? new List<OrderSubtotal>()){}
    }

    public partial class OrderSubtotal: CommonTypedViewDtoBase<OrderSubtotal>
    {
      /// <summary>Gets or sets the OrderId field. </summary>
        public virtual System.Int32 OrderId { get; set; }
      /// <summary>Gets or sets the Subtotal field. </summary>
        public virtual Nullable<System.Decimal> Subtotal { get; set; }

    }
}
