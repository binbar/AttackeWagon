using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoRating : MonoBehaviour
{
    public LoadingSRC LoadingSRC_script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoRatingScene() // Загрузка сцену с рейтингом
    {
        LoadingSRC_script.LoadSomeLvl("Rating");

       // SceneManager.LoadScene(69);
       // Time.timeScale = 1; // начать со скорости 1.
    }
}
