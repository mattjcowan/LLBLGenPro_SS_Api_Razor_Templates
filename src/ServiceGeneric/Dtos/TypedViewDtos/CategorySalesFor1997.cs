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
    public partial class CategorySalesFor1997Collection : CommonTypedViewDtoBaseCollection<CategorySalesFor1997>
    {
        public CategorySalesFor1997Collection(){}
        public CategorySalesFor1997Collection(IEnumerable<CategorySalesFor1997> collection): base(collection ?? new List<CategorySalesFor1997>()){}
        public CategorySalesFor1997Collection(List<CategorySalesFor1997> list): base(list ?? new List<CategorySalesFor1997>()){}
    }

    public partial class CategorySalesFor1997: CommonTypedViewDtoBase<CategorySalesFor1997>
    {
      /// <summary>Gets or sets the CategoryName field. </summary>
        public virtual System.String CategoryName { get; set; }
      /// <summary>Gets or sets the CategorySales field. </summary>
        public virtual Nullable<System.Decimal> CategorySales { get; set; }

    }
}
