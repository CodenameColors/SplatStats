using System.Collections.Generic;
using System;

namespace Splatoon_2_Sorting.Data
{
  public class BrandTraits : Dictionary<String, BrandAbitiyTraits>
  {
    public void Add(String key, String value1, String value2)
    {
      BrandAbitiyTraits Val;
      Val.Common = value1;
      Val.Uncommon = value2;
      this.Add(key, Val);
    }
  }
}