using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectable : MonoBehaviour
{
    [SerializeField] private string compareTag = "Player";
   
    [Header("Sounds")]
    public AudioSource audioSource;

    public ParticleSystem particleSystem;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.CompareTag(compareTag)){
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
        ItemManager.Instance.AddCoins();
        if(audioSource != null) audioSource.Play();
        if(particleSystem != null) particleSystem.Play();
    }
}
