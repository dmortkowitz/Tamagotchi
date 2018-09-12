using Microsoft.AspNetCore.Mvc;
using Tamagotchis.Models;
using System;
using System.Collections.Generic;

namespace Tamagotchis.Controllers
{
  public class TamagotchiController : Controller
  {
    [HttpGet("/tamagotchis/new")]
    public ActionResult CreateTamagotchi()
    {
      return View();
    }

    [HttpPost("/tamagotchis")]
    public ActionResult Create()
    {
      string name = Request.Form["name"];
      Tamagotchi tama = new Tamagotchi(name);
      List <Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
      return View("../Home/Index", allTamagotchis);
    }

    [HttpGet("/tamagotchis/{id}")]
    public ActionResult Details(int id)
    {
      Tamagotchi tama = Tamagotchi.Find(id);
      return View(tama);
    }

    [HttpPost("/tamagotchis/food/{id}")]
    public ActionResult Feed(int id)
    {
      Tamagotchi tama = Tamagotchi.Find(id);
      tama.SetFood(tama.GetFood()+1);
      return View("Details", tama);
    }
    [HttpPost("/tamagotchis/sleep/{id}")]
    public ActionResult Nap(int id)
    {
      Tamagotchi tama = Tamagotchi.Find(id);
      tama.SetSleep(tama.GetSleep()+1);
      return View("Details", tama);
    }
    [HttpPost("/tamagotchis/happiness/{id}")]
    public ActionResult Love(int id)
    {
      Tamagotchi tama = Tamagotchi.Find(id);
      tama.SetHappiness(tama.GetHappiness()+1);
      return View("Details", tama);
    }

    [HttpPost("/tamagotchis/time")]
    public ActionResult Decrease()
    {
      List <Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
      foreach (Tamagotchi tama in allTamagotchis)
      {
        tama.SetFood(tama.GetFood()-1);
        tama.SetSleep(tama.GetSleep()-1);
        tama.SetHappiness(tama.GetHappiness()-1);
      }
      return View("../Home/Index", allTamagotchis);
    }

    [HttpPost("/tamagotchis/clear")]
    public ActionResult ClearAll()
    {
      Tamagotchi.ClearAll();
      List <Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
      return View("../Home/Index", allTamagotchis);
    }
  }
}
