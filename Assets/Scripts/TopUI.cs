using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopUI : MonoBehaviour {
    // Start is called before the first frame update

    public GameObject[] Top_all_UI; //Рейтинг всех пользователей за все время
    public GameObject[] Top_week_UI; //Рейтинг всех пользователей за неделю
    public GameObject User_Top_all_UI; //Рейтинг пользователя за все время
    public GameObject User_Top_week_UI; //Рейтинг пользователя за неделю

    public GameObject Time_to_reset; //время до обновления пользователя

    public DB dB;
    public Countries Countries_script;

    public TopInfo top = new TopInfo ();

    public int Time_top_draw;

    void Start () {
        dB.GetTop ();
        InvokeRepeating ("CalculateTime",1f,1f);
    }

    public void CalculateTime () {
        Time_top_draw--;
        Time_to_reset.GetComponent<Text> ().text = "" + SecondToMinutesAndHours (Time_top_draw);
//Time_top_draw
    }

    public void GetDataTops () {

        foreach (User_r item in top.top_all) {
            Debug.Log ("$$$$" + item.name);
        }
        DrawTops ();
    }

    string SecondToMinutesAndHours (int Seconds) {
        string result = "";
        var ts = TimeSpan.FromSeconds (Seconds);
        result += "" + ((ts.Days * 24) + ts.Hours); //Часы 
        result += ":" + ts.Minutes; //Минуты
        result += ":" + ts.Seconds; //Секунды
        return result;
    }

    public void DrawTops () {
        Time_top_draw=top.Server_time;
    //   Debug.Log ("Server_time=" + top.Server_time);
        Time_to_reset.GetComponent<Text> ().text = "" + SecondToMinutesAndHours (Time_top_draw);
        //top.User_name;
        //top.User_rating_all;
        //top.User_rating_week;
        Debug.Log ("Top_all_UI.3123=" + Top_all_UI.Length);
        //Топ за всё время

        //   try
        //      {
        //За всё время
        User_Top_all_UI.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + top.User_rating_all_rank_pos; //Позиция в рейтинге
        User_Top_all_UI.gameObject.transform.GetChild (1).GetComponent<Text> ().text = "" + top.User_name; //Имя
        User_Top_all_UI.gameObject.transform.GetChild (2).GetComponent<Text> ().text = "" + top.User_rating_all; //Рейтинг
        User_Top_all_UI.gameObject.transform.GetChild (3).GetComponent<Image> ().sprite = Countries_script.CountrySprite (top.User_country); //Установка картинки флага

        //За всё неделю
        User_Top_week_UI.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + top.User_rating_week_rank_pos; //Позиция в рейтинге
        User_Top_week_UI.gameObject.transform.GetChild (1).GetComponent<Text> ().text = "" + top.User_name; //Имя
        User_Top_week_UI.gameObject.transform.GetChild (2).GetComponent<Text> ().text = "" + top.User_rating_week; //Рейтинг
        User_Top_week_UI.gameObject.transform.GetChild (3).GetComponent<Image> ().sprite = Countries_script.CountrySprite (top.User_country); //Установка картинки флага

        //  }
        /*
        catch
        {
            Debug.Log("Ошибка");
        }
*/
        try {
            for (int i = 0; i < Top_all_UI.Length; i++) {
                //Top_all_UI[i].gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + top.top_all[i].name;
                Top_all_UI[i].gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + top.top_all[i].name;
                Top_all_UI[i].gameObject.transform.GetChild (1).GetComponent<Text> ().text = "" + top.top_all[i].rating;
                Top_all_UI[i].gameObject.transform.GetChild (3).GetComponent<Image> ().sprite = Countries_script.CountrySprite (top.top_all[i].country); //Установка картинки флага
                ////         Top_all_UI[i].gameObject.transform.GetChild (2).GetComponent<Image> ().sprite = Countries_script.CountrySprite ("UA"); //Установка картинки флага

            }
        } catch {

        }

        //Топ за неделю
        try {
            for (int i = 0; i < Top_week_UI.Length; i++) {
                Top_week_UI[i].gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + top.top_week[i].name;
                Top_week_UI[i].gameObject.transform.GetChild (1).GetComponent<Text> ().text = "" + top.top_week[i].rating;
                Top_week_UI[i].gameObject.transform.GetChild (3).GetComponent<Image> ().sprite = Countries_script.CountrySprite (top.top_week[i].country); //Установка картинки флага

            }
        } catch {

        }

    }

}