using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameObject Upgrades_Window;

    public Button BuyCrates_Button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenClose_Upgrades() 
    {
        Upgrades_Window.SetActive(!Upgrades_Window.activeSelf);
    }

    public void Buy_Crates() 
    {
        if (GameManager.gameManager.Coins >= 300) 
        {
            GameManager.gameManager.Add_Coins(-300);
            GameManager.gameManager.Start_Crate_Spawn();
            

            BuyCrates_Button.interactable= false;
        }
    }
}
