using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBase : MonoBehaviour
{
    
   public string compareTag = "Player";
   
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.transform.CompareTag(compareTag)){
            Collect();
        }
    }

   protected virtual void Collect()
    {
        Debug.Log("Collect");
        gameObject.SetActive(false);
        OnCollect();
    }

    // Update is called once per frame
   protected virtual void OnCollect()
    {
        
    }
}
