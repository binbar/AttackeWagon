using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Main_Menu : MonoBehaviour
{
    public GameObject Panel_setting;
   public void PlayGame()
    {
        SceneManager.LoadScene(1); // запустить сцену 1
        Time.timeScale = 1;
        DOTween.KillAll();
    }
     void Setting()
    {
        Panel_setting.SetActive(true);
    }
    void SettingOff()
    {
        Panel_setting.SetActive(false);
    }
}
