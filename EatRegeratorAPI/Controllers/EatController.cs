using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatRegeratorAPI.Service;
using EatRegeratorAPI.Services;
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
    private readonly IEatService eatService;
    public EatController(ILogger<EatController> logger, IEatService _eatService)
    {
      _logger = logger;
      eatService = _eatService;
    }

    [HttpGet]
    public List<Dishes> Get()
    {
      using (EatRegeratorContext db = new EatRegeratorContext())
      {
        List<Dishes> eat = db.Dishes.Include(d => d.TypeGu).Include(d => d.Recipes).ToList();
        return eat;
      }
    }

    [HttpGet("GetProducts")]
    public GetProductsResult GetProducts()
    {
      return eatService.GetProducts();
    }

    [HttpGet("GetTypeDishes")]
    public GetTypeDishesResult GetTypeDishes()
    {
      return eatService.GetTypeDishes();
    }

    [HttpGet("GetTypesKitchens")]
    public GetTypesKitchensResult GetTypesKitchens()
    {
      return eatService.GetTypesKitchens();
    }

    [HttpGet("GetTypesMenu")]
    public GetTypesMenuResult GetTypesMenu()
    {
      return eatService.GetTypesMenu();
    }

  }
}
