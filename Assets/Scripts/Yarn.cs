using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yarn : MonoBehaviour
{
    public int tier;
    // Start is called before the first frame update
    void Start()
    {
        Set_Yarn();
    }

    public void Set_Yarn()
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.Yarn_Sprites[tier];
        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1);

        GameManager.gameManager.Add_Coins((int)Mathf.Pow(10, tier));
        Destroy(gameObject);
    }
}
