using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject DialogImg; //Картинка диалога
    public GameObject DialogAniOn; //Анимация Диаплога включить
    public GameObject DialogAniOff; // Анимация диалога выключить
    public GameObject DialogText; //Текст диалога

    public string Text_dialog; //Текст который устанавливаеться в диалоге(меняеться из скрипта "Dialog")

    void Start () {
        DialogOnAni ();
    }

    //Включить анимацию {ПОЯВЛЕНИЕ}
    public void DialogOnAni () {
        DialogAniOn.SetActive (true);
        Invoke ("DialogOffAni", 0.3f);

    }

    //Отключить анимацию стартовую {ПРОИГРЫВАНИЕ ТЕКСТА}
    public void DialogOffAni () {
        DialogAniOn.SetActive (false);
        DialogImg.SetActive (true);
        // DialogAniOff.SetActive (false);
        DialogText.SetActive (true);
        Set_Text ();
        Invoke ("DialogOff", 2f);
    }

    //Установить текст
    public void Set_Text () {
        DialogText.gameObject.GetComponent<Text> ().text = Text_dialog;
    }

    //Конец Диалога {АНИМАЦИЯ ЗАТУХАНИЯ}
    public void DialogOff () {
        DialogImg.SetActive (false);
        DialogText.SetActive (false);
        DialogAniOff.SetActive (true);
        Invoke ("DialogEnd", 0.3f);
    }
    //Конец анимации диалога. {ОТКЛЮЧЕНИЕ АНИМАЦИИ ЗАТУХАНИЯ}
    public void DialogEnd () {
        DialogAniOff.SetActive (false);
        transform.gameObject.SetActive (false);
    }
}