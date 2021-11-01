using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport_buy_controller : MonoBehaviour {
    public GameObject Top_menu;

    public GameObject Lodka_block;
    public GameObject Povozka_winter_block;
    public GameObject Train_block;
    public GameObject Donate_menu;//Включить меню доната

    void Start () {
        Load_transport ();
    }

    public void BuyBTN (string transport_name) {
        if (transport_name == "Lodka_TBC") {
            Buy_Transport ("Lodka_TBC", 10000, 5000);
        }
        if (transport_name == "Povozka_winter_TBC") {
            Buy_Transport ("Povozka_winter_TBC", 25000, 10000);
        }
        if (transport_name == "Train_TBC") {
            Buy_Transport ("Train_TBC", 35000, 20000);
        }
    }

    void Buy_Transport (string transport_name, int Bread_price, int Tooth_price) {
        if (PlayerPrefs.GetString (transport_name) != "yes") {
            if (PlayerPrefs.GetInt ("Bread") >= Bread_price && PlayerPrefs.GetInt ("Tooth") >= Tooth_price) {
                PlayerPrefs.SetString (transport_name, "yes"); //Покупка транспорта
                PlayerPrefs.SetInt ("Bread", PlayerPrefs.GetInt ("Bread") - Bread_price);
                PlayerPrefs.SetInt ("Tooth", PlayerPrefs.GetInt ("Tooth") - Tooth_price);

                Load_transport ();
                Top_menu.gameObject.GetComponent<Info> ().Draw_money (); //Отрисовка денег(валют) сверху
                Debug.Log ("Успешно куплено");
            } else {
                Donate_menu.SetActive (true);//Включить меню доната
                Debug.Log ("Bread=" + PlayerPrefs.GetInt ("Bread") + "Tooth=" + PlayerPrefs.GetInt ("Tooth"));
            }

        }
    }

    void Load_transport () {
        Debug.Log("Load_transport P.Prefs ="+PlayerPrefs.GetString ("Lodka"));
        if (PlayerPrefs.GetString ("Lodka_TBC") == "yes") {
            Lodka_block.SetActive (false);
            Debug.Log ("Lodka=КУПЛЕНО");
        } else {
            Debug.Log ("Lodka=НЕ КУПЛЕНО!!!");
        }

        if (PlayerPrefs.GetString ("Povozka_winter_TBC") == "yes") {
            Povozka_winter_block.SetActive (false);
          Debug.Log ("Povozka_winter=КУПЛЕНО");
        } else {
            Debug.Log ("Povozka_winter=НЕ КУПЛЕНО!!!");
        }

        if (PlayerPrefs.GetString ("Train_TBC") == "yes") {
            Train_block.SetActive (false);
            Debug.Log ("Train=КУПЛЕНО");
        } else {
            Debug.Log ("Train=НЕ КУПЛЕНО!!!");

        }
    }

    // Top_menu.gameObject.GetComponent<Info>().Draw_money(); //Отрисовка денег(валют) сверху

}