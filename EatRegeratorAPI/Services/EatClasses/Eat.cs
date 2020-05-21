using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatRegeratorAPI.Services.EatClasses
{
  public class GetDishesInput
  {
    public List<Guid> IncreaseProductGuids;
    public List<Guid> DecreaseProductGuids;
    public Guid? TypeDishesGuid;
    public Guid? TypeKitchensGuid;
    public Guid? TypeMenuGuid;
  }
}
