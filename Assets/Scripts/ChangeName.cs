using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour {

    public GameObject NameText_Enter;
    public GameObject NameText_Enter_InputField;

    public GameObject Change_Name_And_Countrie_Tab;
    public GameObject ErrorName;//Окно с ошибкой при вводе слишком короткого ника(меньше 4 символов)
    
  //  public GameObject FlagOnButton;//Флаг на кнопке

    public DB dB;
 //   public Countries Countries_script;



    public void OpenTab () {
        Change_Name_And_Countrie_Tab.SetActive (true);


        NameText_Enter_InputField.GetComponent<InputField> ().text = "" + PlayerPrefs.GetString ("User_name");
        Debug.Log ("OpenTab");
      //  FlagOnButton.GetComponent<Image> ().sprite = Countries_script.CountrySprite (PlayerPrefs.GetString ("Player_Flag")); //Установка картинки флага

    }



    public void Change () {

        if (NameText_Enter.GetComponent<Text> ().text.Length >= 4) {
            dB.SetName ("" + NameText_Enter.GetComponent<Text> ().text);
            Change_Name_And_Countrie_Tab.SetActive (false);
        } else {
            Debug.Log ("Слишком короткий ник");
            ErrorName.SetActive (true);
        }

        Debug.Log ("ChangeName");
    }

}