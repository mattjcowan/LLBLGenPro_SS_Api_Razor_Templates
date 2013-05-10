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
    public partial class SummaryOfSalesByYearCollection : CommonTypedViewDtoBaseCollection<SummaryOfSalesByYear>
    {
        public SummaryOfSalesByYearCollection(){}
        public SummaryOfSalesByYearCollection(IEnumerable<SummaryOfSalesByYear> collection): base(collection ?? new List<SummaryOfSalesByYear>()){}
        public SummaryOfSalesByYearCollection(List<SummaryOfSalesByYear> list): base(list ?? new List<SummaryOfSalesByYear>()){}
    }

    public partial class SummaryOfSalesByYear: CommonTypedViewDtoBase<SummaryOfSalesByYear>
    {
      /// <summary>Gets or sets the OrderId field. </summary>
        public virtual System.Int32 OrderId { get; set; }
      /// <summary>Gets or sets the ShippedDate field. </summary>
        public virtual Nullable<System.DateTime> ShippedDate { get; set; }
      /// <summary>Gets or sets the Subtotal field. </summary>
        public virtual Nullable<System.Decimal> Subtotal { get; set; }

    }
}
