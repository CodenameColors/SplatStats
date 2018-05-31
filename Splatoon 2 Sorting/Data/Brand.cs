using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Splatoon_2_Sorting.Data
{

  //struct
  public struct BrandAbitiyTraits
  {
    public String Common;
    public String Uncommon;
  }

  class Brand
  {
    public String BrandName;
    public String CommonRoll;
    public String UncommonRoll;

    public static BrandTraits BrandMap = new BrandTraits();

    public Brand(String BrandName)
    {
      this.BrandName = BrandName;
      CommonRoll = BrandMap[BrandName].Common;
      UncommonRoll = BrandMap[BrandName].Uncommon;
    }

    /// <summary>
    /// Creates and fills the brandMap for common and uncommon traits
    /// </summary>
    public static void CreateBrandDict(){

      //create the Map for brand traits
      BrandMap.Add("amiibo", "Any! Pray to RN Gesus!", "Any! Pray to RN Gesus!");
      BrandMap.Add("Annaki", "Cold Blooded", "Special Saver");
      BrandMap.Add("Cuttlegear", "Any! Pray to the squid sisters!", "Any! Pray to the squid sisters!");
      BrandMap.Add("Enperry", "Sub Power Up", "Ink Resistance Up");
      BrandMap.Add("Firefin", "Ink Saver (Sub)", "Ink Recovery Up");
      BrandMap.Add("Forge", "Special Power Up", "Ink Saver (Sub)");
      BrandMap.Add("Grizzco", "Any! Only 100 Gold Eggs? Shame...", "Any! Only 100 Gold Eggs? Shame...");
      BrandMap.Add("Inkline", "Bomb Defense Up", "Cold Blooded");
      BrandMap.Add("Krak-On", "Swim Speed Up", "Bomb Defense Up");
      BrandMap.Add("Rockenberg", "Run Speed Up", "Swim Speed Up");
      BrandMap.Add("Skalop", "Quick Respawn", "Special Saver");
      BrandMap.Add("Splash Mob", "Ink Saver Main", "Run Speed Up");
      BrandMap.Add("SquidForce", "Ink Resistance Up", "Ink Saver Main");
      BrandMap.Add("Takoroka", "Special Charge Up", "Special Power Up");
      BrandMap.Add("Tentatek", "Ink Recovery Up", "Quick Super Jump");
      BrandMap.Add("Toni Kensa", "Cold Blooded", "Sub Power Up");
      BrandMap.Add("Zekko", "Special Saver", "Special Charge Up");
      BrandMap.Add("Zink", "Quick Super Jump", "Quick Respawn");
    }

    //returns the multivalue brand map
    public static BrandTraits GetBrandMap()
    {
      return BrandMap;
    }

  }
}
