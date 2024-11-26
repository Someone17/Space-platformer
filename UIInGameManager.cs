using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;
  

    // Update is called once per frame
    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }
}
