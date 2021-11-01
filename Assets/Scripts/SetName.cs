using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNameUI : MonoBehaviour
{
    public GameObject NameText;

    void Start()
    {
        SetNameUI_text();
        InvokeRepeating("SetNameUI_text", 2, 1F);
    }

    public void SetNameUI_text()
    {
        NameText.GetComponent<Text>().text = PlayerPrefs.GetString("User_name"); 
    }

}
