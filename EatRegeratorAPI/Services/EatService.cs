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

        result.Dishes = dishes;

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
