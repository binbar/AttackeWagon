using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCoin : MonoBehaviour
{
    // Начисляем моенты + бонусы за покупку
    public Info info_top_panel;
    public GameObject Money_on;
  
    public void Coin10000(){
        PlayerPrefs.SetInt("Bread", (PlayerPrefs.GetInt("Bread") + 55000));
        PlayerPrefs.SetInt("Tooth", (PlayerPrefs.GetInt("Tooth") + 22000));
        info_top_panel.Draw_money(); //Обновить UI с валютами
        Money_on.SetActive(true);
    }
    public void Coin100000(){
        PlayerPrefs.SetInt("Bread", (PlayerPrefs.GetInt("Bread") + 220000));
        PlayerPrefs.SetInt("Tooth", (PlayerPrefs.GetInt("Tooth") + 80000));
        info_top_panel.Draw_money(); //Обновить UI с валютами
        Money_on.SetActive(true);
    }
    public void Coin250000(){
        PlayerPrefs.SetInt("Bread", (PlayerPrefs.GetInt("Bread") + 700000));
        PlayerPrefs.SetInt("Tooth", (PlayerPrefs.GetInt("Tooth") + 300000));
        info_top_panel.Draw_money(); //Обновить UI с валютами
        Money_on.SetActive(true);
    }
    public void Coin1000000(){
        PlayerPrefs.SetInt("Bread", (PlayerPrefs.GetInt("Bread") + 2000000));
        PlayerPrefs.SetInt("Tooth", (PlayerPrefs.GetInt("Tooth") + 1000000));
        info_top_panel.Draw_money(); //Обновить UI с валютами
        Money_on.SetActive(true);
    }
}
