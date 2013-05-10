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
    public partial class CustomerAndSuppliersByCityCollection : CommonTypedViewDtoBaseCollection<CustomerAndSuppliersByCity>
    {
        public CustomerAndSuppliersByCityCollection(){}
        public CustomerAndSuppliersByCityCollection(IEnumerable<CustomerAndSuppliersByCity> collection): base(collection ?? new List<CustomerAndSuppliersByCity>()){}
        public CustomerAndSuppliersByCityCollection(List<CustomerAndSuppliersByCity> list): base(list ?? new List<CustomerAndSuppliersByCity>()){}
    }

    public partial class CustomerAndSuppliersByCity: CommonTypedViewDtoBase<CustomerAndSuppliersByCity>
    {
      /// <summary>Gets or sets the City field. </summary>
        public virtual System.String City { get; set; }
      /// <summary>Gets or sets the CompanyName field. </summary>
        public virtual System.String CompanyName { get; set; }
      /// <summary>Gets or sets the ContactName field. </summary>
        public virtual System.String ContactName { get; set; }
      /// <summary>Gets or sets the Relationship field. </summary>
        public virtual System.String Relationship { get; set; }

    }
}
