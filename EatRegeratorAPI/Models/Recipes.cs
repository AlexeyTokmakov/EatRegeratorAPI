﻿using System;
using System.Collections.Generic;

namespace EatRegeratorAPI
{
    public partial class Recipes
    {
        public Guid RecipeGuid { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public string PictureUrl { get; set; }
        public string Title { get; set; }
        public Guid DishGuid { get; set; }

        public virtual Dishes DishGu { get; set; }
    }
}
