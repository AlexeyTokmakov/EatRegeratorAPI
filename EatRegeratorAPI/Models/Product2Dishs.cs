using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class Product2Dishs
    {
        public Guid ProductGuid { get; set; }
        public Guid DishGuid { get; set; }

        public virtual Dishes DishGu { get; set; }
        public virtual Products ProductGu { get; set; }
    }
}
