using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class TypeDish
    {
        public TypeDish()
        {
            Dishes = new HashSet<Dish>();
        }

        public Guid TypeGuid { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
