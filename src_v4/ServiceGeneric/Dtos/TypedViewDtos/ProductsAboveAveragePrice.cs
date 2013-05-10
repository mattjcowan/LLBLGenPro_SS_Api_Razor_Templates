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
    public partial class ProductsAboveAveragePriceCollection : CommonTypedViewDtoBaseCollection<ProductsAboveAveragePrice>
    {
        public ProductsAboveAveragePriceCollection(){}
        public ProductsAboveAveragePriceCollection(IEnumerable<ProductsAboveAveragePrice> collection): base(collection ?? new List<ProductsAboveAveragePrice>()){}
        public ProductsAboveAveragePriceCollection(List<ProductsAboveAveragePrice> list): base(list ?? new List<ProductsAboveAveragePrice>()){}
    }

    public partial class ProductsAboveAveragePrice: CommonTypedViewDtoBase<ProductsAboveAveragePrice>
    {
      /// <summary>Gets or sets the ProductName field. </summary>
        public virtual System.String ProductName { get; set; }
      /// <summary>Gets or sets the UnitPrice field. </summary>
        public virtual Nullable<System.Decimal> UnitPrice { get; set; }

    }
}
