using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu_Defeat : MonoBehaviour
{
    public void GoMenu()
    {
        SceneManager.LoadScene(0); // запустить сцену 1
          DOTween.KillAll();
    }
    public void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       Time.timeScale = 1;
         DOTween.KillAll();

    }

    public void Start()
    {
        
    }
}
