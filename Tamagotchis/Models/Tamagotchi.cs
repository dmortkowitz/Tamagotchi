using System;
using System.Collections.Generic;

namespace Tamagotchis.Models
{
  public class Tamagotchi
  {
    private int _id;
    private string _name;
    private int _food;
    private int _sleep;
    private int _happiness;
    private bool _life;
    private static List <Tamagotchi> _instances = new List <Tamagotchi> {};

    public Tamagotchi(string name)
    {
      _name = name;
      _food = 10;
      _sleep = 10;
      _happiness = 10;
      _life = true;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string name)
    {
      _name = name;
    }
    public int GetFood()
    {
      return _food;
    }
    public void SetFood(int food)
    {
      if (food < 0)
      {
        return;
      }
      _food = food;
    }
    public int GetSleep()
    {
      return _sleep;
    }
    public void SetSleep(int sleep)
    {
      if (sleep < 0)
      {
        return;
      }
      _sleep = sleep;
    }
    public int GetHappiness()
    {
      return _happiness;
    }
    public void SetHappiness(int happiness)
    {
      if (happiness < 0)
      {
        return;
      }
      _happiness = happiness;
    }

    public static Tamagotchi Find(int id)
    {
      return _instances[id-1];
    }

    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }

    public bool GetLife()
    {
      if (this.GetSleep() == 0 || this.GetFood() == 0 || this.GetHappiness() == 0)
      {
        _life = false;
      }
      return _life;
    }
  }
}
