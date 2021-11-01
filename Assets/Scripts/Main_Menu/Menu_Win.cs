using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;


public class Menu_Win : MonoBehaviour
{
    public void GoMenu()
    {
        SceneManager.LoadScene(0); // запустить сцену 1
          DOTween.KillAll();
    }

    public void NextLevel()
    { //Переход на следуйщий уровень
        PlayerPrefs.SetInt("Opened_levels_AD", (PlayerPrefs.GetInt("Opened_levels_AD") + 1));
        PlayerPrefs.SetInt("Count_Opened_levels", (PlayerPrefs.GetInt("Count_Opened_levels") + 1));
         if (PlayerPrefs.GetInt ("Opened_levels_AD") >= 3) {
               Debug.Log("Показываю рекламу Меню ВИН Начало");
               ShowInterstitial();
                Debug.Log("Показываю рекламу Меню ВИН Конец");
                PlayerPrefs.SetInt ("Opened_levels_AD", 0);
            }
        Invoke("NextLevelADS", 2f);

    }

    public void NextLevelADS()
    {
  DOTween.KillAll();
        int CurrentLvl = PlayerPrefs.GetInt("Current_opened_level");
        if (CurrentLvl <= 68)
        { //68 это последний уровень
            SceneManager.LoadScene("Level_" + (CurrentLvl + 1));
            PlayerPrefs.SetInt("Current_opened_level", (CurrentLvl + 1));
        }
    }

public void ShowInterstitial()
    { //Проверка на загрузку рекламы
        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            Appodeal.show(Appodeal.INTERSTITIAL);
            Debug.Log("Показываю рекламу ADS Magaer");
        Debug.Log("Реклама загружена");
    }


    public void ShowNonSkippable()
    {
        if (Appodeal.isLoaded(Appodeal.NON_SKIPPABLE_VIDEO))
            Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
        Debug.Log("Просмотр рекламы.");
    }

}