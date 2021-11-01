using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Obj_Stats
{
    public string NameObj;
    public int Level_now = 0; //Текущий уровень
    public int Level_max = 0; //Максимальный уровень

    public int Level_next
    { //Следуйщий уровень
        get { return (Level_now + 1); }
    }

    public Dictionary<string, int[]> Parametr = new Dictionary<string, int[]>();
    public Obj_Stats(string NameObj_, int Level_max_)
    { //Создание обьекта
        NameObj = NameObj_;
        Level_max = Level_max_;

        Level_now = PlayerPrefs.GetInt(NameObj_); //Загрузка уровня по имени обьекта
    }

    public void Level_Up()
    { //Повышение уровня (указать ф-ю в кнопке улучшения)
        
        if (Level_now < Level_max)
        {
            Level_now++;
            PlayerPrefs.SetInt(NameObj, Level_now); //Сохраняем уровень
          //  Debug.Log("Теперь уровень " + Level_now);
        }
        else
        {
            //Вы уже улучшили на максимум,сейчас уровень
         //   Debug.Log("Вы уже улучшили на максимум,сейчас уровень " + Level_now);
        }
    }

    public void SetParemetr(string NameParametr_, int[] arr_int)
    { //Добавление параметра
        Parametr.Add(NameParametr_, arr_int);
    }

    public int GetParemetr_now(string NameParametr_)
    { //Узнать текущее финальное значение параметра
        int result = 0;
        int set_limit = Level_now; //Установить лимит для цикла

        if (Level_now >= Parametr[NameParametr_].Length)
        { //Проверка на превышение размера массива в словаре
            set_limit = (Parametr[NameParametr_].Length - 1); //Установить лимит для цикла,так как улучшений дальше нет,-1 потому что берем число количества елементов
        }

        for (int i = 0; i <= set_limit; i++)
        {

            result += Parametr[NameParametr_][i];
        }

        return result;
    }

    public int GetParametr_next_upgrade(string NameParametr_)
    { //Узнать бонус улучшения параметра
        int result = 0;
        if (Level_next < Parametr[NameParametr_].Length)
        { //Проверка на превышение размера массива в словаре
            result = Parametr[NameParametr_][Level_next];
        }
        else
        {
           // Debug.Log("Следуйщего улучшения нет");
        }
        return result;
    }

}

public class Container_stats
{

    //  public List<Obj_Stats> All_obj = new List<Obj_Stats> (); //Выды улучшений и параметры
    public Dictionary<string, Obj_Stats> All_obj = new Dictionary<string, Obj_Stats>();

    public void New_obj_upgrade(Obj_Stats New_upgrade_obj)
    { //Создание нового обьекта улучшения
        All_obj.Add(New_upgrade_obj.NameObj, New_upgrade_obj);
    }

    public void Up_by_name(string name_find_obj)
    { //Улучшить по имени
        All_obj[name_find_obj].Level_Up();
    }

    public int Get_lvl(string name_find_obj)
    { //Узнать уровень обьекта
        return All_obj[name_find_obj].Level_now;
    }

    public int GetUpgradeParamet(string Upgrade_name, string Parametr_name)
    { //Узнать текущий(в сумме) уровень параметра
        int Paremetr;
        Paremetr = All_obj[Upgrade_name].GetParemetr_now(Parametr_name);
        return Paremetr;
    }

    public int GetP_next(string name_find_obj, string name_param)
    { //Узнать следуйщий уровень параметра
        return All_obj[name_find_obj].GetParametr_next_upgrade(name_param);
    }

    public Container_stats()
    { //Создание обьекта
        Obj_Stats Charter = new Obj_Stats("Charter", 10);
        New_obj_upgrade(Charter); //Добавление в словарь 
        Charter.SetParemetr("Bread", new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 });
        Charter.SetParemetr("Exp", new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 });
        Charter.SetParemetr("Damage", new int[] { 1, 2, 3, 3, 3, 4, 5, 6, 8, 10, 15 });
        Charter.SetParemetr("Health", new int[] { 250, 10, 10, 10, 15, 15, 15, 20, 25, 30, 40 });
        // цена прокачки
        Charter.SetParemetr("Price_Bread", new int[] { 0, 1500, 3400, 7300, 15400, 33400, 48000, 58000, 80000, 120000, 200000 });
        Charter.SetParemetr("Price_Exp", new int[] { 0, 500, 800, 1250, 1700, 2300, 3000, 3600, 4500, 6300, 10500 });

        Obj_Stats Kucher = new Obj_Stats("Kucher", 10);
        New_obj_upgrade(Kucher); //Добавление в словарь 
        Kucher.SetParemetr("Bread", new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 });
        Kucher.SetParemetr("Exp", new int[]{ 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
        Kucher.SetParemetr("Speed_skill", new int[] { 20, 1, 1, 2, 2, 2, 2, 3, 3, 4, 5 });//Должно быть не больше 30 секунд в сумме(всех чисел)
        Kucher.SetParemetr("Power", new int[] { 40, 5, 5, 8, 10, 13, 20, 28, 38, 50, 70 });

        Kucher.SetParemetr("Price_Bread", new int[] { 0, 1200, 3000, 7000, 15000, 25000, 38000, 52000, 63000, 89000, 110000 });
        Kucher.SetParemetr("Price_Exp", new int[] { 0, 150, 350, 800, 1200, 2000, 2800, 3500, 4800, 6300, 10000 });

        Obj_Stats Horse = new Obj_Stats("Horse", 10);
        New_obj_upgrade(Horse); //Добавление в словарь 
        Horse.SetParemetr("Speed_transport", new int[] { 25, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });//10=1f  40=4f//Это скорость перемещения транспорта
        Horse.SetParemetr("Health", new int[] { 0, 10, 10, 15, 10, 15, 18, 20, 20, 25, 30 });

        Horse.SetParemetr("Price_Bread", new int[] { 0, 800, 1100, 1600, 2200, 3000, 4100, 6300, 12400, 22000, 35000 });
        Horse.SetParemetr("Price_Exp", new int[] { 0, 220, 300, 520, 850, 1050, 1500, 1950, 2490, 3200, 4000 });

        Obj_Stats Povozka = new Obj_Stats("Povozka", 10);
        New_obj_upgrade(Povozka); //Добавление в словарь 
        Povozka.SetParemetr("Bread", new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 });
        Povozka.SetParemetr("Power", new int[] { 0, 1, 2, 2, 2, 2, 3, 3, 3, 3, 5 });

        Povozka.SetParemetr("Price_Bread", new int[] { 0, 750, 1100, 2000, 4800, 6400, 8100, 15800, 25000, 33000, 55000 });//Цена Монеты
        Povozka.SetParemetr("Price_Exp", new int[] { 0, 200, 300, 420, 610, 820, 1280, 2500, 3900, 5800, 10000});//Цена души

        Obj_Stats Lodka = new Obj_Stats("Lodka", 10);
        New_obj_upgrade(Lodka); //Добавление в словарь 
        Lodka.SetParemetr("Bread", new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
        Lodka.SetParemetr("Power", new int[] { 0, 1, 2, 2, 2, 2, 3, 3, 3, 3, 5 });

        Lodka.SetParemetr("Price_Bread", new int[] { 0, 750, 1100, 2000, 4800, 6400, 8100, 15800, 25000, 33000, 55000 });//Цена Монеты
        Lodka.SetParemetr("Price_Exp", new int[] { 0, 200, 300, 420, 610, 820, 1280, 2500, 3900, 5800, 10000});//Цена души

        Obj_Stats Povozka_winter = new Obj_Stats("Povozka_winter", 10);
        New_obj_upgrade(Povozka_winter); //Добавление в словарь 
        Povozka_winter.SetParemetr("Bread", new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
        Povozka_winter.SetParemetr("Power", new int[] { 0, 1, 2, 2, 2, 2, 3, 3, 3, 3, 5 });

        Povozka_winter.SetParemetr("Price_Bread", new int[] { 0, 750, 1100, 2000, 4800, 6400, 8100, 15800, 25000, 33000, 55000 });//Цена Монеты
        Povozka_winter.SetParemetr("Price_Exp", new int[] { 0, 200, 300, 420, 610, 820, 1280, 2500, 3900, 5800, 10000});//Цена души

        Obj_Stats Train = new Obj_Stats("Train", 10);
        New_obj_upgrade(Train); //Добавление в словарь 
        Train.SetParemetr("Bread", new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 });
        Train.SetParemetr("Power", new int[] { 0, 1, 2, 2, 2, 2, 3, 3, 3, 3, 5 });

        Train.SetParemetr("Price_Bread", new int[] { 0, 750, 1100, 2000, 4800, 6400, 8100, 15800, 25000, 33000, 55000 });//Цена Монеты
        Train.SetParemetr("Price_Exp", new int[] { 0, 200, 300, 420, 610, 820, 1280, 2500, 3900, 5800, 10000});//Цена души
    }
}

public class Upgrade : MonoBehaviour
{
    public GameObject[] Parametr_text; //Массив параметров текста
    public GameObject[] Level_text; //Массив уровней
    public GameObject[] Tab_upgrade; //Массив нужный для выставления цен параметров текста
    public Container_stats Container_in_upgrade;
    public GameObject Top_menu;
    //  Container_stats Upgrade_container = new Container_stats ();
    public GameObject Donate_menu;//Меню доната

    public void Draw_text_one(GameObject Param, string Obj_name, string Param_name)
    {
        //    Debug.Log ("DRAW (1):" + Obj_name + "####" + Param_name);
        Param.gameObject.transform.GetChild(1).GetComponent<Text>().text = "" + Container_in_upgrade.GetUpgradeParamet(Obj_name, Param_name); //Текущее значение
        //    Debug.Log ("DRAW (1) OK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        //   Debug.Log ("DRAW (2):" + Obj_name + "####" + Param_name);
        Param.gameObject.transform.GetChild(2).GetComponent<Text>().text = "+" + Container_in_upgrade.GetP_next(Obj_name, Param_name); //Следуйщее значение
        //  Debug.Log ("DRAW (2) OK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        //  Debug.Log ("DRAW (END):" + Obj_name + "####" + Param_name);
    }

    public void Draw_text()
    { //Отрисовка данных параметров
        //Параметры
        Draw_text_one(Parametr_text[0], "Charter", "Bread");
        Draw_text_one(Parametr_text[1], "Charter", "Exp");
        Draw_text_one(Parametr_text[2], "Charter", "Damage");
        Draw_text_one(Parametr_text[3], "Charter", "Health");

        Draw_text_one(Parametr_text[4], "Kucher", "Bread");
        Draw_text_one(Parametr_text[5], "Kucher", "Exp");
        Draw_text_one(Parametr_text[6], "Kucher", "Speed_skill");
        Draw_text_one(Parametr_text[7], "Kucher", "Power");

        Draw_text_one(Parametr_text[8], "Horse", "Speed_transport");
        Draw_text_one(Parametr_text[9], "Horse", "Health");

        Draw_text_one(Parametr_text[10], "Povozka", "Bread");
        Draw_text_one(Parametr_text[11], "Povozka", "Power");

        Draw_text_one(Parametr_text[12], "Lodka", "Bread"); //Хлеб
        Draw_text_one(Parametr_text[13], "Lodka", "Power"); //Сила

        Draw_text_one(Parametr_text[14], "Povozka_winter", "Bread"); //Хлеб
        Draw_text_one(Parametr_text[15], "Povozka_winter", "Power"); //Сила

        Draw_text_one(Parametr_text[16], "Train", "Bread"); //Хлеб
        Draw_text_one(Parametr_text[17], "Train", "Power"); //Сила


        //Отображение цены на кнопке
        Draw_price_in(Tab_upgrade[0], "Charter");
        Draw_price_in(Tab_upgrade[1], "Kucher");
        Draw_price_in(Tab_upgrade[2], "Horse");
        Draw_price_in(Tab_upgrade[3], "Povozka");
        Draw_price_in(Tab_upgrade[4], "Lodka");
        Draw_price_in(Tab_upgrade[5], "Povozka_winter");
        Draw_price_in(Tab_upgrade[6], "Train");

        //Уровни 
        Draw_level(Level_text[0], "Charter");
        Draw_level(Level_text[1], "Kucher");
        Draw_level(Level_text[2], "Horse");
        Draw_level(Level_text[3], "Povozka");
        Draw_level(Level_text[4], "Lodka");
        Draw_level(Level_text[5], "Povozka_winter");
        Draw_level(Level_text[6], "Train");

    }

    void Draw_level(GameObject L_text, string name_obj)
    {
        L_text.GetComponent<Text>().text = "" + Container_in_upgrade.Get_lvl(name_obj) + " Уровень"; //Отображение уровня
        if (name_obj=="Lodka")
        {
        Debug.Log("Lodka="+Container_in_upgrade.Get_lvl(name_obj));
        }

    }

    void Draw_price_in(GameObject btn_up, string name_obj)
    {
        string p_Bread = "" + Container_in_upgrade.GetP_next(name_obj, "Price_Bread"); //Берем цену хлеба 
        string p_Exp = "" + Container_in_upgrade.GetP_next(name_obj, "Price_Exp"); //Берем цену опыта

        btn_up.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "" + p_Bread; //Цена хлеб
        btn_up.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Text>().text = "" + p_Exp; //Цена опыт
    }

    public void Lvl_up(string Name)
    {
        bool Have_Bread = false;
        bool Have_Exp = false;

        if (PlayerPrefs.GetInt("Bread") >= Container_in_upgrade.GetP_next(Name, "Price_Bread"))
        {

            Have_Bread = true; //Хватавет хлеба
        }
        else
        {
          //  Debug.Log("Не хватает хлеба");
        }

        if (PlayerPrefs.GetInt("Tooth") >= Container_in_upgrade.GetP_next(Name, "Price_Exp"))
        {

            Have_Exp = true; //Хватает опыта
        }
        else
        {
          //Не хватает опыта
        }

        if (Have_Bread == true && Have_Exp == true)
        { //Если хватает  опыта и хлеба то отнимаем деньги

            PlayerPrefs.SetInt("Bread", ((PlayerPrefs.GetInt("Bread")) - Container_in_upgrade.GetP_next(Name, "Price_Bread"))); //Снатие средств (хлеб)
            PlayerPrefs.SetInt("Tooth", ((PlayerPrefs.GetInt("Tooth")) - Container_in_upgrade.GetP_next(Name, "Price_Exp"))); //Снатие средств (опыт)

            Container_in_upgrade.Up_by_name(Name); //Улучшить по имени
            Draw_text();
            Top_menu.gameObject.GetComponent<Info>().Draw_money(); //Отрисовка денег(валют) сверху
        }else
        {
                          Donate_menu.SetActive (true);//Включить меню доната
        }

    }

    public void Load_container()
    {
        Container_stats Upgrade_container = new Container_stats();
        Container_in_upgrade = Upgrade_container;
    }

  //  public void Cheat()
  //  {
    //    PlayerPrefs.SetInt("Bread", 1000); //Снатие средств (хлеб)
   //     PlayerPrefs.SetInt("Tooth", 1000); //Снатие средств (хлеб)
  //  }

    void Start()
    {
        Container_stats Upgrade_container = new Container_stats();
        Container_in_upgrade = Upgrade_container;
        Draw_text();

        //  PlayerPrefs.DeleteAll (); //Нужно для теста
 //  Cheat();

        //Test_Get ();
        // Draw_text ();

    }

}