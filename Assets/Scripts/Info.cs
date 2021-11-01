using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {
    //!Деньги
    public GameObject Bread; // Золото
    public GameObject Tooth; //Кристалики
    public GameObject Carrot; //Морковь
    public GameObject Flag; //Флаг


    //! Счетчик
    public GameObject DeatZombi;

    //!Флаг
    public GameObject FlagOnButton;//Флаг на кнопке
    public Countries Countries_script;

    void Start () {
        Draw_money ();
        Draw_flag();
    }

    //Отрисовка денег
    public void Draw_money () {
        Bread.gameObject.GetComponent<Text> ().text = "" + PlayerPrefs.GetInt ("Bread");
        Tooth.gameObject.GetComponent<Text> ().text = "" + PlayerPrefs.GetInt ("Tooth");
        Carrot.gameObject.GetComponent<Text> ().text = "" + PlayerPrefs.GetInt ("Carrot");
    }

    //Отрисовка флага
    public void Draw_flag () {
        Flag.GetComponent<Image> ().sprite = Countries_script.CountrySprite (PlayerPrefs.GetString ("Player_Flag")); //Установка картинки флага
        FlagOnButton.GetComponent<Image> ().sprite = Countries_script.CountrySprite (PlayerPrefs.GetString ("Player_Flag")); //Установка картинки флага

    }

    public void Draw_counter () {
        DeatZombi.gameObject.GetComponent<Text> ().text = "" + PlayerPrefs.GetInt ("DeatZombi");

    }
}