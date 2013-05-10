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
    public partial class SalesByCategoryCollection : CommonTypedViewDtoBaseCollection<SalesByCategory>
    {
        public SalesByCategoryCollection(){}
        public SalesByCategoryCollection(IEnumerable<SalesByCategory> collection): base(collection ?? new List<SalesByCategory>()){}
        public SalesByCategoryCollection(List<SalesByCategory> list): base(list ?? new List<SalesByCategory>()){}
    }

    public partial class SalesByCategory: CommonTypedViewDtoBase<SalesByCategory>
    {
      /// <summary>Gets or sets the CategoryId field. </summary>
        public virtual System.Int32 CategoryId { get; set; }
      /// <summary>Gets or sets the CategoryName field. </summary>
        public virtual System.String CategoryName { get; set; }
      /// <summary>Gets or sets the ProductName field. </summary>
        public virtual System.String ProductName { get; set; }
      /// <summary>Gets or sets the ProductSales field. </summary>
        public virtual Nullable<System.Decimal> ProductSales { get; set; }

    }
}
