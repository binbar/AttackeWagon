using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject Bomb;
    public PovokZKA Povozka;
    public GameObject Shop;

    public bool In_hand;
    public bool Hold; //True держим бомбу,False отпускаем
    public int Id_bomb;
    public static string Install_shop;
    void Start()
    {
        In_hand = false;
        Hold = true;
        /*
        if (Install_shop != "yes")
        {
            Shop = Instantiate(Resources.Load("ShopPanel", typeof(GameObject))) as GameObject;
            Install_shop = "yes";
        }
        */
        //      Shop.tag="SHOP_TAG_SpawnBomb";

        if (GameObject.FindGameObjectsWithTag("SHOP_TAG_SpawnBomb").Length < 1)
        {
            Shop = Instantiate(Resources.Load("ShopPanel", typeof(GameObject))) as GameObject;
            Shop.tag="SHOP_TAG_SpawnBomb";
        }


    }

    public void Hold_off() //Отпустить бомбу
    {
        Hold = false;
    }




    public void CreateBomb(int id) //Создать бомбу
    {
        if (In_hand == false)
        {
            Hold = true;
            Id_bomb = Int32.Parse(Povozka.Slots_bombs[id]);

            int Damage_bomb = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Id_bomb).damage;
            Bomb.gameObject.GetComponent<Explosion>().Damage = Damage_bomb;
            Instantiate(Bomb);

            In_hand = true;
        }
        else
        {
            Debug.Log("Бомба уже взята");
        }

        //Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f))
    }

    // Update is called once per frame
    void Update()
    {

    }
}