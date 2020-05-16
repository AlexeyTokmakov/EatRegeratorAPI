using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EatRegeratorAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EatController : ControllerBase
  {
    private readonly ILogger<EatController> _logger;
    public EatController(ILogger<EatController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public List<Dish> Get()
    {
      using(EatRegeratorContext db = new EatRegeratorContext())
      {
        List<Dish> eat = db.Dishes.Include(d=>d.Type).Include(d=>d.Recipes).ToList();
        return eat;
      }
    }
  }
}
