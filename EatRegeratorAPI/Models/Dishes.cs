using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class Dish
    {
        public Dish()
        {
            Recipes = new HashSet<Recipe>();
        }

        public Guid DishGuid { get; set; }
        public int? CookingTime { get; set; }
        public Guid TypeGuid { get; set; }
        public string Title { get; set; }

        public virtual TypeDish Type { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
