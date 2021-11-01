using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPGRADE_controller : MonoBehaviour
{
    Container_stats upg;
    public Upgrade upgrade_main_menu_loader;
    //   Levels_parametrs lvl_p;

    /*
        foreach (string key in data.Keys) {
            Console.WriteLine (key);
        }

    */

    public Dictionary<string, int> Game_upg_parametrs = new Dictionary<string, int>(); //Все улучшения(параметры) в игре
    bool loaded;

    string[] Standart = { "Charter", "Kucher", "Horse", "NOT_SET_OBJ" };

    public bool Standart_set_parametrs(string Obj_name)
    {
        foreach (string key in upg.All_obj.Keys)
        {
            foreach (var s in Standart)
            {
                if (s == Obj_name)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Load_all_stats()
    {
        foreach (string Obj_upg_name in upg.All_obj.Keys)
        { //Obj_upg_name имена улучшений
            if (Standart_set_parametrs(Obj_upg_name))
            {
                foreach (string param in upg.All_obj[Obj_upg_name].Parametr.Keys)
                {
                    //  Debug.Log ("OBJ=" + Obj_upg_name + " P=" + param);

                    if (Game_upg_parametrs.ContainsKey(param))
                    {
                        Game_upg_parametrs[param] = Game_upg_parametrs[param] + upg.GetUpgradeParamet(Obj_upg_name, param);
                    }
                    else
                    {
                        Game_upg_parametrs[param] = upg.GetUpgradeParamet(Obj_upg_name, param);
                    }

                    // Game_upg_parametrs[param] += upg.GetP (Obj_upg_name, param);
                }
            }
        }
    }

    // Start is called before the first frame update
    public void Load_upg()
    {
        upgrade_main_menu_loader.Load_container();
        Standart[3] = PlayerPrefs.GetString("Transport"); //Транспорт
        upg = new Container_stats();
        Load_all_stats();
        loaded = true;
    }
    /// <summary>
    /// Прокачка параметра
    /// </summary>
    /// <param name="get_parametr"> Параметр прокачки</param>
    /// <returns>Что вовращает? Уровень или значение?</returns>
    public int Upgrade(string get_parametr)
    {
        if (loaded == false)
        {
            Load_upg();
        }
        else if (!Game_upg_parametrs.ContainsKey(get_parametr))
        {
            upgrade_main_menu_loader.Load_container();
            Load_upg();
        }

        return Game_upg_parametrs[get_parametr];
    }

    void Start()
    {

        loaded = false;
        if (loaded == false)
        {
            Load_upg();
        }

        foreach (string p in Game_upg_parametrs.Keys)
        {
            //            Debug.Log ("P= @" + p + "@ value=" + Game_upg_parametrs[p]);
        }

    }
}