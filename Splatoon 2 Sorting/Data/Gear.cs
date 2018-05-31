using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Splatoon_2_Sorting.Data
{
  class Gear
  {
    public String Name;
    public String MainAbility;
    public Brand GearBrand;
    public int Stars;

    public Gear(String Name, String MainAbility, Brand GearBrand, int Stars)
    {
      this.Name = Name;
      this.MainAbility = MainAbility;
      this.GearBrand = GearBrand;
      this.Stars = Stars;
    }
  }
}
