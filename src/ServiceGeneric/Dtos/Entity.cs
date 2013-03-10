using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Dtos
{
    [Serializable]
    public partial class EntityCollection : CommonDtoBaseCollection<Entity>
    {
        public EntityCollection() { }
        public EntityCollection(IEnumerable<Entity> collection) : base(collection ?? new List<Entity>()) { }
        public EntityCollection(List<Entity> list) : base(list ?? new List<Entity>()) { }
    }

    [Serializable]
    public partial class Entity
    {
        public string Name { get; set; }

        public Link MetaLink { get; set; }
    }
}
