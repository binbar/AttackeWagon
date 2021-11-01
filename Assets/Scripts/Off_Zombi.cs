using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off_Zombi : MonoBehaviour
{

    public GameObject Random; // Отключаем спавм Зомби
    public Fly_mob_controller FlyMobStop;//ссылка на 
    public GameObject Boss_1;

private void OnTriggerEnter2D(Collider2D collision)
    { 
       if (collision.gameObject.tag == "Povozka")
        {
            Boss_1.SetActive(true);
            Random.SetActive(false);     
           FlyMobStop.CanSpawn=false;//Отключение спавна летающих мобов


        }
    }

}
