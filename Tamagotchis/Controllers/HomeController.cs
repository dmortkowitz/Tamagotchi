using Microsoft.AspNetCore.Mvc;
using Tamagotchis.Models;
using System;
using System.Collections.Generic;

namespace Tamagotchis.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List <Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
      return View(allTamagotchis);
    }
  }
}
