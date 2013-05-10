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
    public partial class AlphabeticalListOfProductsCollection : CommonTypedViewDtoBaseCollection<AlphabeticalListOfProducts>
    {
        public AlphabeticalListOfProductsCollection(){}
        public AlphabeticalListOfProductsCollection(IEnumerable<AlphabeticalListOfProducts> collection): base(collection ?? new List<AlphabeticalListOfProducts>()){}
        public AlphabeticalListOfProductsCollection(List<AlphabeticalListOfProducts> list): base(list ?? new List<AlphabeticalListOfProducts>()){}
    }

    public partial class AlphabeticalListOfProducts: CommonTypedViewDtoBase<AlphabeticalListOfProducts>
    {
      /// <summary>Gets or sets the ProductId field. </summary>
        public virtual System.Int32 ProductId { get; set; }
      /// <summary>Gets or sets the ProductName field. </summary>
        public virtual System.String ProductName { get; set; }
      /// <summary>Gets or sets the SupplierId field. </summary>
        public virtual Nullable<System.Int32> SupplierId { get; set; }
      /// <summary>Gets or sets the CategoryId field. </summary>
        public virtual Nullable<System.Int32> CategoryId { get; set; }
      /// <summary>Gets or sets the QuantityPerUnit field. </summary>
        public virtual System.String QuantityPerUnit { get; set; }
      /// <summary>Gets or sets the UnitPrice field. </summary>
        public virtual Nullable<System.Decimal> UnitPrice { get; set; }
      /// <summary>Gets or sets the UnitsInStock field. </summary>
        public virtual Nullable<System.Int16> UnitsInStock { get; set; }
      /// <summary>Gets or sets the UnitsOnOrder field. </summary>
        public virtual Nullable<System.Int16> UnitsOnOrder { get; set; }
      /// <summary>Gets or sets the ReorderLevel field. </summary>
        public virtual Nullable<System.Int16> ReorderLevel { get; set; }
      /// <summary>Gets or sets the Discontinued field. </summary>
        public virtual System.Boolean Discontinued { get; set; }
      /// <summary>Gets or sets the CategoryName field. </summary>
        public virtual System.String CategoryName { get; set; }

    }
}
