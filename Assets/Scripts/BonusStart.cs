using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStart : MonoBehaviour
{
  public Info info_top_panel;

public void BonusDay(){

     PlayerPrefs.SetInt("Bread", (PlayerPrefs.GetInt("Bread") + 25));
      info_top_panel.Draw_money(); //Обновить UI с валютами
}
}
