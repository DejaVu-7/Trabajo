using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private void OnMouseDown() 
    {
     
        OpenCrate();
            
    }

    public void OpenCrate() 
    {
        GameManager.gameManager.Spawn_Cat_At(transform.position);
      Destroy(gameObject);
    }
}
