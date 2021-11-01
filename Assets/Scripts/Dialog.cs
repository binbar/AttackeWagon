using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public Transform Canvas;
    public GameObject Pos_in_world; //Позиция в мире (место появления диалога в мире(НЕ В КАНВАСЕ))
    public DialogManager Dialog_Manager;
    bool Dialog_status; //True диалог идёт,False диалог не идёт и может быть вызван

    void Start()
    {
        Dialog_status = false;
    }

    public void Start_dialog()
    {
        if (Dialog_status == false)
        { //Если диалог неактивен
            Dialog_status = true;
            Dialog_Manager.gameObject.SetActive(true); //Активация обьекта
            Dialog_Manager.Text_dialog = "Нет патронов!!!"; //Установить текст
            Invoke("EndDialog", 5f); //Закончить диалог
        }
    }

    public void EndDialog()
    {
        Dialog_status = false;
    }

    //Установить позицию диалога
    void Dailog_set_pos()
    {
        Vector3 pos_screen = Camera.main.WorldToScreenPoint(Pos_in_world.transform.position);
        Dialog_Manager.transform.position = pos_screen;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialog_status)
        {
            Dailog_set_pos();
        }
    }

}