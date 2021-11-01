using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PovokZKA : MonoBehaviour, IDamagable
{

    public Start_shot Start_shot_script;
    public UPGRADE_controller upg_c;

    public float speed; //Скорость сейчас
    public float speed_default; //Стандартная скорость + улучшения

    public bool second = false;
    public int lives; //ХП,в инспекторе не указывать,загружка из улучшения в старте
    public int lives_max; //ХП,в инспекторе не указывать,загружка из улучшения в старте
    public GameObject camera_main; //камера
    // public GameObject Chunkpovozka;
    //public GameObject _chunkpovozka; // генерация земли
    public GameObject health; // жизнь
    public GameObject health_bar; // Хп бар

    public GameObject raycast;
    public RayHorse rayHorse;
    public Naezdnik naezdnik;
    public GameObject Gameover;
    public GameObject ControllerBonus;
    public ControllerAni controllerAni;
    public GameObject Animation_weapon; //Анимация оружия

    public GameObject Horse_Ilde; //Состояние покоя
    public GameObject Horse_Walk; //Движение
    public GameObject Horse_Run; //Ускоренное движение
    public State currentState;

    public GameObject Shop; //Магазин 
    public GameObject Upgrade; //Улучшения персонажа,повозки,коня и т.д. 

    public GameObject Stvol; //Оружие
    [Header("Картинки оружия и бомбы")]
    public GameObject[] Inv_images; //Картинки слотов инвентаря в игре
    public GameObject[] Inv_images_bombs; //Картинки слотов инвентаря бомб в игре
    public Sprite EMPTY; //Пустой слот инвентаря
    public Sprite NOT_BUY; //Заблокированный слот инвентаря

    public bool Move;

    public GameObject[] Points = new GameObject[3];

    public string[] Slots;
    public string[] Slots_bombs;
    public Dictionary<int, int> Weapon_clip = new Dictionary<int, int>(); //Обоймы всех оружий

    public bool Removing_log_process;

    public int Get_hp_in_procent()
    {
        if (lives_max > 0)
        {
            Debug.Log("Get_hp_in_procent()________");
            Debug.Log("lives=" + lives);
            Debug.Log("lives_max=" + lives_max);
            Debug.Log("(lives / (lives_max / 100)=" + ((int)((float)lives / ((float)lives_max / (float)100))));
            //    return (lives / (lives_max / 100));
            return ((int)((float)lives / ((float)lives_max / (float)100)));
        }
        else
        {
            return 0;
        }
    }

    public void Clip_use(int id_weapon)
    {
        // Debug.Log ("Clip_use(" + id_weapon + ");");
        if (Weapon_clip.ContainsKey(id_weapon))
        { //Если есть ид оружия 
            if (Weapon_clip[id_weapon] > 0)
            { //Если в обойме патронов больше 0
                Weapon_clip[id_weapon] = Weapon_clip[id_weapon] - 1;
            }
            else
            {
                /*
                int id_a = Shop.gameObject.GetComponent<Shop> ().Get_weapon_by_id (id_weapon).id_ammo;

                if (PlayerPrefs.GetInt ("" + id_a) >= Shop.gameObject.GetComponent<Shop> ().Get_weapon_by_id (id_weapon).clip_size) {
                    Weapon_clip[id_weapon] = Shop.gameObject.GetComponent<Shop> ().Get_weapon_by_id (id_weapon).clip_size;
                } else {
                    Weapon_clip[id_weapon] = PlayerPrefs.GetInt ("" + id_a);
                }
                */
            }

        }
        else
        {
            // Debug.Log ("Weapon_clip.Add");
            Weapon_clip.Add(id_weapon, Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(id_weapon).clip_size);
        }
    }

    public void Clip_reload(int id_weapon)
    {
        //   Debug.Log ("Clip_reload()");
        if (Weapon_clip[id_weapon] <= 0)
        {
            //   Debug.Log ("Weapon_clip[id_weapon] <= 0");

            int id_a = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(id_weapon).id_ammo;

            if (PlayerPrefs.GetInt("" + id_a) >= Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(id_weapon).clip_size)
            {
                Weapon_clip[id_weapon] = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(id_weapon).clip_size;
                //   Debug.Log ("clip_size");
            }
            else
            {
                //    Debug.Log ("id_a");
                Weapon_clip[id_weapon] = PlayerPrefs.GetInt("" + id_a);
            }
        }
        UI_ammo_weapon();
    }

    public bool Clip_check(int id_weapon)
    {
        // Debug.Log ("Clip_use(" + id_weapon + ");");
        if (Weapon_clip.ContainsKey(id_weapon))
        { //Если есть ид оружия 
            //    Clip_reload (id_weapon);
            return true;
        }
        else
        {
            //    Debug.Log ("Clip_check Weapon_clip.Add");
            Weapon_clip.Add(id_weapon, Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(id_weapon).clip_size);
            return false;
        }
    }

    void Load_inv_weapons()
    { //Загрузка инвентаря оружия
        Slots = new string[4]; //Установка размера инвентаря оружия
        Slots_bombs = new string[4]; //Установка размера инвентаря бомб

        PlayerPrefs.SetInt("Slots_weapon", 4); // Устаноливаем сколько слотов в начале игры открыто.

        for (int i = 0; i < Slots.Length; i++)
        { //Делаем все слоты оружия не куплеными
            Slots[i] = "NOT_BUY";
        }

        for (int i = 0; i < Slots_bombs.Length; i++) //Делаем все слоты бомб не куплеными
        {
            Slots_bombs[i] = "NOT_BUY";
        }

        int Slots_weapon_count = PlayerPrefs.GetInt("Slots_weapon"); //Загружаем количество купленых слотов оружия

        for (int i = 0; i < Slots.Length && i < Slots_weapon_count; i++) //Делаем все слоты оружия пустыми
        {
            Slots[i] = "EMPTY";
        }

        for (int i = 0; i < Slots_bombs.Length; i++) //Делаем все слоты бомб пустыми
        {
            Slots_bombs[i] = "EMPTY";
        }

        for (int i = 0; i < Slots.Length;) //Загрузка содержимого(предметов) инвентаря оружия
        {

            string SW_check = PlayerPrefs.GetString("SW_" + i);

            if (SW_check != "")
            { //Если слот сохраненного инвентаря не пустой

                if (Slots[i] == "EMPTY")
                { //Если слот пустой
                    Slots[i] = "" + SW_check; //Установить в слот инвентаря
                    //    Debug.Log ("Установлено[ОРУЖИЕ] в слот " + i + " инвентарь ID:" + SW_check);
                }
            }

            i++;
        }

        for (int i = 0; i < Slots_bombs.Length;) //Загрузка содержимого(предметов) инвентаря бомб
        {
            string SB_check = PlayerPrefs.GetString("SB_" + i);

            if (SB_check != "")
            { //Если слот сохраненного инвентаря не пустой

                if (Slots_bombs[i] == "EMPTY")
                { //Если слот пустой
                    Slots_bombs[i] = "" + SB_check; //Установить в слот инвентаря

                }
            }

            i++;
        }

        foreach (var item in Slots)
        {

        }
        Clip_install();

        foreach (var item in Slots_bombs)
        {

        }

        for (int i = 0; i < Slots.Length; i++)
        { //Установка картинок [ОРУЖИЕ]
            if (Slots[i] != "EMPTY" && Slots[i] != "NOT_BUY")
            { //Если слот не "пустой" или не "не куплен" то устанавливаем картинку

                Inv_images[i].GetComponent<Image>().sprite = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Int32.Parse(Slots[i])).Weapon_img; //Взять картинку из предмета 
                UI_ammo_weapon();

            }
            else if (Slots[i] == "EMPTY")
            { //Если нет предмета то сделать пустую картинку
                Inv_images[i].GetComponent<Image>().sprite = EMPTY; //Картинка пустого слота
            }
            else if (Slots[i] == "NOT_BUY")
            {
                Inv_images[i].GetComponent<Image>().sprite = NOT_BUY; //Картинка не купленного слота
            }
        }

        for (int i = 0; i < Slots_bombs.Length; i++) //Установка картинок [БОМБЫ]
        {
            if (Slots_bombs[i] != "EMPTY" && Slots_bombs[i] != "NOT_BUY")
            { //Если слот не "пустой" или не "не куплен" то устанавливаем картинку

                Inv_images_bombs[i].GetComponent<Image>().sprite = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Int32.Parse(Slots_bombs[i])).Weapon_img; //Взять картинку из предмета 
                UI_ammo_boom();

            }
            else
            {
                Inv_images_bombs[i].SetActive(false);
            }

        }

    }

    public void Install_data()
    { //Загрузка улучшений оружия и персонажа(повозки и т.д.)
        Shop.gameObject.GetComponent<Shop>().Load_container(); //Загрузка контейнера оружия
        Shop.gameObject.GetComponent<Shop>().Weapon_install(); //Загрузка оружия
        Upgrade.gameObject.GetComponent<Upgrade>().Load_container();
    }

    public void Clip_install()
    { //Загрузка обойм
        foreach (string Slot_weapon in Slots)
        {
            if (Slot_weapon != "EMPTY" && Slot_weapon != "NOT_BUY")
            {
                Weapon_clip.Add(Int32.Parse(Slot_weapon), 0);

                int id_a = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Int32.Parse(Slot_weapon)).id_ammo;
                int ammo = PlayerPrefs.GetInt("" + id_a); //Количество патронов

                if (ammo >= Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Int32.Parse(Slot_weapon)).clip_size)
                { //Если патронов больше чем максимальный размер обоймы 
                    Weapon_clip[Int32.Parse(Slot_weapon)] = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Int32.Parse(Slot_weapon)).clip_size;
                }
                else
                {
                    Weapon_clip[Int32.Parse(Slot_weapon)] = ammo;
                }

            }
        }
    }

    //   public void OnShoot () { //При выстреле
    //
    //       UI_ammo_weapon (); //Обновить патроны оружия
    //    }

    public void OnBoom()
    { //При использовании взрывчатки

        UI_ammo_boom(); //Обновить снаряды (патроны) взрывчатки
    }

    public void UI_ammo_weapon()
    { //Обновить патроны оружия

        for (int i = 0; i < Slots.Length; i++)
        { //Перебор всего инвентаря 
            if (Slots[i] != "EMPTY" && Slots[i] != "NOT_BUY")
            {
                int id_a = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Int32.Parse(Slots[i])).id_ammo;
                //  Inv_images[i].gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + PlayerPrefs.GetInt ("" + id_a); //Количество патронов
                int s_o = PlayerPrefs.GetInt("" + id_a); //Количество патронов сохраненное 
                int m_o = Shop.gameObject.GetComponent<Shop>().Get_weapon_by_id(Int32.Parse(Slots[i])).clip_size; //Максимальная ообйма
                int n_o = Weapon_clip[Int32.Parse(Slots[i])]; //Текущая ообйма
                Inv_images[i].gameObject.transform.GetChild(1).GetComponent<Text>().text = "" + n_o;
                Inv_images[i].gameObject.transform.GetChild(0).GetComponent<Text>().text = "" + ((s_o - m_o) + (m_o - n_o)); //Обойма и количество патронов в UI

            }
        }

    }

    public void UI_ammo_boom()
    {
        //Обновить снаряды (патроны) взрывчатки
        for (int i = 0; i < Slots_bombs.Length; i++)
        {
            //Перебор всего инвентаря 
            if (Slots_bombs[i] != "EMPTY" && Slots_bombs[i] != "NOT_BUY")
            {
                Shop shop = Shop.GetComponent<Shop>();
                int id_weapon = int.Parse(Slots_bombs[i]);
                Weapon weapon = shop.Get_weapon_by_id(id_weapon);
                //Количество бомб
                int ammoCount = PlayerPrefs.GetInt($"{weapon.id_ammo}");

                //! GetChild(0) -  Так ошибка может быть, 
                //! если ты поменяешь местами объект  в иерархии - то Жопа
                //! NullReferenceExcption 
                Text text = Inv_images_bombs[i].transform.GetChild(0).GetComponent<Text>();
                text.text = $"{ammoCount}";

            }
        }
    }

    public void ChangeWeapon(int id_slot_weapon)
    {
        //Смена активного оружия

        if (Slots[id_slot_weapon] != "EMPTY" && Slots[id_slot_weapon] != "NOT_BUY")
        {
            //Если слот с ид(числом)
            int id_weapon_change = Int32.Parse(Slots[id_slot_weapon]); //Ид оружия из слота

            Stvol stvol = Stvol.GetComponent<Stvol>();
            stvol.id_weapon = id_weapon_change; //установка ид оружия

            Shop shop = Shop.gameObject.GetComponent<Shop>();
            Weapon weapon = shop.Get_weapon_by_id(id_weapon_change);

            int id_a = weapon.id_ammo; //Узнаем ид патронов оружия
            stvol.id_bullet = id_a; //Устанавливаем ид патронов оружия
            stvol.AttackSpeed = weapon.attack_speed; //Устанавливаем скорость стрельбы

            Upgrade upgrade = Upgrade.GetComponent<Upgrade>();
            int parametr = upgrade.Container_in_upgrade.GetUpgradeParamet("Charter", "Damage");
            //Устанавливаем урон оружия (улучшение оружия+улучшение персонажа)
            stvol.Damage_weapon = weapon.damage + parametr;

            //Отрисовка активного оружия (слева снизу)
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i] != "EMPTY" && Slots[i] != "NOT_BUY")
                {
                    Image image = Inv_images[i].GetComponent<Image>();
                    int stvolID = int.Parse(Slots[i]);
                    Weapon shopWeapon = shop.Get_weapon_by_id(stvolID);
                    //Если слот с ид(числом)
                    bool isActive = id_weapon_change == stvolID;

                    //Взять активную картинку из предмета 
                    image.sprite = isActive ? shopWeapon.Active_img : shopWeapon.Weapon_img;

                }
                else
                {
                    Inv_images[i].SetActive(false);
                }
            }

            stvol.Start_id_Weapon(); //Установка анимации оружия

        }
    }

    public void Install_any_weapon()
    { //Установить любое оружие

        bool one_weapon_install = false;
        for (int i = 0; i < Slots.Length; i++)
        {
            //   Debug.Log ("Install_any_weapon I=" + i);
            if (Slots[i] != "EMPTY" && Slots[i] != "NOT_BUY")
            { //Если слот с ид(числом)
                //   Debug.Log ("Slots[i]=" + Slots[i]);
                //    Debug.Log ("Int32.Parse (Slots[i])=" + Int32.Parse (Slots[i]));
                ChangeWeapon(i); // Передаем ид слота 
                one_weapon_install = true;
                break; //Выход из цикла при установке оружия
            }
        }
        if (one_weapon_install == false)
        {
            //  Debug.Log ("Не установлено ни одно оружие !!!!!!!!!!!!");
            PlayerPrefs.SetString("SW_0", ("" + "0")); //Одеваем оружие
            Load_inv_weapons();
            Install_any_weapon();

        }

    }

    private void Start()
    {
        lives = upg_c.Upgrade("Health"); //ХП загружка из улучшения
        lives_max = upg_c.Upgrade("Health"); //ХП загружка из улучшения

        speed_default = (((float)upg_c.Upgrade("Speed_transport")) / 10f);
        speed = speed_default;

        Removing_log_process = false;
        SetState(State.Horse_Walk_walk);
        Install_data();
        Load_inv_weapons();
        ControllerBonus = GameObject.FindGameObjectsWithTag("ControllerBonus")[0];
        Gameover.SetActive(false);
        Move = true;
        Install_any_weapon(); //Установить любое оружие
    }

    public void Boost_animation()
    {
        SetState(State.Horse_Run_run);
    }
    public void Boost_animation_Idle()
    {
        SetState(State.Horse_Walk_walk);
    }

    void Update()
    {
        Run();
    }
    void Run()
    {
        if (Move == true)
        {

            Vector3 direction = -transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        }
    }
    public void Stop_on_win_or_defeat()
    {
        SetState(State.Horse_Idle_idle);
        Move = false;
        controllerAni.Rotation = false;
    }

    public void StopMove()
    { //Остановить движения
        //   rayHorse.onRay=false;
        Removing_log_process = true;
        SetState(State.Horse_Idle_idle);
        Move = false;
        controllerAni.Rotation = false;
        naezdnik.is_jump();

    }

    public void StartMove()
    { //Продолжить движение

        SetState(State.Horse_Walk_walk);
        Move = true;
        controllerAni.Rotation = true;
        rayHorse.onRay = true;

    }

    public void GetDamage(int damage)
    {
        //? Изменение хп и вызов всех связанных функций
        lives -= damage; //Присваиваем значение хп
        LivesUI(); //Отрисовать хп
        PovozkaJizn(); //Убиваем персонажа если хп меньше или равно 0
        // Debug.Log ("Хп у повозки отнято,осталось " + lives + " HP");
    }

    public void LivesUI() //Отрисовать хп
    {
        health_bar.gameObject.GetComponent<Scrollbar>().size = ((float)lives / (float)lives_max);
        //  health.gameObject.GetComponent<Text> ().text = "HP" + lives;
    }

    public void PovozkaJizn() //Убиваем персонажа если хп меньше или равно 0
    {
        if (lives <= 0)
        {
            camera_main.gameObject.GetComponent<CameraController>().alive = false; //Остановить перемежение камеры за повозкой
            //Chunkpovozka.gameObject.GetComponent<ChunksPavozka>().Stoppovozka = false;
            //_chunkpovozka.gameObject.GetComponent<ChunksPavozka>().Stoppovozka = false;
            //  Gameover.SetActive (true);
            // Time.timeScale = 0;

            Start_shot_script.CanShoot = false;
            ControllerBonus.gameObject.GetComponent<UI_controller>().Draw_Defeath(); // 
            Destroy(gameObject);

        }
    }

    public void SetState(State state)
    {
        currentState = state;
        Horse_Ilde.SetActive(state == State.Horse_Idle_idle);
        Horse_Run.SetActive(state == State.Horse_Run_run);
        Horse_Walk.SetActive(state == State.Horse_Walk_walk);
    }
    public enum State
    {
        Horse_Idle_idle,
        Horse_Run_run,
        Horse_Walk_walk
    }
}