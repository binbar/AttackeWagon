using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressLevel : MonoBehaviour {
    // Start is called before the first frame update
    public float Start_pos;
    public float End;
    public float Current; //Текущее значение
    public Slider Lvl_progress;

    public GameObject Current_obj;
    public GameObject End_obj;

    void SetProgress () {
        if (Current_obj!=null) {
        Current = Current_obj.gameObject.transform.position.x;

        float Percent = (100f / (End / Current)) / 100f;
        if (Percent < 1f) {
            Lvl_progress.value = Percent;
        } else {
            Lvl_progress.value = 1;
        }
        }
//        Debug.Log("##############################################");
    }

    void Start () {
        Start_pos = Current_obj.gameObject.transform.position.x;
        Current = Current_obj.gameObject.transform.position.x;
        End = End_obj.gameObject.transform.position.x;
        InvokeRepeating ("SetProgress", 1f, 1f);
    }

    // Update is called once per frame
    void Update () {

    }
}