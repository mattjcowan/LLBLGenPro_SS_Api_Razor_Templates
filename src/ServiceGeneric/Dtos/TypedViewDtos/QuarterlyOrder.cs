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
    public partial class QuarterlyOrderCollection : CommonTypedViewDtoBaseCollection<QuarterlyOrder>
    {
        public QuarterlyOrderCollection(){}
        public QuarterlyOrderCollection(IEnumerable<QuarterlyOrder> collection): base(collection ?? new List<QuarterlyOrder>()){}
        public QuarterlyOrderCollection(List<QuarterlyOrder> list): base(list ?? new List<QuarterlyOrder>()){}
    }

    public partial class QuarterlyOrder: CommonTypedViewDtoBase<QuarterlyOrder>
    {
      /// <summary>Gets or sets the City field. </summary>
        public virtual System.String City { get; set; }
      /// <summary>Gets or sets the CompanyName field. </summary>
        public virtual System.String CompanyName { get; set; }
      /// <summary>Gets or sets the Country field. </summary>
        public virtual System.String Country { get; set; }
      /// <summary>Gets or sets the CustomerId field. </summary>
        public virtual System.String CustomerId { get; set; }

    }
}
