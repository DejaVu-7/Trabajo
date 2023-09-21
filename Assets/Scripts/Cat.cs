using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public static GameManager gameManager;
    public int tier, good_Yarn, bad_Yarn;
    bool isDragged, hasDestination;

    Vector3 destination, offset;

    public Yarn yarn;

    float yarn_Frequency, yarn_InBelly;

    public static SaveData SaveCat;

   
    void Start()
    {
        Set_Cat();
        InvokeRepeating("Take_Yarn",1,3);
    }

    // Update is called once per frame
    void Update()
    {
        yarn_InBelly += yarn_Frequency * bad_Yarn;
        if(!isDragged)
        {
         if(hasDestination)
         {
           if(Vector3.Distance(transform.position,destination)> .5f)
           {
            transform.position = Vector3.MoveTowards(transform.position,destination, 1 * Time.deltaTime);
           }
           else
           {
            hasDestination= false;
           }
         }
         else
         {
            destination = new Vector3(Random.Range(GameManager.gameManager.Fence.bounds.extents.x -0.15f, (GameManager.gameManager.Fence.bounds.extents.x * -1) + 0.15f), Random.Range(GameManager.gameManager.Fence.bounds.extents.y -0.5f,(GameManager.gameManager.Fence.bounds.extents.y * -1) + 0.5f),0);
            hasDestination = true;
         }
        }
    }

    public void Set_Cat()
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.Cat_Sprites[tier];

        bad_Yarn = tier / 5;
        if(tier != 0)
        good_Yarn = bad_Yarn + 1;
        else 
        good_Yarn = bad_Yarn;
        yarn_Frequency = (tier + 1) * .5f;

         if (tier == 0)
    {
       SaveData.SaveCat.tier1++;
    }
    else if (tier == 1)
    {
        SaveData.SaveCat.tier2++;
    }
    else if (tier == 2)
    {
        SaveData.SaveCat.tier3++;
    }
    else if (tier == 3)
    {
        SaveData.SaveCat.tier4++;
    }
    else if (tier == 4)
    {
       SaveData.SaveCat.tier5++;
    }
    else if (tier == 5)
    {
        SaveData.SaveCat.tier6++;
    }

}
    public void Evolve()
    {
        tier ++;

        GameManager.gameManager.Check_Tier(tier);

         Set_Cat();
    }

    public void Take_Yarn()
    {
      Yarn new_Yarn = Instantiate(yarn, transform.position, Quaternion.identity, null);

        if(yarn_InBelly >= Mathf.Pow(10, good_Yarn)) 
        {
            new_Yarn.tier = good_Yarn;
            yarn_InBelly -= Mathf.Pow(10 , good_Yarn);
        }
        else 
        {
            new_Yarn.tier = bad_Yarn;
            yarn_InBelly -= Mathf.Pow(10, bad_Yarn);
        }
    }


    private void OnMouseDown()
    {
       offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10));
    }

    private void OnMouseDrag()
    {
        isDragged = true;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10)) + offset;
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(isDragged)
       {
        if(collision.tag == "Cat")
        {
            if(collision.GetComponent<Cat>().tier == tier)
            {
                Evolve();

                Destroy(collision.gameObject);
                  if (tier == 0)
                    {
                        SaveData.SaveCat.tier1++;
                    }
                    else if (tier == 1)
                    {
                        SaveData.SaveCat.tier2++;
                    }
                    else if (tier == 2)
                    {
                        SaveData.SaveCat.tier3++;
                    }
                    else if (tier == 3)
                    {
                        SaveData.SaveCat.tier4++;
                    }
                    else if (tier == 4)
                    {
                        SaveData.SaveCat.tier5++;
                    }
                    else if (tier == 5)
                    {
                       SaveData.SaveCat.tier6++;
                    }

            }
        }
       }

     }

     private void OnTriggerStay2D(Collider2D collision)
     {
        if(isDragged)
        {
            if(collision.tag == "Cat")
            {
                if (collision.GetComponent<Cat>().tier == tier)
                {
                    Evolve();

                    Destroy(collision.gameObject);
                     if (tier == 0)
                    {
                        SaveData.SaveCat.tier1++;
                    }
                    else if (tier == 1)
                    {
                        SaveData.SaveCat.tier2++;
                    }
                    else if (tier == 2)
                    {
                        SaveData.SaveCat.tier3++;
                    }
                    else if (tier == 3)
                    {
                     SaveData.SaveCat.tier4++;
                    }
                    else if (tier == 4)
                    {
                    SaveData.SaveCat.tier5++;
                    }
                    else if (tier == 5)
                    {
                    SaveData.SaveCat.tier6++;
                    }

                }
            }
        }
     }
}
