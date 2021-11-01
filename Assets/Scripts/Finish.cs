using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{ 
    public GameObject WinPanel;
    public GameObject P;//Повозка
    public GameObject Star1;//Повозка
    public GameObject Star2;//Повозка
    public GameObject Star3;//Повозка
    public GameObject Star1Ani;//Повозка
    public GameObject Star2Ani;//Повозка
    public GameObject Star3Ani;//Повозка
    public GameObject BonusController;

     private void OnTriggerEnter2D(Collider2D collision)
    { 
        Debug.Log("FFFFFFFF");
        if (collision.gameObject.tag == "Povozka")
        {
            Debug.Log("FFFFFFFF222222");
            WinPanel.SetActive(true);
            Debug.Log("Get_hp_in_procent()="+P.gameObject.GetComponent<PovokZKA>().Get_hp_in_procent());
            if (P.gameObject.GetComponent<PovokZKA>().Get_hp_in_procent() >= 0)
            {
               
                Star1Ani.SetActive(true);
                Invoke("OffStar1Ani", 0.50f);
            }
        }
        Invoke("BonusOn", 1.50f);
    }
    public void OffStar1Ani()
    {
        Star1Ani.SetActive(false);
        Star1.SetActive(true);

        if (P.gameObject.GetComponent<PovokZKA>().Get_hp_in_procent() >= 51)
        {
        
            Star2Ani.SetActive(true);
            Invoke("OffStar2Ani", 0.50f);
        }
    }
    public void OffStar2Ani()
    {
        Star2Ani.SetActive(false);
        Star2.SetActive(true);
        if (P.gameObject.GetComponent<PovokZKA>().Get_hp_in_procent() >= 95)
        {
           
            Star3Ani.SetActive(true);
            Invoke("OffStar3Ani", 0.50f);
        }
    }
    public void OffStar3Ani()
    {
        Star3Ani.SetActive(false);
        Star3.SetActive(true);

       
    }
    public void BonusOn()
    {
        BonusController.gameObject.GetComponent<UI_controller>().Draw_Win();
    }

}
