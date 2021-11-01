using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Pausemenu : MonoBehaviour
{
    public GameObject panelPause; // Обьект с кнопками

    public void PauseControl()
    {
        if (Time.timeScale == 1) // Если время = 1, то установить на 0.
        {
            DOTween.KillAll();
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
        else // если время = 0, то установить его на 1.
        {
            DOTween.KillAll();
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }
    }
      public void Restart() // Начать уровень заново.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void InMenu() // Выйти в главное меню
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);
        Time.timeScale = 1; // начать со скорости 1.
    }


}
