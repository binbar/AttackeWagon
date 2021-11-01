using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Task_test : MonoBehaviour {
    public GameObject T; //Указать обьект с текстом

    void Start () {
        IncrementIntText (10, T);
    }

    public async void IncrementIntText (float Target, GameObject SomeText) {
        float Time = 5f; // Время за которое требуеться завершить все операции
        int Delay = (int) ((Time / (Target + 1)) * 1000); // Задержка между каждой опирацией
        Debug.Log ("Target:" + Target);
        Debug.Log ("One operation time:" + Delay);
        for (int i = 0; i <= Target; i++) {
            Debug.Log ("i:" + i);
            SomeText.GetComponent<Text> ().text = "" + i; 
            await Task.Delay (Delay); 
        }
    }

}