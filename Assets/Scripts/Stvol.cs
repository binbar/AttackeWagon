using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class Stvol : MonoBehaviour {
    public Dialog Dialog_controller;

    public float offset;
    public GameObject bulletPrefab; // Пуля

    public Transform shotDir; // Прицел(откуда берутся пули)
    //! c Анимациями та же беда что и с у зобей 
    public GameObject Ob_Stvolka_Idle;
    public GameObject Ob_Stvolka_Shoot;
    public GameObject Ob_Stvolka_Rel;

    public GameObject Ob_Drobovik_Idle;
    public GameObject Ob_Drobovik_Shoot;
    public GameObject Ob_Drobovik_Rel;

    public GameObject Ob_A2Stvola_Idle;
    public GameObject Ob_A2Stvola_Shoot;
    public GameObject Ob_A2Stvola_Rel;

    public GameObject Ob_Sniper_Idle;
    public GameObject Ob_Sniper_Shoot;
    public GameObject Ob_Sniper_Rel;

    public GameObject Ob_Ak47_Idle;
    public GameObject Ob_Ak47_Shoot;
    public GameObject Ob_Ak47_Rel;

    public GameObject Ob_Bazuka_Idle;
    public GameObject Ob_Bazuka_Shoot;
    public GameObject Ob_Bazuka_Rel;

    public int numberBullet = 2;
    private float timeShot;

    public float AttackSpeed; //Скорость стрельбы
    public int id_weapon; //Ид текущего оружия
    public int id_bullet; //Ид текущих патронов
    public int Damage_weapon; //Урон оружия
    //? Повозка
    [SerializeField] private PovokZKA _povozka;

    public CameraController CameraController_script;

    private State currentState;

    void Start () {
        CameraController_script = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraController> ();
    }

    public void Start_id_Weapon () {
        if (id_weapon == 0) {
            SetState (State.Stvolka_Idle);

        }
        if (id_weapon == 1) {

            SetState (State.Drobovik_Idle);
        }
        if (id_weapon == 2) {
            SetState (State.A2Stvola_Idle);

        }
        if (id_weapon == 3) {
            SetState (State.Sniper_Idle);

        }
        if (id_weapon == 4) {
            SetState (State.Ak47_Idle);

        }
        if (id_weapon == 5) {
            SetState (State.Bazuka_Idle);

        }
    }

    public void Shoot_Button () {

        //----------------<Начало Weapon_id_0>------------
        if (id_weapon == 0) {

            if (timeShot <= 0 && currentState == State.Stvolka_Idle) {
                string id_bullet_key = $"{id_bullet}";
                int ammoCount = PlayerPrefs.GetInt (id_bullet_key);

                if (ammoCount > 0) { //Если патроновы больше чем 0 то происходит выстрел
                    Debug.Log ("ВЫСТРЕЛ");
                    CameraController_script.ShakeCamera (-0.125f, 0.125f);

                    //  bulletPrefab.gameObject.GetComponent<Bullet>().AudioEffectOn();
                    //_povozka.transform.GetChild(0).gameObject.GetComponent<Bullet>().

                    _povozka.Clip_use (id_weapon); //Изменение обоймы(отнимаем патрон)
                    SetState (State.Stvolka_Shoot);
                    Invoke ("Fu_Stvolka_Rel", 0.40f); // Через 0.1 секунду вызвется функция HideFlash которая выключит вспышку,

                    Bullet bullet = InstatiateBulletByMousePosition ();
                    bullet.Damage = Damage_weapon; //Устанавливаем урон
                    timeShot = AttackSpeed;

                    //Отнимаем патроны
                    ammoCount--;
                    PlayerPrefs.SetInt (id_bullet_key, ammoCount);

                    _povozka.UI_ammo_weapon (); //Отрисовываем патроны

                } else {
                    // Debug.Log ("Нет патронов");
                    Dialog_controller.Start_dialog ();
                }
            }
        }
        //----------------<Конец Weapon_id_0>-------------
        //----------------<Начало Weapon_id_1>------------
        if (id_weapon == 1) {

            if (timeShot <= 0 && currentState == State.Drobovik_Idle) {

                if (PlayerPrefs.GetInt ("" + id_bullet) > 0) { //Если патроновы больше чем 0 то происходит выстрел
                    CameraController_script.ShakeCamera (-0.1f, 0.1f);

                    _povozka.Clip_use (id_weapon); //Изменение обоймы(отнимаем патрон)

                    SetState (State.Drobovik_Shoot);
                    Invoke ("Fu_Drobovik_Rel", 0.40f); // Через 0.1 секунду вызвется функция HideFlash которая выключит вспышку,

                    //Самая верхняя пуля
                    Bullet bullet2 = InstatiateBulletByMousePosition_special (0.15f, 1.5f); //1-й параметр это высота,второй это угол("дополнительный градус") наклона
                    bullet2.Damage = Damage_weapon; //Устанавливаем урон
                    bullet2.destroyTime = 0.4f;

                    //Верхняя пуля
                    Bullet bullet1 = InstatiateBulletByMousePosition_special (0.1f, 1f); //1-й параметр это высота,второй это угол("дополнительный градус") наклона
                    bullet1.Damage = Damage_weapon; //Устанавливаем урон
                    bullet1.destroyTime = 0.45f;

                    //Центральная пуля
                    Bullet bullet = InstatiateBulletByMousePosition (); //1-й параметр это высота,второй это угол("дополнительный градус") наклона
                    bullet.Damage = Damage_weapon; //Устанавливаем урон
                    bullet.destroyTime = 0.40f;

                    //Нижняя пуля
                    Bullet bullet_1 = InstatiateBulletByMousePosition_special (-0.1f, -0.5f); //1-й параметр это высота,второй это угол("дополнительный градус") наклона
                    bullet_1.Damage = Damage_weapon; //Устанавливаем урон
                    bullet_1.destroyTime = 0.35f;

                    //Самая нижняя пуля
                    Bullet bullet_2 = InstatiateBulletByMousePosition_special (-0.15f, -1f); //1-й параметр это высота,второй это угол("дополнительный градус") наклона
                    bullet_2.Damage = Damage_weapon; //Устанавливаем урон
                    bullet_2.destroyTime = 0.4f;

                    timeShot = AttackSpeed;
                    numberBullet--;

                    PlayerPrefs.SetInt ("" + id_bullet, PlayerPrefs.GetInt ("" + id_bullet) - 1); //Отнимаем патроны
                    _povozka.UI_ammo_weapon (); //Отрисовываем патроны

                } else {
                    //    Debug.Log ("Нет патронов");
                    Dialog_controller.Start_dialog ();
                }
            }

        }
        //----------------<Конец Weapon_id_1>-------------
        //----------------<Начало Weapon_id_2>------------
        if (id_weapon == 2) {

            if (timeShot <= 0 && currentState == State.A2Stvola_Idle) {

                if (PlayerPrefs.GetInt ("" + id_bullet) > 0) { //Если патроновы больше чем 0 то происходит выстрел
                    CameraController_script.ShakeCamera (-0.07f, 0.07f);

                    _povozka.Clip_use (id_weapon); //Изменение обоймы(отнимаем патрон)

                    SetState (State.A2Stvola_Shoot);
                    Invoke ("Fu_A2Stvola_Rel", 0.45f); // Через 0.1 секунду вызвется функция HideFlash которая выключит вспышку,

                    Weapon_revolver_shoot ();
                    Invoke ("Weapon_revolver_shoot", 0.2f); //

                    //   Bullet bullet = InstatiateBulletByMousePosition ();
                    //   bullet.Damage = Damage_weapon; //Устанавливаем урон

                    timeShot = AttackSpeed;
                    numberBullet--;

                    PlayerPrefs.SetInt ("" + id_bullet, PlayerPrefs.GetInt ("" + id_bullet) - 1); //Отнимаем патроны
                    _povozka.UI_ammo_weapon (); //Отрисовываем патроны

                } else {
                    //   Debug.Log ("Нет патронов");
                    Dialog_controller.Start_dialog ();
                }
            }
        }
        //----------------<Конец Weapon_id_2>-------------
        //----------------<Начало Weapon_id_3>------------
        if (id_weapon == 3) {

            if (timeShot <= 0 && currentState == State.Sniper_Idle) {

                if (PlayerPrefs.GetInt ("" + id_bullet) > 0) { //Если патроновы больше чем 0 то происходит выстрел
                    CameraController_script.ShakeCamera (-0.13f, 0.13f);

                    _povozka.Clip_use (id_weapon); //Изменение обоймы(отнимаем патрон)
                    SetState (State.Sniper_Shoot);
                    Invoke ("Fu_Sniper_Rel", 0.45f); // Через 0.1 секунду вызвется функция HideFlash которая выключит вспышку,

                    Bullet bullet = InstatiateBulletByMousePosition ();
                    bullet.Damage = Damage_weapon; //Устанавливаем урон
                    timeShot = AttackSpeed;
                    numberBullet--;

                    PlayerPrefs.SetInt ("" + id_bullet, PlayerPrefs.GetInt ("" + id_bullet) - 1); //Отнимаем патроны
                    _povozka.UI_ammo_weapon (); //Отрисовываем патроны

                } else {
                    //  Debug.Log ("Нет патронов");
                    Dialog_controller.Start_dialog ();
                }
            }
        }
        //----------------<Конец Weapon_id_3>-------------
        //----------------<Начало Weapon_id_4>------------
        if (id_weapon == 4) {

            if (timeShot <= 0 && currentState == State.Ak47_Idle) {

                if (PlayerPrefs.GetInt ("" + id_bullet) > 0) { //Если патроновы больше чем 0 то происходит выстрел
                    CameraController_script.ShakeCamera (-0.07f, 0.07f);

                    _povozka.Clip_use (id_weapon); //Изменение обоймы(отнимаем патрон)
                    SetState (State.Ak47_Shoot);
                    Invoke ("Fu_Ak47_Rel", 0.20f); //
                    Bullet bullet = InstatiateBulletByMousePosition ();
                    bullet.Damage = Damage_weapon; //Устанавливаем урон
                    timeShot = AttackSpeed;
                    numberBullet--;

                    PlayerPrefs.SetInt ("" + id_bullet, PlayerPrefs.GetInt ("" + id_bullet) - 1); //Отнимаем патроны
                    _povozka.UI_ammo_weapon (); //Отрисовываем патроны

                } else {
                    // Debug.Log ("Нет патронов");
                    Dialog_controller.Start_dialog ();
                }
            }
        }
        //--------------------<Конец Weapon_id_4>--------------------
        //----------------<Начало Weapon_id_5>------------
        if (id_weapon == 5) {

            if (timeShot <= 0 && currentState == State.Bazuka_Idle) {

                if (PlayerPrefs.GetInt ("" + id_bullet) > 0) { //Если патроновы больше чем 0 то происходит выстрел
                    CameraController_script.ShakeCamera (-0.139f, 0.139f);

                    _povozka.Clip_use (id_weapon); //Изменение обоймы(отнимаем патрон)

                    SetState (State.Bazuka_Shoot);
                    Invoke ("Fu_Bazuka_Rel", 0.45f); // Через 0.1 секунду вызвется функция HideFlash которая выключит вспышку,

                    Bullet bullet = InstatiateBulletByMousePosition ();
                    bullet.Damage = Damage_weapon; //Устанавливаем урон
                    timeShot = AttackSpeed;
                    numberBullet--;

                    PlayerPrefs.SetInt ("" + id_bullet, PlayerPrefs.GetInt ("" + id_bullet) - 1); //Отнимаем патроны
                    _povozka.UI_ammo_weapon (); //Отрисовываем патроны

                } else {
                    // Debug.Log ("Нет патронов");
                    Dialog_controller.Start_dialog ();
                }
            }
        }
        //----------------<Конец Weapon_id_5>-------------

    } //Конец Update.

    private Bullet InstatiateBulletByMousePosition () {
        Vector3 pos = new Vector3 (shotDir.position.x, shotDir.position.y, 0);
        Vector3 m = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Vector3 mouse = new Vector3 (m.x, m.y, 0);
        Vector3 dir = mouse - pos;

        float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion rotation_bullet = Quaternion.AngleAxis (angle, Vector3.forward);

        GameObject bulletInstance = LeanPool.Spawn (bulletPrefab, shotDir.position, rotation_bullet);

        Bullet bullet = bulletInstance.GetComponent<Bullet> ();
        return bullet;
    }

    private Bullet InstatiateBulletByMousePosition_special (float y_pos, float y_coeficient) {
        Vector3 pos = new Vector3 (shotDir.position.x, shotDir.position.y, 0);
        Vector3 m = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Vector3 mouse = new Vector3 (m.x, m.y + y_coeficient, 0);
        Vector3 dir = mouse - pos;

        float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation_bullet = Quaternion.AngleAxis (angle, Vector3.forward);

        GameObject bulletInctance = LeanPool.Spawn (bulletPrefab, new Vector3 (shotDir.position.x, shotDir.position.y + y_pos, shotDir.position.z), rotation_bullet);

        Bullet bullet = bulletInctance.GetComponent<Bullet> ();
        return bullet;
    }

    void Weapon_revolver_shoot () {
        Bullet bullet = InstatiateBulletByMousePosition ();
        bullet.Damage = Damage_weapon; //Устанавливаем урон
        bullet.destroyTime = 1f;
    }

    //--------------------<Функция перезарядки и добавление патрон Weapon_id_0>--------

    void Update () {
        timeShot -= Time.deltaTime;
    }
    public void Fu_Stvolka_Shoot () {
        //Делаем перезарядку и активируем анимацию покоя
        _povozka.Clip_reload (id_weapon);
        SetState (State.Stvolka_Idle);
    }
    public void Fu_Stvolka_Rel () {
        if (_povozka.Clip_check (id_weapon) && _povozka.Weapon_clip[id_weapon] <= 0) { //Если потрон нет, то активировать анимацию перезарядки
            SetState (State.Stvolka_Rel);
            Invoke ("Fu_Stvolka_Shoot", 1.0f);
        } else {
            SetState (State.Stvolka_Idle);
        }
    }
    //-------------------<Конец функции перезарядки и добавление патрон Weapon_id_0>--------

    //--------------------<Функция перезарядки и добавление патрон Weapon_id_1>--------
    public void Fu_Drobovik_Shoot () {
        //Делаем перезарядку и активируем анимацию покоя

        _povozka.Clip_reload (id_weapon);
        SetState (State.Drobovik_Idle);
    }
    public void Fu_Drobovik_Rel () {
        if (_povozka.Clip_check (id_weapon) && _povozka.Weapon_clip[id_weapon] <= 0) { //Если потрон нет, то активировать анимацию перезарядки

            SetState (State.Drobovik_Rel);
            Invoke ("Fu_Drobovik_Shoot", 1.3f);
        } else {
            SetState (State.Drobovik_Idle);
        }
    }
    //-------------------<Конец функции перезарядки и добавление патрон Weapon_id_1>--------

    //--------------------<Функция перезарядки и добавление патрон Weapon_id_2>--------
    public void Fu_A2Stvola_Shoot () {
        //Делаем перезарядку и активируем анимацию покоя

        _povozka.Clip_reload (id_weapon);
        SetState (State.A2Stvola_Idle);
    }
    public void Fu_A2Stvola_Rel () {
        if (_povozka.Clip_check (id_weapon) && _povozka.Weapon_clip[id_weapon] <= 0) { //Если потрон нет, то активировать анимацию перезарядки

            SetState (State.A2Stvola_Rel);
            Invoke ("Fu_A2Stvola_Shoot", 1.3f);
        } else {
            SetState (State.A2Stvola_Idle);
        }
    }
    //-------------------<Конец функции перезарядки и добавление патрон Weapon_id_2>--------

    //--------------------<Функция перезарядки и добавление патрон Weapon_id_3>--------
    public void Fu_Sniper_Shoot () {
        //Делаем перезарядку и активируем анимацию покоя

        _povozka.Clip_reload (id_weapon);
        SetState (State.Sniper_Idle);
    }
    public void Fu_Sniper_Rel () {
        Debug.Log ("Fu_Sniper_Rel=" + id_weapon);

        if (_povozka.Clip_check (id_weapon) && _povozka.Weapon_clip[id_weapon] <= 0) { //Если потрон нет, то активировать анимацию перезарядки

            SetState (State.Sniper_Rel);
            Invoke ("Fu_Sniper_Shoot", 1.3f);
        } else {
            SetState (State.Sniper_Idle);
        }
    }
    //-------------------<Конец функции перезарядки и добавление патрон Weapon_id_3>--------

    //--------------------<Функция перезарядки и добавление патрон Weapon_id_4>--------
    public void Fu_Ak47_Shoot () {
        //Делаем перезарядку и активируем анимацию покоя
        _povozka.Clip_reload (id_weapon);

        SetState (State.Ak47_Idle);
    }
    public void Fu_Ak47_Rel () {

        if (_povozka.Clip_check (id_weapon) && _povozka.Weapon_clip[id_weapon] <= 0) { //Если потрон нет, то активировать анимацию перезарядки

            SetState (State.Ak47_Rel);
            Invoke ("Fu_Ak47_Shoot", 1f);
        } else {
            SetState (State.Ak47_Idle);
        }
    }
    //-------------------<Конец функции перезарядки и добавление патрон Weapon_id_4>--------

    //--------------------<Функция перезарядки и добавление патрон Weapon_id_5>--------
    public void Fu_Bazuka_Shoot () {
        //Делаем перезарядку и активируем анимацию покоя
        _povozka.Clip_reload (id_weapon);

        SetState (State.Bazuka_Idle);
    }
    public void Fu_Bazuka_Rel () {
        if (_povozka.Clip_check (id_weapon) && _povozka.Weapon_clip[id_weapon] <= 0) { //Если потрон нет, то активировать анимацию перезарядки

            SetState (State.Bazuka_Rel);
            Invoke ("Fu_Bazuka_Shoot", 1.3f);
        } else {
            SetState (State.Bazuka_Idle);
        }
    }
    //-------------------<Конец функции перезарядки и добавление патрон Weapon_id_5>--------

    public void SetState (State state) {
        currentState = state;
        Ob_Stvolka_Idle.SetActive (state == State.Stvolka_Idle);
        Ob_Stvolka_Rel.SetActive (state == State.Stvolka_Rel);
        Ob_Stvolka_Shoot.SetActive (state == State.Stvolka_Shoot);

        Ob_Drobovik_Idle.SetActive (state == State.Drobovik_Idle);
        Ob_Drobovik_Rel.SetActive (state == State.Drobovik_Rel);
        Ob_Drobovik_Shoot.SetActive (state == State.Drobovik_Shoot);

        Ob_A2Stvola_Idle.SetActive (state == State.A2Stvola_Idle);
        Ob_A2Stvola_Rel.SetActive (state == State.A2Stvola_Rel);
        Ob_A2Stvola_Shoot.SetActive (state == State.A2Stvola_Shoot);

        Ob_Sniper_Idle.SetActive (state == State.Sniper_Idle);
        Ob_Sniper_Rel.SetActive (state == State.Sniper_Rel);
        Ob_Sniper_Shoot.SetActive (state == State.Sniper_Shoot);

        Ob_Ak47_Idle.SetActive (state == State.Ak47_Idle);
        Ob_Ak47_Rel.SetActive (state == State.Ak47_Rel);
        Ob_Ak47_Shoot.SetActive (state == State.Ak47_Shoot);

        Ob_Bazuka_Idle.SetActive (state == State.Bazuka_Idle);
        Ob_Bazuka_Rel.SetActive (state == State.Bazuka_Rel);
        Ob_Bazuka_Shoot.SetActive (state == State.Bazuka_Shoot);
    }

    public enum State {
        Stvolka_Idle,
        Stvolka_Rel,
        Stvolka_Shoot,
        Drobovik_Idle,
        Drobovik_Rel,
        Drobovik_Shoot,
        A2Stvola_Idle,
        A2Stvola_Rel,
        A2Stvola_Shoot,
        Sniper_Idle,
        Sniper_Rel,
        Sniper_Shoot,
        Ak47_Idle,
        Ak47_Rel,
        Ak47_Shoot,
        Bazuka_Idle,
        Bazuka_Rel,
        Bazuka_Shoot
    }
}