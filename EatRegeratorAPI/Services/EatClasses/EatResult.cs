using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatRegeratorAPI.Services
{
  public class GetProductsResult : BaseResult
  {
    public List<Products> Products { get; set; }
  }

  public class GetTypeDishesResult : BaseResult
  {
    public List<TypeDishes> TypeDishes { get; set; }
  }

  public class GetTypesKitchensResult : BaseResult
  {
    public List<TypeKitchen> TypesKitchen { get; set; }
  }

  public class GetTypesMenuResult : BaseResult
  {
    public List<TypeMenu> TypesMenu { get; set; }
  }

  public class GetDishesResult: BaseResult
  {
    public List<Dishes> Dishes { get; set; }
  }
}
