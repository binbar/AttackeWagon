using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAds : MonoBehaviour
{
    public Info info_top_panel;
    public void BonusForAds()
    {
        PlayerPrefs.SetInt("Bread", (PlayerPrefs.GetInt("Bread") + 1000));
        PlayerPrefs.SetInt("Tooth", (PlayerPrefs.GetInt("Tooth") + 200));
        info_top_panel.Draw_money(); //Обновить UI с валютами

    }
    public void BonusForAds(double amount, string reward) 
    {
        PlayerPrefs.SetInt(reward, (PlayerPrefs.GetInt(reward) + (int)amount));
    }
}
