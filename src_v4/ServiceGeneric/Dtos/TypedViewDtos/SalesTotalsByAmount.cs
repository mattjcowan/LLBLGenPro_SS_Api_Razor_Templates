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
    public partial class SalesTotalsByAmountCollection : CommonTypedViewDtoBaseCollection<SalesTotalsByAmount>
    {
        public SalesTotalsByAmountCollection(){}
        public SalesTotalsByAmountCollection(IEnumerable<SalesTotalsByAmount> collection): base(collection ?? new List<SalesTotalsByAmount>()){}
        public SalesTotalsByAmountCollection(List<SalesTotalsByAmount> list): base(list ?? new List<SalesTotalsByAmount>()){}
    }

    public partial class SalesTotalsByAmount: CommonTypedViewDtoBase<SalesTotalsByAmount>
    {
      /// <summary>Gets or sets the SaleAmount field. </summary>
        public virtual Nullable<System.Decimal> SaleAmount { get; set; }
      /// <summary>Gets or sets the OrderId field. </summary>
        public virtual System.Int32 OrderId { get; set; }
      /// <summary>Gets or sets the CompanyName field. </summary>
        public virtual System.String CompanyName { get; set; }
      /// <summary>Gets or sets the ShippedDate field. </summary>
        public virtual Nullable<System.DateTime> ShippedDate { get; set; }

    }
}
