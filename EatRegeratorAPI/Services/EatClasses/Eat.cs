using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatRegeratorAPI.Services.EatClasses
{
  public class GetDishesInput
  {
    public List<Guid> IncreaseProductGuids { get; set; }
    public List<Guid> DecreaseProductGuids { get; set; }
    public Guid? TypeDishesGuid { get; set; }
    public Guid? TypeKitchensGuid { get; set; }
    public Guid? TypeMenuGuid { get; set; }
  }

  public class Dish
  {
    public Guid DishGuid { get; set; }
    public int? CookingTime { get; set; }
    public Guid TypeGuid { get; set; }
    public string Title { get; set; }
    public Guid TypeKitchenGuid { get; set; }
    public Guid TypeMenuGuid { get; set; }
    public string PictureUrl { get; set; }
    public string Description { get; set; }
  }

  public class DishRecipe : Dish
  {
    public List<Recipe> Recipe { get; set; }
  }

  public class Recipe
  {
    public Guid RecipeGuid { get; set; }
    public string Text { get; set; }
    public int Order { get; set; }
    public string PictureUrl { get; set; }
    public string Title { get; set; }
  }
}
