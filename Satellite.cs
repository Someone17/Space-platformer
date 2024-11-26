using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    public Animator animator;

    public string triggerToPlay = "Fly";

    private void OnValidate(){
        if(animator == null) animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            animator.SetTrigger(triggerToPlay);
        }
    }
}
