using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]

public class SavePoints 
{
   public int Coins;
   public int tier1;
   public int tier2;
   public int tier3;
   public int tier4;
   public int tier5;
   public int tier6;


   public SavePoints ( int Coins, int tier1, int tier2, int tier3, int tier4, int tier5, int tier6)
   {
      this.Coins = Coins;
      this.tier1 = tier1;
      this.tier2 = tier2;
      this.tier3 = tier3;
      this.tier4 = tier4;
      this.tier5 = tier5;
      this.tier6 = tier6;
   }
}
