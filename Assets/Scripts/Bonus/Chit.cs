using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chit : MonoBehaviour
{
    // Start is called before the first frame update
   public void OpenAllLevels () {
        for (int i = 0; i < 69; i++) {
            PlayerPrefs.SetString ("Level_" + i, "complete"); //Открыть уровень
        }
    }

    public void StartChit(){
        PlayerPrefs.SetInt ("Carrot", 9999999);
        PlayerPrefs.SetInt ("Bread", 9999999);
        PlayerPrefs.SetInt ("Tooth", 999999);
    }  
}
