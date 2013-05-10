using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Dtos.TypedViewDtos
{
    public partial class TypedViewCollection : CommonTypedViewDtoBaseCollection<TypedView>
    {
        public TypedViewCollection() { }
        public TypedViewCollection(IEnumerable<TypedView> collection) : base(collection ?? new List<TypedView>()) { }
        public TypedViewCollection(List<TypedView> list) : base(list ?? new List<TypedView>()) { }
    }

    public partial class TypedView
    {
        public string Name { get; set; }

        public Link MetaLink { get; set; }
    }
}
