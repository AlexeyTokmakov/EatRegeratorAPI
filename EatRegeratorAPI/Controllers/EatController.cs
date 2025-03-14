﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EatRegeratorAPI.Service;
using EatRegeratorAPI.Services;
using EatRegeratorAPI.Services.EatClasses;
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

    [HttpPost("GetDishes")]
    public GetDishesResult GetDishes(GetDishesInput input)
    {
      return eatService.GetDishes(input);
    }

    [HttpGet("GetRecipe")]
    public GetRecipeResult GetRecipe(Guid dishGuid)
    {
      return eatService.GetRecipe(dishGuid);
    }
  }
}
