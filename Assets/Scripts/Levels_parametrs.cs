using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels_parametrs : MonoBehaviour {
    // Start is called before the first frame update
    public int Lvl;

    public void install_lvl_parametrs () {
        PlayerPrefs.GetString ("Current_lvl"); //Текущий уровень

        PlayerPrefs.SetString ("Level_1", "open"); //complete завершен,open открыт,closed закрыт //Нужно прописать только в первом уровне
        PlayerPrefs.SetString ("Level_1_transport", "Povozka"); //Транспорт
        PlayerPrefs.SetString ("Level_1_mobs_zombie_spawndelay", "5"); //Количество зомби
        PlayerPrefs.SetString ("Level_1_mobs_zombie_hp", "100"); //Хп зомби
        PlayerPrefs.SetString ("Level_1_mobs_zombie_movespeed", "2"); //Скорость перемещения
        PlayerPrefs.SetString ("Level_1_mobs_zombie_damage", "100"); //Урон

        PlayerPrefs.SetString ("Level_2_transport", "Povozka"); //Транспорт
        PlayerPrefs.SetString ("Level_2_mobs_zombie_spawndelay", "5"); //Количество зомби
        PlayerPrefs.SetString ("Level_2_mobs_zombie_hp", "100"); //Хп зомби
        PlayerPrefs.SetString ("Level_2_mobs_zombie_movespeed", "2"); //Скорость перемещения
        PlayerPrefs.SetString ("Level_2_mobs_zombie_damage", "100"); //Урон

    }

    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}