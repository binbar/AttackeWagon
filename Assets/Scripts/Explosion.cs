using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int Damage; //Урон бомбы
    bool Can_use;
    public GameObject SP_script;
    public GameObject Shop; //Магазин 
    public GameObject Povozka; //Повозка
    public GameObject Explosion_anim_1;
    public GameObject Explosion_anim_2;
    public GameObject Explosion_anim_3;
    public GameObject Explosion_anim_4;

    void Start()
    {
        Debug.Log("ExplosionExplosionExplosionExplosionExplosionExplosionExplosionExplosionExplosionExplosionExplosionExplosionExplosionExplosion");
        Debug.Log("gameObject.transform.name" +gameObject.name);
        Debug.Log("gameObject.transform.tag"+gameObject.transform.tag);
        SP_script = GameObject.FindGameObjectsWithTag("SP_script_tag")[0];
        if (GameObject.FindGameObjectsWithTag("Povozka").Length>0)
        {
            if (GameObject.FindGameObjectsWithTag("Povozka")[0] != null)
            {
                Povozka = GameObject.FindGameObjectsWithTag("Povozka")[0];
            }
            else
            {
                //Повозка уничтожена,нельзя взрывать бомбы
            }
        }

        Can_use = false;
        OnMouseDrag();
    }

    public float distance = 0f;
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        transform.position = objPosition; // и собственно объекту записываються координаты

    }

    void ExplosionDamage(Vector2 center, float radius, float dmg)
    {

        //    Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        //   Debug.Log("Physics.OverlapSphere X=" + center.x + " Y=" + center.y + " Z=" + center.z);

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);

        foreach (Collider2D col in hitColliders)
        {

            //   Debug.Log ("ПЕРЕБОР foreach !!!!!!!!!!");
            if (col.gameObject.tag == "Zombi1")
            {
                //  Debug.Log("Нанесение урона ВЗРЫВОМ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!=");
                //  col.gameObject.GetComponent<Zombi1> ().hp -= dmg;
                //    col.gameObject.GetComponent<Zombi1> ().jizn ();

                col.gameObject.GetComponent<Zombi1>().GetDamage(Damage);
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ZoneBomb") //Если в области вызрыва
        {
            Can_use = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ZoneBomb") //Если вышли из области вызрыва
        {
            Can_use = false;
        }
    }

    void Update()
    {
        OnMouseDrag();

        if (SP_script.gameObject.GetComponent<SpawnBomb>().Hold == false) //
        {
            if (Povozka != null)
            {
                if (Can_use == true)
                {
                    //ТУТ ДОДЕЛАТЬ ОТНИМАНИЕ БОМБ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                    // Бомба и её параметры

                    int id_a = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(SP_script.gameObject.GetComponent<SpawnBomb>().Id_bomb).id_ammo;
                    int id_bomb = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(SP_script.gameObject.GetComponent<SpawnBomb>().Id_bomb).id;
                    int damage_bomb = (int)Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(SP_script.gameObject.GetComponent<SpawnBomb>().Id_bomb).damage;

                    if (PlayerPrefs.GetInt("" + id_a) > 0)
                    { //Если бомб больше 0
                      //  Debug.Log("Взрыв !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        PlayerPrefs.SetInt("" + id_a, (PlayerPrefs.GetInt("" + id_a) - 1));

                      //  ExplosionDamage(new Vector2(this.transform.position.x, this.transform.position.y), 1.8f, damage_bomb);// WORK OLD
                        //     Instantiate (Explosion_anim_1);
                        //   Instantiate(Explosion_anim_1, this.transform.position);
                        // Instantiate (Explosion_anim_1, , Quaternion.identity);

                        if (id_bomb == 12)
                        {
                            ExplosionDamage(new Vector2(this.transform.position.x, this.transform.position.y), 1.8f, damage_bomb);
                            Instantiate(Explosion_anim_1, new Vector3(this.transform.position.x, this.transform.position.y + 1.2f, this.transform.position.z), Quaternion.identity);
                        }
                        if (id_bomb == 13)
                        {
                            ExplosionDamage(new Vector2(this.transform.position.x, this.transform.position.y), 1.8f, damage_bomb);
                            Instantiate(Explosion_anim_2, new Vector3(this.transform.position.x, this.transform.position.y + 1.2f, this.transform.position.z), Quaternion.identity);
                        }
                        if (id_bomb == 14)
                        {
                            ExplosionDamage(new Vector2(this.transform.position.x, this.transform.position.y), 1.8f, damage_bomb);
                            Instantiate(Explosion_anim_3, new Vector3(this.transform.position.x, this.transform.position.y + 1.2f, this.transform.position.z), Quaternion.identity);
                        }
                        if (id_bomb == 15)
                        {
                            ExplosionDamage(new Vector2(this.transform.position.x, this.transform.position.y), 1.8f, damage_bomb);
                            Instantiate(Explosion_anim_4, new Vector3(this.transform.position.x, this.transform.position.y + 2.2f, this.transform.position.z), Quaternion.identity);
                        }

                        Povozka.gameObject.GetComponent<PovokZKA>().UI_ammo_boom(); //Обновить интерфейс бомб

                    }
                    else
                    {
                        //   Debug.Log("Не достаточно бомб");
                    }

                    SP_script.gameObject.GetComponent<SpawnBomb>().In_hand = false;

                    Destroy(gameObject); //Удаление бомбы после вызрыва
                }
                else
                {
                    //  Debug.Log("Взрыва нет,бомба не была в области взрыва");

                    SP_script.gameObject.GetComponent<SpawnBomb>().In_hand = false;
                    Destroy(gameObject); //Удаление бомбы если не в области возможного взрыва
                }
            }
            else
            {
                //  Debug.Log("Повозка уничтожена,нельзя взрывать бомбы");
            }

        }
        else
        {
            //  Debug.Log("ЛКМ ОТЖАТА!!!!!!!!!!!!!!!!!!!");
        }

    }
}