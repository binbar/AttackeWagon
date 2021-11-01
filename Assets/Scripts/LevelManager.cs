using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level {
    public int Number; //Уровень
    private string Status_local; //complete - завершенный, open - открытый 
    public string Status {
        get {
            string result = PlayerPrefs.GetString ("Level_" + Number);
            Debug.Log ("GET result=" + result);
            return result;
        }

        set {
            Status_local = value;
            PlayerPrefs.SetString ("Level_" + Number, value);
        }

    }
    public Image Img; //Картинка уровня(ссылка на картинку)
    public Level (int Number_, Image Img_) {
        Number = Number_;
        Img = Img_;
    }

}

public class LevelManager : MonoBehaviour {
    public LoadingSRC LoadingSRC_script;
    Level[] Levels = new Level[68]; //Уровни (менять в 3-х местах)

    public Image[] Levels_image = new Image[68]; //Картинки уровней которые нужно менять в зависимости от доступности(можно играть или нет)

    public Sprite CanPlay; //Можно играть на уровне
    public Sprite Close; //Нельзя играть на уровне
    public GameObject[] Reward_OBJ_Array; //
    public Info info_top_panel; //Панель с деньгами

    void Start () {

        Install_levels ();
        LoadStatus ();
        /*
        for (int i = 0; i < length; i++)
        {
            Levels[Lvl_number].Status == "complete"
        }

        */
        Install_RewardsLevels ();
    }

    //Инициализация уровней
    void Install_levels () {
        for (int i = 0; i < 68; i++) {
            Levels[i] = new Level (i + 1, Levels_image[i]);
        }
    }
    void Install_RewardsLevels () {
        LoadRewardLevels ();
        DrawRewardLevels ();
    }

    void LoadRewardLevels () {
        LoadRewardOneLevel ("LVL_REWARD_2500", 4);
        LoadRewardOneLevel ("LVL_REWARD_BOOMB", 7);
        LoadRewardOneLevel ("LVL_REWARD_4500", 12);
        LoadRewardOneLevel ("LVL_REWARD_5000", 18);
        LoadRewardOneLevel ("LVL_REWARD_8000", 29);
        LoadRewardOneLevel ("LVL_REWARD_10000", 43);
        LoadRewardOneLevel ("LVL_REWARD_15000", 55);
        LoadRewardOneLevel ("LVL_REWARD_20000", 62);
    }

    void LoadRewardOneLevel (string NameReward, int SomeLevel) {
        SomeLevel+=-2;
        if (PlayerPrefs.GetString (NameReward) != "TAKEN") { //Если награда еще не забиралась
            if (Levels[SomeLevel].Status == "complete") { //Если уровень пройден
                Debug.Log ("ЗАГРУЗКА" + NameReward + " награду можно забрать=YES");
                PlayerPrefs.SetString (NameReward, "YES"); //Делаем возможность забрать награду
            }
        }
    }

    void DrawRewardLevels () { //Отрисовка кнопок
        DrawRewardOneLevel ("LVL_REWARD_2500", Reward_OBJ_Array[0]);
        DrawRewardOneLevel ("LVL_REWARD_BOOMB", Reward_OBJ_Array[1]);
        DrawRewardOneLevel ("LVL_REWARD_4500", Reward_OBJ_Array[2]);
        DrawRewardOneLevel ("LVL_REWARD_5000", Reward_OBJ_Array[3]);
        DrawRewardOneLevel ("LVL_REWARD_8000", Reward_OBJ_Array[4]);
        DrawRewardOneLevel ("LVL_REWARD_10000", Reward_OBJ_Array[5]);
        DrawRewardOneLevel ("LVL_REWARD_15000", Reward_OBJ_Array[6]);
        DrawRewardOneLevel ("LVL_REWARD_20000", Reward_OBJ_Array[7]);
    }

    void DrawRewardOneLevel (string NameReward, GameObject RewardOBJ) {
        if (CheckAvailableReward (NameReward) == true) { //Если награда доступна(то есть можно забрать)
            RewardOBJ.SetActive (true);
        } else { //Если награда недоступна(нельзя забрать)
            RewardOBJ.SetActive (false);
        }
    }

    public void GetRewardLevel (string NameReward) {
        if (NameReward == "LVL_REWARD_2500") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 2500)); //Тут выдача награды
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        if (NameReward == "LVL_REWARD_BOOMB") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("" + 12, 1); //Тут выдача награды динамит
                PlayerPrefs.SetInt ("" + 16, (PlayerPrefs.GetInt ("" + 16) + 5)); //Тут выдача награды боеприпасы динамита
                Debug.Log ("LVL_REWARD_BOOMB награда получена");
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        if (NameReward == "LVL_REWARD_4500") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 4500)); //Тут выдача награды
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        if (NameReward == "LVL_REWARD_5000") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 5000)); //Тут выдача награды
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        if (NameReward == "LVL_REWARD_8000") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 8000)); //Тут выдача награды
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        if (NameReward == "LVL_REWARD_10000") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 10000)); //Тут выдача награды
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        if (NameReward == "LVL_REWARD_15000") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 15000)); //Тут выдача награды
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        if (NameReward == "LVL_REWARD_20000") {
            if (CheckAvailableReward (NameReward) == true) {
                PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + 20000)); //Тут выдача награды
                PlayerPrefs.SetString (NameReward, "TAKEN");
            }
        }
        info_top_panel.Draw_money (); //Обновить UI с валютами
        DrawRewardLevels (); //Отрисоавать 
    }

    bool CheckAvailableReward (string NameReward) {
        bool result = false;
        if (PlayerPrefs.GetString (NameReward) == "YES") {
            result = true;
        }
        return result;
    }

    //Отрисовка картинок
    void LoadStatus () {
        foreach (Level Lvl in Levels) {
            Debug.Log ("foreach");
            if (Lvl.Status == "open" || Lvl.Status == "complete") { //Если уровень "открыт" или "пройден" то меняем картинку
                Lvl.Img.sprite = CanPlay;
            } else {
                Debug.Log ("LVL");
                Lvl.Img.sprite = Close;
            }
        }
    }

    //Открытие уровня(повесить на кнопку)
    public void OpenLevel (int Lvl_number) {
        Debug.Log ("OpenLevel" + Lvl_number);
        Lvl_number += -1; //Нужно делать -1,потому что в массиве оно расположено по индексу
        if (Levels[Lvl_number].Status == "open" || Levels[Lvl_number].Status == "complete") { //Если уровень "открыт" или "пройден" то можем на него зайти
            Debug.Log ("OpenLevel OK");
            PlayerPrefs.SetInt ("Current_opened_level", Levels[Lvl_number].Number);
            //   Application.LoadLevel ("Какой то префикс_" + Lvl_number); //Открываем сцену с уровнем по названию
            // SceneManager.LoadScene("Level_" + Levels[Lvl_number].Number);//WORK
            Debug.Log ("LevelManager");
            PlayerPrefs.SetInt ("Opened_levels_AD", (PlayerPrefs.GetInt ("Opened_levels_AD") + 1));
            PlayerPrefs.SetInt ("Count_Opened_levels", (PlayerPrefs.GetInt ("Count_Opened_levels") + 1));

          LoadingSRC_script.LoadSomeLvl ("Level_" + Levels[Lvl_number].Number);
        }
    }

    //Удачное завершение уровня при прохождении(ВЫНЕСТИ В ДРУГОЙ СКРИПТ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!)
    void CompleteLvl () {
        PlayerPrefs.SetString ("Level_" + PlayerPrefs.GetInt ("Current_opened_level"), "complete"); //Уровень завершен успещно
        PlayerPrefs.SetString ("Level_" + (PlayerPrefs.GetInt ("Current_opened_level") + 1), "open"); //Открыть следуйщий уровень
    }

    //При первом открытие(ВЫНЕСТИ В ДРУГОЙ СКРИПТ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!)
    void FirstOpen () {
        PlayerPrefs.SetString ("Level_" + 1, "open");
    }
}