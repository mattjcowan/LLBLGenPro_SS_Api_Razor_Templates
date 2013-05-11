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
    public partial class ProductsByCategoryCollection : CommonTypedViewDtoBaseCollection<ProductsByCategory>
    {
        public ProductsByCategoryCollection(){}
        public ProductsByCategoryCollection(IEnumerable<ProductsByCategory> collection): base(collection ?? new List<ProductsByCategory>()){}
        public ProductsByCategoryCollection(List<ProductsByCategory> list): base(list ?? new List<ProductsByCategory>()){}
    }

    public partial class ProductsByCategory: CommonTypedViewDtoBase<ProductsByCategory>
    {
      /// <summary>Gets or sets the CategoryName field. </summary>
        public virtual System.String CategoryName { get; set; }
      /// <summary>Gets or sets the ProductName field. </summary>
        public virtual System.String ProductName { get; set; }
      /// <summary>Gets or sets the QuantityPerUnit field. </summary>
        public virtual System.String QuantityPerUnit { get; set; }
      /// <summary>Gets or sets the UnitsInStock field. </summary>
        public virtual Nullable<System.Int16> UnitsInStock { get; set; }
      /// <summary>Gets or sets the Discontinued field. </summary>
        public virtual System.Boolean Discontinued { get; set; }

    }
}
