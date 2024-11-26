using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase Projectile;

    public Transform positionToShoot;

    public float timeBetweenShoot = .3f;

    private Coroutine _currentCoroutine;

    public Transform playerSideReference;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
           _currentCoroutine = StartCoroutine(StartShoot());
        }
        if(Input.GetKeyUp(KeyCode.M)){
            if(_currentCoroutine != null) 
                StopCoroutine(_currentCoroutine);
        }      
    }

    IEnumerator StartShoot(){
        while(true){
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    // Update is called once per frame
    public void Shoot()
    {
        var projectile = Instantiate(Projectile);
        projectile.transform.position = positionToShoot.position; 
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
