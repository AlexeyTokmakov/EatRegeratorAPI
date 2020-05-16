using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class Product2Dish
    {
        public Guid ProductGuid { get; set; }
        public Guid DishGuid { get; set; }

        public virtual Dish DishGu { get; set; }
        public virtual Product ProductGu { get; set; }
    }
}
