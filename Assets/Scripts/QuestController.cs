using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestController : MonoBehaviour {

    List<Quest> AllQuests = new List<Quest> (0);
    List<string> ActiveQuests_names = new List<string> (0);
    public GameObject Quest_obj_1;
    public GameObject Quest_obj_2;
    public Info info_top_panel;
    public GameObject Quest_button_1;
    public GameObject Quest_button_2;

    public GameObject Povozka_object;
    public float INVOKE_Q_Move_last_x;

    bool All_Install = false;
    static bool All_Invoke_Install = false;

    void Start () {

        Install ();
    }

    string SecondToMinutes (int Seconds) {
        string SM = "";
        int M = Seconds / 60; //Минуты
        SM += "" + M + ":";
        int S = Seconds % 60; //Секунды
        if (S < 10) {
            SM += "0" + S;
        } else {
            SM += "" + S;
        }
        return SM;
    }

    void FIRST_QUESTS () {
        SetQuest_is_any_slot ("Q_Time");
        GetQuestByName ("Q_Time").GenerateQuest ();

        SetQuest_is_any_slot ("Q_Move");
        GetQuestByName ("Q_Move").GenerateQuest ();
    }

    public void RefreshViewQuests () {
        All_Install = false;
        Install ();
    }

    //Инициализация всех настроек квестов
    public void Install () {

        if (All_Install == false) {
            Debug.Log ("All_Install");
            AllQuests.Clear ();
            AllQuests.Add (new Quest ("Q_KillZombies", Random.Range (60, 150), Random.Range (100, 450), Language.S_DailyQuests[0], "ОПИСАНИЕ")); // Убить n-количество зомби ++++++++++++++++
            AllQuests.Add (new Quest ("Q_FlyMob", Random.Range (15, 50), Random.Range (350, 1100), Language.S_DailyQuests[1], "ОПИСАНИЕ")); //Убить n- количество летающих обьектов ++++++++++++++++
            AllQuests.Add (new Quest ("Q_Move", Random.Range (320, 850), Random.Range (100, 300), Language.S_DailyQuests[2], "ОПИСАНИЕ")); //Проехать n-количество растояний [InvokeRepeating]
            AllQuests.Add (new Quest ("Q_Money", Random.Range (220, 830), Random.Range (100, 250), Language.S_DailyQuests[3], "ОПИСАНИЕ")); //Заработать n-количество монет ++++++++++++++++++++++
            AllQuests.Add (new Quest ("Q_Time", Random.Range (650, 2550), Random.Range (100, 550), Language.S_DailyQuests[4], "ОПИСАНИЕ")); // Провести в игре n-количество времени [InvokeRepeating] ++++++++++++++++++
            AllQuests.Add (new Quest ("Q_Levels", Random.Range (1, 1), Random.Range (100, 500), Language.S_DailyQuests[5], "ОПИСАНИЕ")); //Пройти любой уровень. ++++++++++++++++++++++++

            /*
            AllQuests.Add (new Quest ("Q_KillZombies", Random.Range (20, 50), Random.Range (100, 450), Language.S_DailyQuests[0], "ОПИСАНИЕ")); // Убить n-количество зомби ++++++++++++++++
            AllQuests.Add (new Quest ("Q_FlyMob", Random.Range (15, 45), Random.Range (200, 550), "Унитожить летающих обьектов", "ОПИСАНИЕ")); //Убить n- количество летающих обьектов ++++++++++++++++
            AllQuests.Add (new Quest ("Q_Move", Random.Range (100, 500), Random.Range (100, 300), "Проехать растрояние", "ОПИСАНИЕ")); //Проехать n-количество растояний [InvokeRepeating]
            AllQuests.Add (new Quest ("Q_Money", Random.Range (110, 220), Random.Range (100, 250), "Заработать золотых монет", "ОПИСАНИЕ")); //Заработать n-количество монет ++++++++++++++++++++++
            AllQuests.Add (new Quest ("Q_Time", Random.Range (100, 250), Random.Range (100, 1000), "Поиграть определенное время", "ОПИСАНИЕ")); // Провести в игре n-количество времени [InvokeRepeating] ++++++++++++++++++
            AllQuests.Add (new Quest ("Q_Levels", Random.Range (1, 10), Random.Range (100, 1000), "Пройти несколько уровней", "ОПИСАНИЕ")); //Пройти любой уровень. ++++++++++++++++++++++++
            //    AllQuests.Add (new Quest ("Q_MoveRating", Random.Range (1, 10), Random.Range (100, 1000), "Набрать рейтинг")); //Проехать в рейтинге 800 метров. [InvokeRepeating] ++++++++++++++++
*/
            FIRST_QUESTS ();

            GetQuests ();
            InstallActiveQuests (); //Составление списка активных квестов

            //Включает квесты если мы в игре(если есть повозка)
            if (GameObject.FindGameObjectsWithTag ("Povozka").Length > 0) {
                Debug.Log ("All_Invoke_Install");
                QuestOnStartLevel ();
            }

            RefreshStatusQuests ();
            ViewQuest ();
            All_Install = true;
        }
    }

    public string SLOT_Q_1;
    public string SLOT_Q_2;
    //Составление списка активных квестов
    void InstallActiveQuests () {
        ActiveQuests_names.Add (PlayerPrefs.GetString ("Quest_1"));
        ActiveQuests_names.Add (PlayerPrefs.GetString ("Quest_2"));
        for (int i = 0; i < ActiveQuests_names.Count; i++) {
            if (ActiveQuests_names[i] == "") {
                ActiveQuests_names.RemoveAt (i);
            }
        }
        SLOT_Q_1 = PlayerPrefs.GetString ("Quest_1");
        SLOT_Q_2 = PlayerPrefs.GetString ("Quest_2");
    }
    void GetQuests () {

        GetQuestButton ();
        Debug.Log ("Q1 GENERATED");
        GetQuestButton ();
        Debug.Log ("Q2 GENERATED");
    }
    void ViewQuest () {

        string name_q1 = PlayerPrefs.GetString ("Quest_1");
        string name_q2 = PlayerPrefs.GetString ("Quest_2");

        Debug.Log ("ViewQuest name_q1=" + name_q1);
        Debug.Log ("ViewQuest name_q2=" + name_q2);
        if (Quest_obj_1 != null && Quest_obj_2 != null) {
            //1-й слот квеста
            Quest_obj_1.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + GetQuestByName (name_q1).TextNameInQuestsForView;
            Quest_obj_1.gameObject.transform.GetChild (2).GetComponent<Text> ().text = "" + GetQuestByName (name_q1).GetRewardValue ();
            if (name_q1 == "Q_Time") {
                Quest_obj_1.gameObject.transform.GetChild (3).gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + SecondToMinutes (GetQuestByName (name_q1).GetCurrentValue ()) + " из " + SecondToMinutes (GetQuestByName (name_q1).GetTargetValue ());
            } else {
                Quest_obj_1.gameObject.transform.GetChild (3).gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + GetQuestByName (name_q1).GetCurrentValue () + " из " + GetQuestByName (name_q1).GetTargetValue ();
            }
            //2-й слот квеста
            Quest_obj_2.gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + GetQuestByName (name_q2).TextNameInQuestsForView;
            Quest_obj_2.gameObject.transform.GetChild (2).GetComponent<Text> ().text = "" + GetQuestByName (name_q2).GetRewardValue ();
            if (name_q2 == "Q_Time") {
                Quest_obj_2.gameObject.transform.GetChild (3).gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + SecondToMinutes (GetQuestByName (name_q2).GetCurrentValue ()) + " из " + SecondToMinutes (GetQuestByName (name_q2).GetTargetValue ());
            } else {
                Quest_obj_2.gameObject.transform.GetChild (3).gameObject.transform.GetChild (0).GetComponent<Text> ().text = "" + GetQuestByName (name_q2).GetCurrentValue () + " из " + GetQuestByName (name_q2).GetTargetValue ();
            }

        }
        // Quest_obj_1.
    }

    void QuestOnStartLevel () {
        //  InstallActiveQuests ();
        if (ActiveQuests_names.Count > 0) {
            InvokeStarter (PlayerPrefs.GetString ("Quest_1"));
            InvokeStarter (PlayerPrefs.GetString ("Quest_2"));

        } else {
            Debug.Log ("Нет квестов");
        }
    }

    //Использовать в процессе игры для зачисления 
    public void AddValueToQuest (string Input_Q_Name, int AddValue) {
        Debug.Log ("AddValueToQuest");
        Install ();

        if (CheckEnabledQuest (Input_Q_Name) == true) {
            Debug.Log ("CheckEnabledQuest= TRUE");

        } else {
            Debug.Log ("CheckEnabledQuest= FALSE");
        }

        if (CheckEnabledQuest (Input_Q_Name) == true) {
            if (SLOT_Q_1 == Input_Q_Name) {
                Debug.Log ("SLOT_Q_1 == Input_Q_Name");
                GetQuestByName (Input_Q_Name).AddToCurrentValue (AddValue, "Quest_1");

            } else if (SLOT_Q_2 == Input_Q_Name) {
                Debug.Log ("SLOT_Q_2 == Input_Q_Name");
                GetQuestByName (Input_Q_Name).AddToCurrentValue (AddValue, "Quest_2");
            }
        }
    }

    //Проверить включен ли квест(взят)
    bool CheckEnabledQuest (string Input_Q_Name) {
        if (ActiveQuests_names.Count > 0) {
            for (int i = 0; i < ActiveQuests_names.Count; i++) {
                if (ActiveQuests_names[i] == Input_Q_Name) {
                    return true;
                }
            }
            Debug.Log ("NOT HAVE IN ActiveQuests_names !!!");
            return false;
        } else {
            Debug.Log ("ActiveQuests_names.Count =" + ActiveQuests_names.Count);
            return false;
        }

    }

    //Включает или выключает квест
    void InvokeStarter (string Input_Q_Name) {
        if (Input_Q_Name == "Q_Move") {
            Povozka_object = GameObject.FindGameObjectsWithTag ("Povozka") [0];
            INVOKE_Q_Move_last_x = Povozka_object.transform.position.x;
            InvokeRepeating ("INVOKE_Q_Move", 0, 5f);
        }

        if (Input_Q_Name == "Q_Time") {
            Debug.Log ("InvokeStarter INVOKE_Q_Time");
            InvokeRepeating ("INVOKE_Q_Time", 0, 1f);
        }

        if (Input_Q_Name == "Q_MoveRating") {
            InvokeRepeating ("INVOKE_Q_MoveRating", 0, 5f);
        }

    }

    void INVOKE_Q_Move () { //Подсчет расстояния(везде)

        //   Debug.Log ("INVOKE_Q_Move_last_x RRRRRRRRRRRRRRR=" );
        AddValueToQuest ("Q_Move", (int) (INVOKE_Q_Move_last_x - (Povozka_object.transform.position.x)));

        INVOKE_Q_Move_last_x = Povozka_object.transform.position.x;

        //Povozka_object.transform.position.x
    }

    void INVOKE_Q_Time () { //Подсчет времени
        Debug.Log ("INVOKE_Q_Time");
        AddValueToQuest ("Q_Time", 1);
    }

    void INVOKE_Q_MoveRating () { //Подсчет расстояния(только в рейтинге)

    }

    public Quest GetQuestByName (string Q_Name) {
        Quest Return_Quest = new Quest ("", 0, 0, "", "");
        for (int i = 0; i < AllQuests.Count; i++) {
            if (AllQuests[i].NameQuest == Q_Name) {
                Return_Quest = AllQuests[i];
            }
        }
        if (Return_Quest.NameQuest == "") {
            Debug.Log ("ERROR!!! GetQuestByName() Return_Quest.NameQuest is EMPTY or NOT FOUND");
        }
        return Return_Quest;
    }

    //Завершить квест в слоте 1
    public void EndQuest_1 () {
        EndQuestBySlot ("Quest_1");
    }

    //Завершить квест в слоте 2
    public void EndQuest_2 () {
        EndQuestBySlot ("Quest_2");
    }

    void EndQuestBySlot (string NameSlot) {

        if (PlayerPrefs.GetString (NameSlot + "_Status") == "Complete") {

            PlayerPrefs.SetInt ("Bread", (PlayerPrefs.GetInt ("Bread") + GetQuestByName (PlayerPrefs.GetString (NameSlot)).GetRewardValue ()));
            PlayerPrefs.SetString (NameSlot + "_Status", "NotComplete");

            GetQuestByName (PlayerPrefs.GetString (NameSlot)).SetNoGenerated (); //Установить значение "no" чтоб квест пересоздался с новыми характеристиками

            PlayerPrefs.SetString (NameSlot, ""); //Удаляем квест

            GetQuests (); //Взять новые квесты
            RefreshStatusQuests (); //Обновить статус квестов
            ViewQuest (); //Отрисовать квесты
            info_top_panel.Draw_money (); //Обновить UI с валютами
        }
    }

    void RefreshStatusQuests () {
        if (Quest_button_1 != null && Quest_button_2 != null) {
            string name_q1 = PlayerPrefs.GetString ("Quest_1");
            string name_q2 = PlayerPrefs.GetString ("Quest_2");

            Debug.Log ("name_q1" + name_q1);
            Debug.Log ("name_q2" + name_q2);

            if (name_q1 != "" && GetQuestByName (name_q1).GetCurrentValue () >= GetQuestByName (name_q1).GetTargetValue ()) {
                PlayerPrefs.SetString ("Quest_1" + "_Status", "Complete"); //Делает квест завершенным
                Debug.Log ("КВЕСТ 1 ВЫПОЛНЕН");
                //  GetQuestByName (name_q1).SetNoGenerated ();

                Quest_button_1.GetComponent<Button> ().interactable = true;
            } else {
                Quest_button_1.GetComponent<Button> ().interactable = false;
                Debug.Log ("КВЕСТ 1 НЕ ВЫПОЛНЕН");
            }

            if (name_q2 != "" && GetQuestByName (name_q2).GetCurrentValue () >= GetQuestByName (name_q2).GetTargetValue ()) {
                PlayerPrefs.SetString ("Quest_2" + "_Status", "Complete"); //Делает квест завершенным
                Quest_button_2.GetComponent<Button> ().interactable = true;
                Debug.Log ("КВЕСТ 2 ВЫПОЛНЕН");
            } else {
                Quest_button_2.GetComponent<Button> ().interactable = false;
                Debug.Log ("КВЕСТ 2 НЕ ВЫПОЛНЕН");
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Quest {
        public string NameQuest;
        //  public int TargetNumber;
        public string TextNameInQuestsForView;
        public string TextDescription;

        public string Description;
        int Target_For_Generate; //Временное значение для генерации
        int Reward_For_Generate; //Временное значение для генерации

        public void CalculateStatusQuest_by_slot (string NameSlot) { //ВОЗМОЖНО НЕ НУЖНО CalculateStatusQuest_by_slot !!!!!!!!!!!!!!!!!!!!!!!!!!
            if (PlayerPrefs.GetString (NameSlot + "_Status") != "Complete") {
                if (GetCurrentValue () >= GetTargetValue ()) { //Если текущее значение больше или равно то засчитываем выполнение квеста
                    //  PlayerPrefs.SetInt (NameSlot + "_Reward", PlayerPrefs.GetInt (NameQuest + "_Reward"));//ВОЗМОЖНО НЕ НУЖНО !!!!!!!!!!!!!!!!!!!!!!!!!!
                    // PlayerPrefs.SetString (NameQuest + "_Generated", "no"); //Для сброса генерации
                    PlayerPrefs.SetString (NameSlot + "_Status", "Complete"); //Делает квест завершенным

                }
            }
        }

        //Получить текущее значение
        public int GetCurrentValue () {
            return PlayerPrefs.GetInt (NameQuest + "_CurrentValue");
        }
        //Установить текущее значение
        public void SetCurrentValue (int NewCurrentValue) {
            PlayerPrefs.SetInt (NameQuest + "_CurrentValue", NewCurrentValue);
        }
        //Добавить к текущему значению
        public void AddToCurrentValue (int Add, string Input_NameSlot) {
            PlayerPrefs.SetInt (NameQuest + "_CurrentValue", (PlayerPrefs.GetInt (NameQuest + "_CurrentValue") + Add));
            //     CalculateStatusQuest_by_slot (Input_NameSlot);//ВОЗМОЖНО НЕ НУЖНО !!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        //Установить целевое значение
        public void SetTargetValue (int NewTargetValue) {
            PlayerPrefs.SetInt (NameQuest + "_TargetValue", NewTargetValue);
        }
        //Получить целевое значение
        public int GetTargetValue () {
            return PlayerPrefs.GetInt (NameQuest + "_TargetValue");
        }

        //Получить значение награды
        public int GetRewardValue () {
            return PlayerPrefs.GetInt (NameQuest + "_Reward");
        }

        public void SetNoGenerated () {
            PlayerPrefs.SetString (NameQuest + "_Generated", "no");
        }

        public void GenerateQuest () {
            if (PlayerPrefs.GetString (NameQuest + "_Generated") != "yes") {
                PlayerPrefs.SetInt (NameQuest + "_Reward", Reward_For_Generate);
                SetCurrentValue (0);
                SetTargetValue (Target_For_Generate);
                PlayerPrefs.SetString (NameQuest + "_Generated", "yes");

            }
        }

        public Quest (string NameQuest, int Target_For_Generate, int Reward_For_Generate, string TextNameInQuestsForView, string TextDescription) {
            this.NameQuest = NameQuest;
            this.Target_For_Generate = Target_For_Generate; //Временное значение для генерации
            this.Reward_For_Generate = Reward_For_Generate; //Временное значение для генерации
            this.TextNameInQuestsForView = TextNameInQuestsForView;
            this.TextDescription = TextDescription;
        }

    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Имя нового квеста,не из списка тех что есть уже(не взятых)
    string New_Random_Quest_Name () {
        List<string> Q_Names_not_getted = new List<string> (0);
        for (int i = 0; i < AllQuests.Count; i++) {
            if (PlayerPrefs.GetString ("Quest_1") != AllQuests[i].NameQuest && PlayerPrefs.GetString ("Quest_2") != AllQuests[i].NameQuest) { // Проверить есть ли уже в списке квестов это имя квеста
                Q_Names_not_getted.Add (AllQuests[i].NameQuest);
            }
        }
        string Random_quest_name = Q_Names_not_getted[Random.Range (0, Q_Names_not_getted.Count)]; //Выбираем случайное имя
        return Random_quest_name;
    }

    //Взять квест по нажатию на кнопку
    public void GetQuestButton () {
        if (AnyEmptySlot () == true) {
            string Some_name_quest = New_Random_Quest_Name ();
            Debug.Log ("Some_name_quest=" + Some_name_quest);
            SetQuest_is_any_slot (Some_name_quest);
            GetQuestByName (Some_name_quest).GenerateQuest ();
        }
    }

    //Проверка есть ли свободные слоты
    bool AnyEmptySlot () {
        if (PlayerPrefs.GetString ("Quest_1") == "") {
            return true;
        }
        if (PlayerPrefs.GetString ("Quest_2") == "") {
            return true;
        }
        return false;
    }

    //Установить квест по названию 
    void SetQuest_is_any_slot (string InputQuest) {
        if (PlayerPrefs.GetString ("Quest_1") == "") {
            PlayerPrefs.SetString ("Quest_1", InputQuest);
        } else if (PlayerPrefs.GetString ("Quest_2") == "") {
            PlayerPrefs.SetString ("Quest_2", InputQuest);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}