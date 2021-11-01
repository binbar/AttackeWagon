using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class FLY_MOB : MonoBehaviour, IPoolable, IDamagable {
    QuestController QuestController_script;
    [Header ("НЕ НАСТРАИВАТЬ ТУТ!!!А В Fly_mob_controller")]
    [SerializeField] float _hp = 100; //Установить в испекторе
    public float _startHP;
    public float speed;

    [SerializeField] private Ui_Hp_Zombi healtBar_Fly_mob;

    public GameObject UP_limit;
    public GameObject DOWN_limit;
    public GameObject STABILIZATION_pos;
    public GameObject FLY_target;

    public int Fall_bomb_damage;
    public Fly_mob_controller Controller_link; //Нужно для подсчета смертей(уменьшения количества)

    public float y_pos;
    public string pos_status;

    [SerializeField] private Balloon _baloon;
    [SerializeField] private Fall_Bomb _bomb;
    private bool _isMoving;
    private void Awake () {
        QuestController_script = GameObject.FindGameObjectWithTag ("Povozka").GetComponent<QuestController> ();
        //   _startHP = _hp;
    }
    private void LivesUI_Fly_mob () //Отрисовать хп у зомби
    {
        healtBar_Fly_mob.SetSize (_hp / _startHP);
        // Debug.Log("LivesUI_Fly_mob");

        //  var value = Mathf.Clamp01(_hp / _startHP);
        //   healtBar_Fly_mob.SetSize(value);
    }

    //Вызываем при получении урона от пули при столкновении
    public void GetDamage (int DMG) {
        _hp -= DMG;
        LivesUI_Fly_mob ();

        if (_hp <= 0) {
            QuestController_script.AddValueToQuest ("Q_FlyMob", 1);

            Kill_mob ();
            PlayerPrefs.SetInt ("Kill_mobs", (PlayerPrefs.GetInt ("Kill_mobs") + PlayerPrefs.GetInt ("Current_opened_level")));

        }
    }

    //При убийстве летающего моба до его долёта до нужной точки
    public void Kill_mob () {

        _isMoving = false;
        CastBomb ();

        Controller_link.NowMobs += -1;

    }

    //При долёте до нужной точки сбрасывает бомбу
    public void CastBomb () {
        //_baloon.gameObject.GetComponent<Fall_Bomb>().Fall_bomb_damage=Fall_bomb_damage;
        _bomb.Fall_bomb_damage = Fall_bomb_damage;
        _baloon.Boom ();
        healtBar_Fly_mob.gameObject.SetActive (false);

    }

    public void MoveTo (Vector3 t_pos, float speed_now) {
        transform.position = Vector3.MoveTowards (transform.position, t_pos, speed_now * Time.deltaTime); //Идем прямо к повозке
    }

    public void New_pos_y () {
        y_pos = Random.Range (DOWN_limit.transform.position.y, UP_limit.transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        if (UP_limit != null && _isMoving) {
            if (pos_status == "go_line") {
                MoveTo (new Vector3 (UP_limit.transform.position.x, y_pos, 0), speed);
                if (transform.position.x < (UP_limit.transform.position.x + 0.1f)) {
                    pos_status = "go_target";
                }

                if (transform.position.y > UP_limit.transform.position.y) //Если выше верхнего лимита 
                {
                    pos_status = "stabilization";
                    New_pos_y ();
                }

                if (transform.position.y < DOWN_limit.transform.position.y) //Если ниже верхнего лимита и правее вертикального лимита
                {
                    pos_status = "stabilization";
                    New_pos_y ();
                }

            }

            if (pos_status == "go_target") {
                MoveTo (FLY_target.transform.position, speed);

                if (transform.position.y > UP_limit.transform.position.y) //Если выше верхнего лимита 
                {
                    pos_status = "stabilization";
                    New_pos_y ();
                }

                if (transform.position.x > (UP_limit.transform.position.x) + 0.2f) //Если правее вертикального лимита
                {
                    pos_status = "stabilization";
                    New_pos_y ();
                }

                if (transform.position.y < DOWN_limit.transform.position.y &&
                    transform.position.x > (UP_limit.transform.position.x)) //Если ниже верхнего лимита и правее вертикального лимита
                {
                    pos_status = "stabilization";
                    New_pos_y ();
                }

                float dist_to_launch_bomb = Vector3.Distance (FLY_target.transform.position, transform.position);
                if (dist_to_launch_bomb < 0.2f) {
                    CastBomb (); //Запускаем бомбу
                }

            }

            if (pos_status == "stabilization") {
                Vector3 STAB_POS = new Vector3 (STABILIZATION_pos.transform.position.x, y_pos, 0);
                float dist = Vector3.Distance (STAB_POS, transform.position);
                if (dist > 0.4f) {
                    MoveTo (STAB_POS, speed);
                } else {
                    pos_status = "go_line";

                }

            }
        }
    }
    public void Despawn () {
        LeanPool.Despawn (this);
    }
    public void OnSpawn () {
        _hp = _startHP;
        LivesUI_Fly_mob ();
        _isMoving = true;

        pos_status = "go_line";

        healtBar_Fly_mob.gameObject.SetActive (true);

        _baloon.Restat ();
        _bomb.Restart ();
    }

    public void OnDespawn () {

    }
}