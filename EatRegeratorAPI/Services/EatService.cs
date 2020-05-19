using EatRegeratorAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatRegeratorAPI.Service
{
  public class EatService : IEatService
  {
    public GetProductsResult GetProducts()
    {
      GetProductsResult result = new GetProductsResult();
      try
      {
        using EatRegeratorContext db = new EatRegeratorContext();
        result.Products = db.Products.ToList();
      }
      catch(Exception ex)
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
        using EatRegeratorContext db = new EatRegeratorContext();
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
        using EatRegeratorContext db = new EatRegeratorContext();
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
        using EatRegeratorContext db = new EatRegeratorContext();
        result.TypesMenu = db.TypeMenu.ToList();
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
