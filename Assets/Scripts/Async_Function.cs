using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Async_Function : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        StartCoroutine ("SlowIncrement", 700);
    }
    IEnumerator SlowIncrement (int Target) {
        float Time = 5f; // Время за которое требуеться завершить все операции
        float Delay = Time / Target + 1; // Задержка между каждой опирацией
        Debug.Log ("Target:" + Target);
        for (int i = 0; i <= Target; i++) {

            Debug.Log ("Time:" + i);
            yield return new WaitForSeconds (Delay);
        }

    }



    
    // Update is called once per frame

}