using EatRegeratorAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatRegeratorAPI.Service
{
  public interface IEatService
  {
    GetProductsResult GetProducts();
    GetTypeDishesResult GetTypeDishes();
    GetTypesKitchensResult GetTypesKitchens();
    GetTypesMenuResult GetTypesMenu();

  }
}
