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
    public partial class SummaryOfSalesByQuarterCollection : CommonTypedViewDtoBaseCollection<SummaryOfSalesByQuarter>
    {
        public SummaryOfSalesByQuarterCollection(){}
        public SummaryOfSalesByQuarterCollection(IEnumerable<SummaryOfSalesByQuarter> collection): base(collection ?? new List<SummaryOfSalesByQuarter>()){}
        public SummaryOfSalesByQuarterCollection(List<SummaryOfSalesByQuarter> list): base(list ?? new List<SummaryOfSalesByQuarter>()){}
    }

    public partial class SummaryOfSalesByQuarter: CommonTypedViewDtoBase<SummaryOfSalesByQuarter>
    {
      /// <summary>Gets or sets the OrderId field. </summary>
        public virtual System.Int32 OrderId { get; set; }
      /// <summary>Gets or sets the ShippedDate field. </summary>
        public virtual Nullable<System.DateTime> ShippedDate { get; set; }
      /// <summary>Gets or sets the Subtotal field. </summary>
        public virtual Nullable<System.Decimal> Subtotal { get; set; }

    }
}
