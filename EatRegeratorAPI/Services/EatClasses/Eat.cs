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
    public Guid TypeDishesGuid { get; set; }
    public Guid TypeKitchensGuid { get; set; }
    public Guid TypeMenuGuid { get; set; }
  }
}
