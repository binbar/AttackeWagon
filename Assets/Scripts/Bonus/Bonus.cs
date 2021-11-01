using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Bonus : MonoBehaviour
{

    public GameObject Money;
    public GameObject Opit;
    // Start is called before the first frame update
    void Start()
    {
    DrawStats();
    }

    public void DrawStats(){

        Money.gameObject.GetComponent<Text>().text = "Money:" + PlayerPrefs.GetInt("Money");
        Opit.gameObject.GetComponent<Text>().text = "Money:" + PlayerPrefs.GetInt("Exp");
    }

}
