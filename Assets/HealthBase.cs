using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;

    public int startLife = 30;

    public bool destroyOnKill;
    public float delayToKill = 0f;

    public int _currentLife;
    public bool _isDead = false;

   [SerializeField] private FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if(_flashColor == null){
            _flashColor = GetComponent<FlashColor>();
        }
    }

    // Update is called once per frame
    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage){
        if (_isDead) return;

        _currentLife -= startLife;

        if(_currentLife <= 0){
            Kill();
        }

        if(_flashColor != null){
            _flashColor.Flash();
        }
    }

    private void Kill(){
        _isDead = true;
        
        if(destroyOnKill){
            Destroy(gameObject, delayToKill);
        }

        OnKill?.Invoke();
    }
}
