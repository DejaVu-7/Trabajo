using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
    public static SaveData SaveCat;

    public GameObject Cat_Prefab, Crate_Prefab;
    public GameObject newCat_Window;
    public TextMeshProUGUI newCat_Name;
    public Image newCat_Image;

    public SpriteRenderer Fence;


    public string[] Cat_Names;
    public Sprite[] Cat_Sprites, Yarn_Sprites;

    public int Coins, Bought_Cat;
    public int highest_Tier;
    public int totalCat;


    void Awake() {
        gameManager = this;

    }

    private void Start() {
        Spawn_Cat();

       SaveData.SaveCat.Load();
    }
    // Update is called once per frame
    void Update() {

    }

    public void Buy_Cat() {
        if (Coins >= 25 * (Bought_Cat + 1)) {
            Add_Coins(-25 * (Bought_Cat + 1));
            Bought_Cat++;
            Spawn_Cat();
        }
    }
    public void Spawn_Cat() {
        Vector3 position = new Vector3(Random.Range(Fence.bounds.extents.x - 0.15f, (Fence.bounds.extents.x * -1) + 0.15f), Random.Range(Fence.bounds.extents.y - 0.5f, (Fence.bounds.extents.y * -1) + 0.5f), 0);
        Instantiate(Cat_Prefab, position, Quaternion.identity, null);
    }

    public void Spawn_Cat_At(Vector3 position) {

        Instantiate(Cat_Prefab, position, Quaternion.identity, null);
    }


    public void Spawn_Crate() {
        Vector3 position = new Vector3(Random.Range(Fence.bounds.extents.x - 0.15f, (Fence.bounds.extents.x * -1) + 0.15f), Random.Range(Fence.bounds.extents.y - 0.5f, (Fence.bounds.extents.y * -1) + 0.5f), 0);
        Instantiate(Crate_Prefab, position, Quaternion.identity, null);
    }

    public void Start_Crate_Spawn() {
        InvokeRepeating("Spawn_Crate", 1, 5);

    }

    public void Check_Tier(int tier) 
    {
        if (tier > highest_Tier) 
        {
            highest_Tier= tier;

            StartCoroutine(New_Tier());
        }
    }

    public void Add_Coins(int amount)
    {
        Coins += amount;

        Texts.texts.ChangeText_Coins(Coins);
    }

    IEnumerator New_Tier() 
    {
         newCat_Window.SetActive(true);
        newCat_Name.text = Cat_Names[highest_Tier];
        newCat_Image.sprite = Cat_Sprites[highest_Tier];

        yield return new WaitForSeconds(2);


        newCat_Window.SetActive(false);

    }
}
