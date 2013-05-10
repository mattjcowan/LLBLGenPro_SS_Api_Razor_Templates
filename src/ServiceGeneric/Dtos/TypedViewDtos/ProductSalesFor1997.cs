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
    public partial class ProductSalesFor1997Collection : CommonTypedViewDtoBaseCollection<ProductSalesFor1997>
    {
        public ProductSalesFor1997Collection(){}
        public ProductSalesFor1997Collection(IEnumerable<ProductSalesFor1997> collection): base(collection ?? new List<ProductSalesFor1997>()){}
        public ProductSalesFor1997Collection(List<ProductSalesFor1997> list): base(list ?? new List<ProductSalesFor1997>()){}
    }

    public partial class ProductSalesFor1997: CommonTypedViewDtoBase<ProductSalesFor1997>
    {
      /// <summary>Gets or sets the CategoryName field. </summary>
        public virtual System.String CategoryName { get; set; }
      /// <summary>Gets or sets the ProductName field. </summary>
        public virtual System.String ProductName { get; set; }
      /// <summary>Gets or sets the ProductSales field. </summary>
        public virtual Nullable<System.Decimal> ProductSales { get; set; }

    }
}
