using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelTraining : MonoBehaviour
{
  public void GoTraining()
    {
        SceneManager.LoadScene(69); // запустить сцену 1
          DOTween.KillAll();
    }
}
