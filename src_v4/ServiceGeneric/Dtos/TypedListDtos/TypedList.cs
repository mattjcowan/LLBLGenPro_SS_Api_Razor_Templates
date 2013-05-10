using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Dtos.TypedListDtos
{
    public partial class TypedListCollection : CommonTypedListDtoBaseCollection<TypedList>
    {
        public TypedListCollection() { }
        public TypedListCollection(IEnumerable<TypedList> collection) : base(collection ?? new List<TypedList>()) { }
        public TypedListCollection(List<TypedList> list) : base(list ?? new List<TypedList>()) { }
    }

    public partial class TypedList
    {
        public string Name { get; set; }

        public Link MetaLink { get; set; }
    }
}
