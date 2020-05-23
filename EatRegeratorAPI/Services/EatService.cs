using EatRegeratorAPI.Services;
using EatRegeratorAPI.Services.EatClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatRegeratorAPI.Service
{
  public class EatService : IEatService
  {
    public EatRegeratorContext db;
    public EatService(EatRegeratorContext _db)
    {
      db = _db;
    }
    public GetProductsResult GetProducts()
    {
      GetProductsResult result = new GetProductsResult();
      try
      {
        result.Products = db.Products.ToList();
      }
      catch (Exception ex)
      {
        SetException(result, ex);
      }
      return result;
    }

    public GetTypeDishesResult GetTypeDishes()
    {
      GetTypeDishesResult result = new GetTypeDishesResult();
      try
      {
        result.TypeDishes = db.TypeDishes.ToList();
      }
      catch (Exception ex)
      {
        SetException(result, ex);
      }
      return result;
    }

    public GetTypesKitchensResult GetTypesKitchens()
    {
      GetTypesKitchensResult result = new GetTypesKitchensResult();
      try
      {
        result.TypesKitchen = db.TypeKitchen.ToList();
      }
      catch (Exception ex)
      {
        SetException(result, ex);
      }
      return result;
    }

    public GetTypesMenuResult GetTypesMenu()
    {
      GetTypesMenuResult result = new GetTypesMenuResult();
      try
      {
        result.TypesMenu = db.TypeMenu.ToList();
      }
      catch (Exception ex)
      {
        SetException(result, ex);
      }
      return result;
    }

    public GetDishesResult GetDishes(GetDishesInput input)
    {
      GetDishesResult result = new GetDishesResult();
      try
      {
        var dishes = db.Dishes.Include(d => d.Product2Dishs).ThenInclude(pd => pd.ProductGu).ToList();

        if (input.TypeDishesGuid != null)
          dishes = dishes.Where(d => d.TypeGuid == input.TypeDishesGuid).ToList();
        if (input.TypeKitchensGuid != null)
          dishes = dishes.Where(d => d.TypeKitchenGuid == input.TypeKitchensGuid).ToList();
        if (input.TypeMenuGuid != null)
          dishes = dishes.Where(d => d.TypeMenuGuid == input.TypeMenuGuid).ToList();

        if (input.DecreaseProductGuids != null)
          foreach (var product in input.DecreaseProductGuids)
            dishes = dishes.Where(d => d.Product2Dishs.Find(p => p.ProductGuid == product) == null).ToList();

        if (input.IncreaseProductGuids != null)
          foreach (var product in input.IncreaseProductGuids)
            dishes = dishes.Where(d => d.Product2Dishs.Find(p => p.ProductGuid == product) != null).ToList();

        result.Dishes = dishes?.Select(d => new Dish
        {
          CookingTime = d?.CookingTime,
          Description = d?.Description,
          DishGuid = d.DishGuid,
          PictureUrl = d?.PictureUrl,
          Title = d?.Title,
          TypeGuid = d.TypeGuid,
          TypeKitchenGuid = d.TypeKitchenGuid,
          TypeMenuGuid = d.TypeMenuGuid
        }).ToList() ?? new List<Dish>(); ;

      }
      catch (Exception ex)
      {
        SetException(result, ex);
      }
      return result;
    }

    public GetRecipeResult GetRecipe(Guid dishGuid)
    {
      GetRecipeResult result = new GetRecipeResult();
      try
      {
        var recipe = db.Dishes.Where(d => d.DishGuid == dishGuid).Include(d => d.Recipes).ToList();

        if (recipe != null)
        {
          result.Recipe = new DishRecipe();
          result.Recipe.CookingTime = recipe[0]?.CookingTime;
          result.Recipe.Description = recipe[0]?.Description;
          result.Recipe.DishGuid = recipe[0].DishGuid;
          result.Recipe.PictureUrl = recipe[0]?.PictureUrl;
          result.Recipe.Title = recipe[0]?.Title;
          result.Recipe.Recipe = recipe[0].Recipes?.Select(r => new Recipe
          {
            RecipeGuid = r.RecipeGuid,
            Order = r.Order,
            PictureUrl = r?.PictureUrl,
            Text = r?.Text,
            Title = r?.Title
          }).ToList() ?? new List<Recipe>();
        }
      }
      catch (Exception ex)
      {
        SetException(result, ex);
      }
      return result;
    }

    private void SetException(BaseResult result, Exception ex)
    {
      result.ResultCode = -1;
      result.Error = ex.Message;
    }
  }
}
