using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Singleton;

public class ItemManager : Singleton<ItemManager>
{
   
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start(){
        Reset();
    }

    private void Reset(){
        coins.value = 0;
        UpdateUI();
    }

    // Update is called once per frame
    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI(){
        //uiTextCoins.text = coins.ToString();
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }


}
