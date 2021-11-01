using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
public class Fly_mob_controller : MonoBehaviour {

    [Header ("Настройки спавна летающих мобов")]
    public int LimitMobs; //Ограничение одновременно находящихся летающих мобов
    public float SpawnRate; //Переодичность спавна мобов(2f=спавн каждых 2 секунды)
    public float StartSpawnAt; //Начать спавнить через указанное время от начала игры 
    public int HP_mob; //Хп мобов
    public float SPEED_mob; //Скорость перемещения мобов
    public int BOMB_damage; //Урон бомбы

    public GameObject FLY_SPAWN;

    public GameObject UP_limit;
    public GameObject DOWN_limit;
    public GameObject STABILIZATION_pos;
    public GameObject FLY_target;
    //? FlyMob prefab
    [SerializeField] private FLY_MOB _prefab;

    public int NowMobs; //Не трогать
    public bool CanSpawn;
    void Start () {
        NowMobs = 0;
        CanSpawn = true;
        InvokeRepeating ("Spawn_fly_mob", StartSpawnAt, SpawnRate);
    }

    public void Spawn_fly_mob () {
        Debug.Log ("CanSpawn=" + CanSpawn + " UP_limit=" + UP_limit + " NowMobs=" + NowMobs + " LimitMobs+" + LimitMobs);

        if (CanSpawn == true) {
            if (UP_limit != null) {
                if (NowMobs < LimitMobs) {

                    float y_pos = Random.Range (DOWN_limit.transform.position.y, UP_limit.transform.position.y);
                    Vector3 pos_fly_mob = new Vector3 (FLY_SPAWN.transform.position.x, y_pos, 0);

                    //? mobInstance  - Экземпляр моба
                    var mobInstance = LeanPool.Spawn<FLY_MOB> (_prefab, pos_fly_mob, Quaternion.identity);
                    SetParametrs (mobInstance, y_pos);
                    NowMobs++;
                }

            }
        }
    }

    public void SetParametrs (FLY_MOB mob, float set_y_pos) {
        mob.UP_limit = UP_limit;
        mob.DOWN_limit = DOWN_limit;
        mob.STABILIZATION_pos = STABILIZATION_pos;
        mob.FLY_target = FLY_target;
        mob.Controller_link = this;

        mob.speed = SPEED_mob;
        mob.y_pos = set_y_pos;
        mob._startHP = HP_mob;
        mob.Fall_bomb_damage = BOMB_damage;
    }
}