using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public static Texts texts;

   public TextMeshProUGUI Coins_Text;

   void Awake()
   {
    texts = this;
   }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText_Coins(int amount)
    {
        Coins_Text.text = amount.ToString();
    }
}
