﻿using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class TypeDishes
    {
        public TypeDishes()
        {
            Dishes = new HashSet<Dishes>();
        }

        public Guid TypeGuid { get; set; }
        public string Title { get; set; }
        public int Code { get; set; }

        public virtual ICollection<Dishes> Dishes { get; set; }
    }
}
