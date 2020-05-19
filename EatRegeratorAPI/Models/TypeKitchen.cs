using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class TypeKitchen
    {
        public TypeKitchen()
        {
            Dishes = new HashSet<Dishes>();
        }

        public Guid KitchenTypeGuid { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Dishes> Dishes { get; set; }
    }
}
