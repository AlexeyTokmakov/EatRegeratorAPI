using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatRegeratorAPI
{
  public partial class Dishes
  {
    public Dishes()
    {
      Recipes = new HashSet<Recipes>();
      Product2Dishs = new List<Product2Dishs>();
    }

    public Guid DishGuid { get; set; }
    public int? CookingTime { get; set; }
    public Guid TypeGuid { get; set; }
    public string Title { get; set; }
    public Guid TypeKitchenGuid { get; set; }
    public Guid TypeMenuGuid { get; set; }
    public string PictureUrl { get; set; }
    public string Description { get; set; }

    public virtual TypeDishes TypeGu { get; set; }
    public virtual TypeKitchen TypeKitchenGu { get; set; }
    public virtual TypeMenu TypeMenuGu { get; set; }
    public virtual ICollection<Recipes> Recipes { get; set; }
    public virtual List<Product2Dishs> Product2Dishs { get; set; }
  }
}
