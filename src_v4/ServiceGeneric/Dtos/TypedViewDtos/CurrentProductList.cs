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
    public partial class CurrentProductListCollection : CommonTypedViewDtoBaseCollection<CurrentProductList>
    {
        public CurrentProductListCollection(){}
        public CurrentProductListCollection(IEnumerable<CurrentProductList> collection): base(collection ?? new List<CurrentProductList>()){}
        public CurrentProductListCollection(List<CurrentProductList> list): base(list ?? new List<CurrentProductList>()){}
    }

    public partial class CurrentProductList: CommonTypedViewDtoBase<CurrentProductList>
    {
      /// <summary>Gets or sets the ProductId field. </summary>
        public virtual System.Int32 ProductId { get; set; }
      /// <summary>Gets or sets the ProductName field. </summary>
        public virtual System.String ProductName { get; set; }

    }
}
