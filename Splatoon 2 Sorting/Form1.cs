using System.Windows.Forms;
using Splatoon_2_Sorting.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Drawing;

namespace Splatoon_2_Sorting
{
  public partial class MainForm : Form
  {

    //data from files
    public ArrayList HeadGearData = new ArrayList();
    public ArrayList ClothesData = new ArrayList();
    public ArrayList ShoesData = new ArrayList();

    //parsed data
    List<Gear> HeadGear = new List<Gear>();
    List<Gear> Clothes = new List<Gear>();
    List<Gear> Shoes = new List<Gear>();

    public MainForm()
    {
      InitializeComponent();
      Brand.CreateBrandDict();

      //read data and parse into arrays
      ParseHeadGearFile();
      ParseClothesFile();
      ParseShoesFile();

      #region "HeadGear Parse"
      //parse into gear structs
      foreach (String CurrentData in HeadGearData)
      {

        //syntax beat me...
        String TempCurrentData = CurrentData;

        //get Properites
        String TempName;
        String TempAbility;
        Brand TempBrand;
        int TempStars;

        //parse for name
        TempName = TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t"));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Ability
        TempAbility = TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t"));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Brand
        TempBrand = new Brand(TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t")));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Stars
        Int32.TryParse(TempCurrentData, out TempStars);

        HeadGear.Add(new Gear(TempName, TempAbility, TempBrand, TempStars));

      }
      #endregion

      #region "Clothes Parse"
      //parse into gear structs
      foreach (String CurrentData in ClothesData)
      {

        //syntax beat me...
        String TempCurrentData = CurrentData;

        //get Properites
        String TempName;
        String TempAbility;
        Brand TempBrand;
        int TempStars;

        //parse for name
        TempName = TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t"));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Ability
        TempAbility = TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t"));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Brand
        TempBrand = new Brand(TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t")));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Stars
        Int32.TryParse(TempCurrentData, out TempStars);

        Clothes.Add(new Gear(TempName, TempAbility, TempBrand, TempStars));

      }
      #endregion

      #region "Shoes Parse"
      //parse into gear structs
      foreach (String CurrentData in ShoesData)
      {

        //syntax beat me...
        String TempCurrentData = CurrentData;

        //get Properites
        String TempName;
        String TempAbility;
        Brand TempBrand;
        int TempStars;

        //parse for name
        TempName = TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t"));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Ability
        TempAbility = TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t"));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Brand
        TempBrand = new Brand(TempCurrentData.Substring(0, TempCurrentData.IndexOf("\t")));
        //move down the line
        TempCurrentData = TempCurrentData.Substring(TempCurrentData.IndexOf("\t") + 1);

        //parse for Stars
        Int32.TryParse(TempCurrentData, out TempStars);

        Shoes.Add(new Gear(TempName, TempAbility, TempBrand, TempStars));

      }
      #endregion

    }


    private void ParseHeadGearFile()
    {
      try
      {
        String Line;
        //read file
        System.IO.StreamReader file = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + "../../../Head Gear.txt");
        //read line by line
        while ((Line = file.ReadLine()) != null)
        {
          //Console.WriteLine(Line);
          HeadGearData.Add(Line);
        }
        file.Close();
      }
      catch (System.IO.FileNotFoundException e)
      {
        Console.WriteLine(e);
      }
    }

    private void ParseClothesFile()
    {
      try
      {
        String Line;
        //read file
        System.IO.StreamReader file = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + "../../../Clothes.txt");
        //read line by line
        while ((Line = file.ReadLine()) != null)
        {
          //Console.WriteLine(Line);
          ClothesData.Add(Line);
        }
        file.Close();
      }
      catch (System.IO.FileNotFoundException e)
      {
        Console.WriteLine(e);
      }
    }

    private void ParseShoesFile()
    {
      try
      {
        String Line;
        //read file
        System.IO.StreamReader file = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + "../../../Shoes.txt");
        //read line by line
        while ((Line = file.ReadLine()) != null)
        {
          //Console.WriteLine(Line);
          ShoesData.Add(Line);
        }
        file.Close();
      }
      catch (System.IO.FileNotFoundException e)
      {
        Console.WriteLine(e);
      }
    }

    private List<Gear> FilterGear(List<Gear> ListToFilter, String FilterObject, String FilterType)
    {

      List<Gear> TempList = new List<Gear>(ListToFilter);

      //if no sorting needs to be done exit
      if (FilterObject == "" || FilterObject == "(None)")
      {
        return ListToFilter;
      }
      //do sorting
      else
      {
        if (FilterType == "Ability")
        {
          foreach (Gear g in ListToFilter)
          {
            if (!g.MainAbility.ToLower().Equals(FilterObject.ToLower()))
            {
              TempList.Remove(g);
            }

          }
          return TempList;
        }

        else if (FilterType == "Brand")
        {
          foreach (Gear g in ListToFilter)
          {
            if (!g.GearBrand.BrandName.ToLower().Equals(FilterObject.ToLower()))
            {
              TempList.Remove(g);
            }
          }
          return TempList;
        }

        else if (FilterType == "Stars")
        {
          foreach (Gear g in ListToFilter)
          {
            if (g.Stars.ToString() != FilterObject)
            {
              TempList.Remove(g);
            }
          }
          return TempList;
        }

      }
      return TempList;
    }

    private void FilterBtn_Click(object sender, EventArgs e)
    {
      //ArrayLists to add to GUI AFTER SORT
      List<Gear> HeadGearSorted = HeadGear;
      List<Gear> ClothesSorted = Clothes;
      List<Gear> ShoesSorted = Shoes;
      String[] FilterType = new String[3];
      #region "Setup Filters"

      if (AbilityFilterCBB.Text != "" || AbilityFilterCBB.Text != "(None)")
      {
        FilterType[0] = AbilityFilterCBB.Text;
      }
      else
      {
        FilterType[0] = "";
      }

      if (BrandFilterCBB.Text != "" || BrandFilterCBB.Text != "(None)")
      {
        FilterType[1] = BrandFilterCBB.Text;
      }
      else
      {
        FilterType[1] = "";
      }

      if (StarFilterCBB.Text != "" || StarFilterCBB.Text != "(None)")
      {
        FilterType[2] = StarFilterCBB.Text;
      }
      else
      {
        FilterType[2] = "";
      }

      #endregion

      //clear stuff gui here
      ClothesSortedLB.Items.Clear();
      HeadgearSortedLB.Items.Clear();
      ShoesSortedLB.Items.Clear();
      HeadgearAbilitesLB.Items.Clear();

      HeadGearSorted = FilterGear(HeadGearSorted, AbilityFilterCBB.Text, "Ability");
      HeadGearSorted = FilterGear(HeadGearSorted, BrandFilterCBB.Text, "Brand");
      HeadGearSorted = FilterGear(HeadGearSorted, StarFilterCBB.Text, "Stars");

      ClothesSorted = FilterGear(ClothesSorted, AbilityFilterCBB.Text, "Ability");
      ClothesSorted = FilterGear(ClothesSorted, BrandFilterCBB.Text, "Brand");
      ClothesSorted = FilterGear(ClothesSorted, StarFilterCBB.Text, "Stars");

      ShoesSorted = FilterGear(ShoesSorted, AbilityFilterCBB.Text, "Ability");
      ShoesSorted = FilterGear(ShoesSorted, BrandFilterCBB.Text, "Brand");
      ShoesSorted = FilterGear(ShoesSorted, StarFilterCBB.Text, "Stars");

      foreach (Gear g in HeadGearSorted)
      {
        HeadgearSortedLB.Items.Add(g.Name);
      }
      foreach (Gear g in ClothesSorted)
      {
        ClothesSortedLB.Items.Add(g.Name);
      }
      foreach (Gear g in ShoesSorted)
      {
        ShoesSortedLB.Items.Add(g.Name);
      }
    }

    private void HeadgearSortedLB_SelectedIndexChanged(object sender, EventArgs e)
    {
      HeadgearAbilitesLB.Items.Clear();
      foreach (Gear g in HeadGear)
      {
        if (HeadgearSortedLB.SelectedItem.ToString().Equals(g.Name))
        {
          HeadgearAbilitesLB.Items.Add(g.GearBrand.CommonRoll);
          HeadgearAbilitesLB.Items.Add(g.GearBrand.UncommonRoll);
          HeadgearAbilitesLB.Items.Add("Number of Stars:  " + g.Stars);

          HeadCommonPB.Image = Properties.Resources.BombDamage_Reduction;

          break;
        }
      }
    }

    private void ClothesAbilitiesLB_SelectedIndexChanged(object sender, EventArgs e)
    {
      ClothesAbilitiesLB.Items.Clear();
      foreach (Gear g in Clothes)
      {
        if (ClothesSortedLB.SelectedItem.ToString().Equals(g.Name))
        {
          ClothesAbilitiesLB.Items.Add(g.GearBrand.CommonRoll);
          ClothesAbilitiesLB.Items.Add(g.GearBrand.UncommonRoll);
          ClothesAbilitiesLB.Items.Add("Number of Stars:  " + g.Stars);
          break;
        }
      }
    }

    private void ShoeAbilitiesLB_SelectedIndexChanged(object sender, EventArgs e)
    {
      ShoeAbilitiesLB.Items.Clear();
      foreach (Gear g in Shoes)
      {
        if (ShoesSortedLB.SelectedItem.ToString().Equals(g.Name))
        {
          ShoeAbilitiesLB.Items.Add(g.GearBrand.CommonRoll);
          ShoeAbilitiesLB.Items.Add(g.GearBrand.UncommonRoll);
          ShoeAbilitiesLB.Items.Add("Number of Stars:  " + g.Stars);
          break;
        }
      }
    }





  }
}
