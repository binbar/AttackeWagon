using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Weapon { //Оружие
    public string name; //Название предмета
    public int id; //Уникальный ид предмета,нужен для проверки куплен или нет предмет
    public int damage; //Урон
    public int clip_size; //Количество патронов в обойме
    public float attack_speed; //Скорость стельбы
    public int reload_speed; //Скорость перезарядки
    public int id_ammo; //Ид боеприпасов для стрельбы

    public Sprite image; //Картинка предмета
    public Sprite Weapon_img; //Неактивное оружие
    public Sprite Active_img; //Активное оружие

    public Weapon (string _name, int _id, int damage_, int clip_size_, float attack_speed_, int reload_speed_, int id_ammo_, Sprite _image, Sprite _Weapon_img, Sprite _Active_img) {
        name = _name;
        id = _id;
        damage = damage_;
        clip_size = clip_size_;
        attack_speed = attack_speed_;
        reload_speed = reload_speed_;
        id_ammo = id_ammo_;

        image = _image;
        Weapon_img = _Weapon_img;
        Active_img = _Active_img;
    }
}

[System.Serializable]
public class ShopItem { //Предмет магазина 
    public string name; //Название предмета
    public int id; //Уникальный ид предмета,нужен для проверки куплен или нет предмет

    public string type_buy; //Одноразово покупаемое или многоразово покупаемое
    public int cost; //Цена
    public string typecoin; //Тип валюты
    public int count; //Количество покупаемых предметов

    public string description; //Описание предмета

    public Sprite image; //Картинка предмета

    public ShopItem (string _name, int _id, string _type_buy, int _cost, string _typecoin, int _count, string _description, Sprite _image) {
        name = _name;
        id = _id;
        type_buy = _type_buy;
        cost = _cost;
        typecoin = _typecoin;
        count = _count;
        description = _description;

        image = _image;

    }
}

public class Container_weapon_upgrade {

    //  public List<Obj_Stats> All_obj = new List<Obj_Stats> (); //Выды улучшений и параметры
    public Dictionary<string, Obj_Stats> All_obj = new Dictionary<string, Obj_Stats> ();

    public void New_obj_upgrade (Obj_Stats New_upgrade_obj) { //Создание нового обьекта улучшения
        All_obj.Add (New_upgrade_obj.NameObj, New_upgrade_obj);
    }

    public void Up_by_name (string name_find_obj) { //Улучшить по имени
        All_obj[name_find_obj].Level_Up ();
    }

    public int Get_lvl (string name_find_obj) { //Узнать уровень обьекта
        return All_obj[name_find_obj].Level_now;
    }

    public int GetP (string Upgrade_name, string Parametr_name) { //Узнать текущий(в сумме) уровень параметра
        int Paremetr;
        Paremetr = All_obj[Upgrade_name].GetParemetr_now (Parametr_name);
        return Paremetr;
    }

    public int GetP_next (string name_find_obj, string name_param) { //Узнать следуйщий уровень параметра
        return All_obj[name_find_obj].GetParametr_next_upgrade (name_param);
    }

    public Container_weapon_upgrade () { //Создание обьекта

        //PlayerPrefs.DeleteAll (); //Нужно для теста
      //  Debug.Log ("Container_load:WEAPON");

        Obj_Stats Weapon_0 = new Obj_Stats ("Weapon_0", 4);
        New_obj_upgrade (Weapon_0); //Добавление в словарь 
        Weapon_0.SetParemetr ("Damage", new int[] { 120, 30, 30, 70, 70 }); //количество урона
        Weapon_0.SetParemetr ("Price_Bread", new int[] { 0, 2000, 3200, 5300, 9700 }); //Цена за хлеб

        Obj_Stats Weapon_1 = new Obj_Stats ("Weapon_1", 4);

        New_obj_upgrade (Weapon_1); //Добавление в словарь 

        Weapon_1.SetParemetr ("Damage", new int[] { 75, 30, 40, 50, 60 }); //количество урона
        Weapon_1.SetParemetr ("Price_Bread", new int[] { 0, 2500, 4000, 6800, 13600 }); //Цена за хлеб

        Obj_Stats Weapon_2 = new Obj_Stats ("Weapon_2", 4);
        New_obj_upgrade (Weapon_2); //Добавление в словарь 
        Weapon_2.SetParemetr ("Damage", new int[] { 80, 30, 30, 30, 30 }); //количество урона
        Weapon_2.SetParemetr ("Price_Bread", new int[] { 0, 3200, 4800, 8200, 15700 }); //Цена за хлеб

        Obj_Stats Weapon_3 = new Obj_Stats ("Weapon_3", 4);
        New_obj_upgrade (Weapon_3); //Добавление в словарь 
        Weapon_3.SetParemetr ("Damage", new int[] { 250, 250, 250, 450, 600 }); //количество урона
        Weapon_3.SetParemetr ("Price_Bread", new int[] { 0, 4500, 7200, 12400, 24000 }); //Цена за хлеб

        Obj_Stats Weapon_4 = new Obj_Stats ("Weapon_4", 4);
        New_obj_upgrade (Weapon_4); //Добавление в словарь 
        Weapon_4.SetParemetr ("Damage", new int[] { 160, 40, 50, 70, 130 }); //количество урона
        Weapon_4.SetParemetr ("Price_Bread", new int[] { 0, 6200, 10200, 18200, 32000 }); //Цена за хлеб

        Obj_Stats Weapon_5 = new Obj_Stats ("Weapon_5", 4);
        New_obj_upgrade (Weapon_5); //Добавление в словарь 
        Weapon_5.SetParemetr ("Damage", new int[] { 290, 60, 140, 160, 1000 }); //количество урона
        Weapon_5.SetParemetr ("Price_Bread", new int[] { 0, 9200, 15500, 24000, 41000 }); //Цена за хлеб

        //выставляем урон для бомбы
        Obj_Stats Weapon_12 = new Obj_Stats ("Weapon_12", 4);
        New_obj_upgrade (Weapon_12); //Добавление в словарь 
        Weapon_12.SetParemetr ("Damage", new int[] { 500, 100, 150, 200, 300 });
        Weapon_12.SetParemetr ("Price_Bread", new int[] { 0, 800, 1500, 2800, 5300 });//Цена за хлеб

        Obj_Stats Weapon_13 = new Obj_Stats ("Weapon_13", 4);
        New_obj_upgrade (Weapon_13); //Добавление в словарь 
        Weapon_13.SetParemetr ("Damage", new int[] { 180, 70, 70, 80, 120 });
        Weapon_13.SetParemetr ("Price_Bread", new int[] { 0, 850, 1750, 3500, 9000 });//Цена за хлеб

        Obj_Stats Weapon_14 = new Obj_Stats ("Weapon_14", 4);
        New_obj_upgrade (Weapon_14); //Добавление в словарь 
        Weapon_14.SetParemetr ("Damage", new int[] { 190, 90, 120, 150, 150 });
        Weapon_14.SetParemetr ("Price_Bread", new int[] { 0, 900, 1900, 3900, 10500 });//Цена за хлеб

        Obj_Stats Weapon_15 = new Obj_Stats ("Weapon_15", 4);
        New_obj_upgrade (Weapon_15); //Добавление в словарь 
        Weapon_15.SetParemetr ("Damage", new int[] { 350, 100, 140, 90, 150 });
        Weapon_15.SetParemetr ("Price_Bread", new int[] { 0, 1200, 3500, 9800, 22000 });//Цена за хлеб

    }
}

public class Shop : MonoBehaviour {
    public List<ShopItem> shop_items = new List<ShopItem> (); //Все магазинные предметы
    public GameObject[] Weapon_buy; //Ячейки продажи оружия

    public List<Weapon> all_weapons = new List<Weapon> (); //Все оружие
    public Sprite[] all_weapons_image; //Все картинки оружий
    public Sprite[] Weapon_image; //Неактивное оружие
    public Sprite[] Active_image; //Активные оружия

    public string[] Slots; //Слоты инвентаря(оружие)
    public string[] Slots_bomb; //Слоты инвентаря(бомбы)
    public GameObject[] Slot_imgs; //Картинки слотов инвентаря(для указания)(оружие)
    public GameObject[] Slot_imgs_bomb; //Картинки слотов инвентаря(для указания)(бомбы)

    public Sprite EMPTY; //Пустой слот инвентаря
    public Sprite NOT_BUY; //Заблокированный слот инвентаря

    public Container_weapon_upgrade Container_in_weapon; //Улучшение оружия

    public GameObject MoneyPanel;
    public GameObject WeaponPanel;
    public GameObject BoomPanel;
    public GameObject InfoText;

    public GameObject[] Weapon_line; //Оружия в магазине

    public int id_selected;

    public GameObject Top_menu;

    public GameObject Donate_menu;//Меню доната

    void Slots_install () { //Загрузка инвентаря и отрисовка
        ////////////////////////////////////////// ОРУЖИЕ ////////////////////////////////////////////////
        Slots = new string[4]; //Установка размера инвентаря (оружие)

        PlayerPrefs.SetInt ("Slots_weapon", 4); // Устаноливаем сколько слотов в начале игры открыто.

        for (int i = 0; i < Slots.Length; i++) { //Делаем все слоты не куплеными
            Slots[i] = "NOT_BUY";
        }
        int Slots_weapon_count = PlayerPrefs.GetInt ("Slots_weapon"); //Загружаем количество купленых слотов оружия

        for (int i = 0; i < Slots.Length && i < Slots_weapon_count; i++) { //Делаем все слоты не куплеными
            Slots[i] = "EMPTY";
        }

        for (int i = 0; i < Slots.Length; i++) { //Загрузка содержимого(предметов) инвентаря

            string SW_check = PlayerPrefs.GetString ("SW_" + i);

            if (SW_check != "") { //Если слот сохраненного инвентаря не пустой

                if (Slots[i] == "EMPTY") { //Если слот пустой
                    Slots[i] = "" + SW_check; //Установить в слот инвентаря
                  //  Debug.Log ("Установлено в " + i + " инвентарь ID:" + SW_check);
                }
            }

        }
        for (int i = 0; i < Slots.Length; i++) { //Установка картинок
            if (Slots[i] != "EMPTY" && Slots[i] != "NOT_BUY") { //Если слот не "пустой" или не "не куплен" то устанавливаем картинку
             //  Debug.Log ("SLOT SET:" + Int32.Parse (Slots[i]));
                Slot_imgs[i].GetComponent<Image> ().sprite = Get_weapon_by_id (Int32.Parse (Slots[i])).image; //Взять картинку из предмета 
            } else if (Slots[i] == "EMPTY") { //Если нет предмета то сделать пустую картинку
                Slot_imgs[i].GetComponent<Image> ().sprite = EMPTY; //Картинка пустого слота
            } else if (Slots[i] == "NOT_BUY") {
                Slot_imgs[i].GetComponent<Image> ().sprite = NOT_BUY; //Картинка не купленного слота
            }
        }
        ////////////////////////////////////////// БОМБЫ ////////////////////////////////////////////////
        Slots_bomb = new string[4]; //Установка размера инвентаря (бомбы)

        PlayerPrefs.SetInt ("Slots_bomb", 4); // Устаноливаем сколько слотов в начале игры открыто.

        for (int i = 0; i < Slots_bomb.Length; i++) { //Делаем все слоты не куплеными
            Slots_bomb[i] = "NOT_BUY";
        }
        int Slots_bomb_count = PlayerPrefs.GetInt ("Slots_bomb"); //Загружаем количество купленых слотов оружия

        for (int i = 0; i < Slots_bomb.Length && i < Slots_bomb_count; i++) { //Делаем все слоты не куплеными
            Slots_bomb[i] = "EMPTY";
        }

        for (int i = 0; i < Slots_bomb.Length; i++) { //Загрузка содержимого(предметов) инвентаря

            string SB_check = PlayerPrefs.GetString ("SB_" + i);

            if (SB_check != "") { //Если слот сохраненного инвентаря не пустой

                if (Slots_bomb[i] == "EMPTY") { //Если слот пустой
                    Slots_bomb[i] = "" + SB_check; //Установить в слот инвентаря
                  //  Debug.Log ("Установлено в " + i + " инвентарь ID:" + SB_check);
                }
            }

        }
        for (int i = 0; i < Slots.Length; i++) { //Установка картинок
            if (Slots_bomb[i] != "EMPTY" && Slots_bomb[i] != "NOT_BUY") { //Если слот не "пустой" или не "не куплен" то устанавливаем картинку
            //    Debug.Log ("SLOT SET:" + Int32.Parse (Slots_bomb[i]));
                Slot_imgs_bomb[i].GetComponent<Image> ().sprite = Get_weapon_by_id (Int32.Parse (Slots_bomb[i])).image; //Взять картинку из предмета 
            } else if (Slots_bomb[i] == "EMPTY") { //Если нет предмета то сделать пустую картинку
                Slot_imgs_bomb[i].GetComponent<Image> ().sprite = EMPTY; //Картинка пустого слота
            } else if (Slots_bomb[i] == "NOT_BUY") {
                Slot_imgs_bomb[i].GetComponent<Image> ().sprite = NOT_BUY; //Картинка не купленного слота
            }
        }

        Weapon_load ();
    }
    public void Weapon_load () {
        for (int i = 0; i <= 15; i++) {
            if (i <= 5 || (i >= 12 && i <= 15)) //Если диапазон оружия или вызрывчатки
            {
                if (Check_buy (i) == true) {
                    Weapon_buy[i].gameObject.transform.GetChild (0).transform.gameObject.SetActive (true); //Включить купленый предмет
                    Weapon_buy[i].gameObject.transform.GetChild (1).transform.gameObject.SetActive (false); //Выключить не купленый предмет 
                }
            }
        }
    }

    public void ShopItem_install () { //Список предметов магазина ( Название/Iцена/количество патронов)
        shop_items.Add (new ShopItem ("Двухстволка", 0, "one", 25, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Дробовик", 1, "one", 22500, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Револьвер", 2, "one", 10200, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Sniper", 3, "one", 50000, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Ak-47", 4, "one", 95000, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Базука", 5, "one", 220000, "Bread", 1, "ОПИСАНИЕ", null));

        shop_items.Add (new ShopItem ("Двухстволка_боеприпасы", 6, "many", 5, "Bread", 20, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Дробовик_боеприпасы", 7, "many", 15, "Bread", 8, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Револьвер_боеприпасы", 8, "many", 20, "Bread", 16, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Sniper_боеприпасы", 9, "many", 55, "Bread", 10, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Ak-47_боеприпасы", 10, "many", 80, "Bread", 30, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Базука_боеприпасы", 11, "many", 200, "Bread", 10, "ОПИСАНИЕ", null));

        shop_items.Add (new ShopItem ("Динамит", 12, "one", 3300, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Граната", 13, "one", 4000, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Коктейль_молотова", 14, "one", 4200, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Мина", 15, "one", 6000, "Bread",1, "ОПИСАНИЕ", null));

        shop_items.Add (new ShopItem ("Динамит_боеприпасы", 16, "many", 100, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Граната_боеприпасы", 17, "many", 200, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Коктейль_молотова_боеприпасы", 18, "many",250, "Bread", 1, "ОПИСАНИЕ", null));
        shop_items.Add (new ShopItem ("Мина_боеприпасы", 19, "many", 450, "Bread", 1, "ОПИСАНИЕ", null));

    }

    public void Weapon_install () { //Список всего оружия в игре
        //Перезарядка, количество патронов в обойме и врем перезарядки
        all_weapons.Clear ();
        all_weapons.Add (new Weapon ("Двухстволка", 0, Container_in_weapon.GetP ("Weapon_0", "Damage"), 2, 0.5f, 2, 6, all_weapons_image[0], Weapon_image[0], Active_image[0]));
        all_weapons.Add (new Weapon ("Дробовик", 1, Container_in_weapon.GetP ("Weapon_1", "Damage"), 8, 0.5f, 2, 7, all_weapons_image[1], Weapon_image[1], Active_image[1]));
        all_weapons.Add (new Weapon ("Револьвер", 2, Container_in_weapon.GetP ("Weapon_2", "Damage"), 16, 0.5f, 2, 8, all_weapons_image[2], Weapon_image[2], Active_image[2]));
        all_weapons.Add (new Weapon ("Sniper", 3, Container_in_weapon.GetP ("Weapon_3", "Damage"), 10, 0.5f, 2, 9, all_weapons_image[3], Weapon_image[3], Active_image[3]));
        all_weapons.Add (new Weapon ("Ak-47", 4, Container_in_weapon.GetP ("Weapon_4", "Damage"), 30, 0.01f, 2, 10, all_weapons_image[4], Weapon_image[4], Active_image[4]));
        all_weapons.Add (new Weapon ("Базука", 5, Container_in_weapon.GetP ("Weapon_5", "Damage"), 1, 0.5f, 2, 11, all_weapons_image[5], Weapon_image[5], Active_image[5]));

        all_weapons.Add (new Weapon ("Динамит", 12, Container_in_weapon.GetP ("Weapon_12", "Damage"), 30, 0.5f, 2, 16, all_weapons_image[6], Weapon_image[6], Active_image[6]));
        all_weapons.Add (new Weapon ("Граната", 13, Container_in_weapon.GetP ("Weapon_13", "Damage"), 30, 0.5f, 2, 17, all_weapons_image[7], Weapon_image[7], Active_image[7]));
        all_weapons.Add (new Weapon ("Коктейль_молотова", 14, Container_in_weapon.GetP ("Weapon_14", "Damage"), 30, 0.5f, 2, 18, all_weapons_image[8], Weapon_image[8], Active_image[8]));
        all_weapons.Add (new Weapon ("Мина", 15, Container_in_weapon.GetP ("Weapon_15", "Damage"), 30, 0.5f, 2, 19, all_weapons_image[9], Weapon_image[9], Active_image[9]));

    }

    public Weapon Get_weapon_by_id (int id_weapon) { //Получить информации об оружии по его ид
        foreach (var some_weapon in all_weapons) {
            if (some_weapon.id == id_weapon) {
                return some_weapon;
            }
        }
        return null;
    }
    public bool Check_buy (int id_some_item) { //Проверка куплен ли предмет, true куплен ,false не куплен
        if (PlayerPrefs.GetInt ("" + id_some_item) > 0) {
            return true; //Куплен
        }
        return false; //Не куплен
    }

    public void Equip_weapon (int id_weapon) { //Одеть оружие
        if (Check_buy (id_weapon) == true) { //Проверка куплен ли предмет, true куплен ,false не куплен 
           
            if (Check_inventory_weapon (id_weapon) == false) { //Проверка одето ли оружие в слот инвентаря
             

                for (int i = 0; i < PlayerPrefs.GetInt ("Slots_weapon"); i++) {
                    if (Slots[i] == "EMPTY") {
                     //   Debug.Log ("Оружие одето:" + id_weapon);

                        PlayerPrefs.SetString ("SW_" + i, ("" + id_weapon)); //Одеваем оружие
                        Slots_install (); //Прогрузка и отрисовка инвентаря
                        break;
                    }
                }
               // Debug.Log ("Все слоты заняты");
            }
        }

    }
    public void Equip_bomb (int id_weapon) { //Одеть оружие
        if (Check_buy (id_weapon) == true) { //Проверка куплен ли предмет, true куплен ,false не куплен 
          
            if (Check_inventory_bomb (id_weapon) == false) { //Проверка одето ли оружие в слот инвентаря
              

                for (int i = 0; i < PlayerPrefs.GetInt ("Slots_bomb"); i++) {
                    if (Slots_bomb[i] == "EMPTY") {
                      //  Debug.Log ("Оружие одето:" + id_weapon);

                        PlayerPrefs.SetString ("SB_" + i, ("" + id_weapon)); //Одеваем оружие
                        Slots_install (); //Прогрузка и отрисовка инвентаря
                        break;
                    }
                }
               // Debug.Log ("Все слоты заняты");
            }
        }

    }

    public void Clear_weapon (int id_slot) { //Снять оружие
        string some_slot = PlayerPrefs.GetString ("SW_" + id_slot);
        if (some_slot != "NOT_BUY" && some_slot != "EMPTY") {
            PlayerPrefs.SetString ("SW_" + id_slot, "EMPTY"); //Очищаем слот справа
            Slots_install (); //Прогрузка и отрисовка инвентаря
        }
    }
    public void Clear_weapon_bomb (int id_slot) { //Снять оружие(бомбы)
        string some_slot = PlayerPrefs.GetString ("SB_" + id_slot);
        if (some_slot != "NOT_BUY" && some_slot != "EMPTY") {
            PlayerPrefs.SetString ("SB_" + id_slot, "EMPTY"); //Очищаем слот справа
            Slots_install (); //Прогрузка и отрисовка инвентаря
        }
    }

    public bool Check_inventory_weapon (int id_weapon) { //Проверка одето ли оружие в слот инвентаря

        for (int i = 0; i < Slots.Length; i++) {
            if (Slots[i] == ("" + id_weapon)) { //Проверка есть ли в инвентаре предмет
                return true; //Предмет есть в инвентаре
            }
        }
        return false; //Предмета нет в инвентаре

    }
    public bool Check_inventory_bomb (int id_weapon) { //Проверка одето ли оружие в слот инвентаря

        for (int i = 0; i < Slots_bomb.Length; i++) {
            if (Slots_bomb[i] == ("" + id_weapon)) { //Проверка есть ли в инвентаре предмет
                return true; //Предмет есть в инвентаре
            }
        }
        return false; //Предмета нет в инвентаре

    }
    public void CheatMoney () {
        PlayerPrefs.SetInt ("Carrot", 9999999);
        PlayerPrefs.SetInt ("Bread", 9999999);
        PlayerPrefs.SetInt ("Tooth", 999999);
    }

    public void Balance () {
        //   Debug.Log("carrot:" + PlayerPrefs.GetInt("carrot") + "# bread:" + PlayerPrefs.GetInt("Bread"));
    }

    public void Load_container () {
        Container_weapon_upgrade Upg_waepon = new Container_weapon_upgrade ();
        Container_in_weapon = Upg_waepon;

    }

    public void Drobovik_install () {
        PlayerPrefs.SetString ("SW_0", "0");
    }

    void Start () {
        Drobovik_install ();
        // PlayerPrefs.DeleteAll ();
       // CheatMoney ();
        Load_container ();

        Weapon_install ();
        ShopItem_install ();

        Slots_install ();
        Draw_weapon_line (); //Отрисовка орежия

        //  BuyItem(2);
        //    Balance ();

        //   BuyItem (8);
        //  Balance ();

    }

    public void BuyItem (int id_selected) { //Покупка предмета

        if ((shop_items[id_selected].type_buy == "one" && PlayerPrefs.GetInt ("" + shop_items[id_selected].id) < 1) || shop_items[id_selected].type_buy == "many") {
            if (PlayerPrefs.GetInt ("" + shop_items[id_selected].typecoin) >= shop_items[id_selected].cost) { //Проверка хватает ли средств на покупку
                PlayerPrefs.SetInt ("" + shop_items[id_selected].id, (PlayerPrefs.GetInt ("" + shop_items[id_selected].id) + shop_items[id_selected].count)); //Зачисление покупки,добавление count
                PlayerPrefs.SetInt ("" + shop_items[id_selected].typecoin, ((PlayerPrefs.GetInt ("" + shop_items[id_selected].typecoin)) - shop_items[id_selected].cost)); //Снятие средств(валюты указанной в предмете) за покупку
               // Debug.Log ("Предмет" + shop_items[id_selected].name + " с ид " + shop_items[id_selected].id + " успешно куплен,сейчас количество " + PlayerPrefs.GetInt ("" + shop_items[id_selected].id));
                Slots_install (); //Перезагрузить инвентарь
                Draw_weapon_line ();
                Top_menu.gameObject.GetComponent<Info> ().Draw_money (); //Отрисовка денег(валют) сверху
            } else {
              //  Debug.Log ("Не хватает средств на покупку");
              Donate_menu.SetActive (true);//Включить меню доната
              
            }
        } else if (shop_items[id_selected].type_buy == "one") {
           // Debug.Log ("Этот предмет может быть куплен только один раз");
        }
    }

    public void Lvl_up_weapon (int id_selected) { //Улучшить оружие по ид
      //  Debug.Log ("Lvl_up_weapon();");
        bool Have_Bread = false;

        if (PlayerPrefs.GetInt ("Bread") >= Container_in_weapon.GetP_next (("Weapon_" + id_selected), "Price_Bread")) {

            Have_Bread = true; //Хватавет хлеба
         //   Debug.Log ("Хватавет хлеба");
        } else {
            Donate_menu.SetActive (true);//Включить меню доната
        }
        if (Have_Bread == true)

        { //Если хватает  опыта и хлеба то отнимаем деньги

            PlayerPrefs.SetInt ("Bread", ((PlayerPrefs.GetInt ("Bread")) - Container_in_weapon.GetP_next (("Weapon_" + id_selected), "Price_Bread"))); //Снатие средств (хлеб)

            Container_in_weapon.Up_by_name ("Weapon_" + id_selected); //Улучшить по имени
            Weapon_install ();
            Draw_weapon_line ();
            Top_menu.gameObject.GetComponent<Info> ().Draw_money (); //Отрисовка денег(валют) сверху

         //   Debug.Log ("Weapon_" + id_selected + " Улучшено");
            // Debug.Log ("" + Container_in_weapon.Get_lvl (Name)); //Тест
            // Draw_text ();

        }
    }
    public void Draw_weapon_line () {
        for (int i = 0; i <= 15; i++) { // all_weapons.Count //Выставление на каждом оружии 
            //Если куплено
            if (i <= 5 || (i >= 12 && i <= 15)) //Если диапазон оружия или вызрывчатки
            {

                for (int lvl_star = 1; lvl_star <= 4; lvl_star++) { //Выставление звезд на конкретном оружии
                    if (Container_in_weapon.Get_lvl ("Weapon_" + i) >= lvl_star) {
                        Weapon_line[i].gameObject.transform.GetChild (0).gameObject.transform.GetChild (3).gameObject.transform.GetChild (lvl_star - 1).gameObject.SetActive (true);
                    }
                }

                if (Container_in_weapon.Get_lvl ("Weapon_" + i) >= 4) {
                    for (int s = 0; s < 3; s++) {
                        Weapon_line[i].gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.transform.GetChild (s).gameObject.SetActive (false);
                    }
                    Weapon_line[i].gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.transform.GetChild (3).gameObject.SetActive (true);
                    Weapon_line[i].gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.GetComponent<Button> ().enabled = false;

                }
                Weapon_line[i].gameObject.transform.GetChild (0).gameObject.transform.GetChild (1).gameObject.transform.GetChild (2).GetComponent<Text> ().text = "" + Container_in_weapon.GetP_next (("Weapon_" + i), "Price_Bread"); //Количество патронов

                //  
                //Отрисовка количества патронов
                Weapon_line[i].gameObject.transform.GetChild (0).gameObject.transform.GetChild (4).gameObject.transform.GetChild (0).gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + PlayerPrefs.GetInt ("" + Get_weapon_by_id (i).id_ammo); //Количество патронов

            }
        }

    }

}