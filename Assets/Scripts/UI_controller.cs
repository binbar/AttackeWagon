using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class UI_controller : MonoBehaviour {
    QuestController QuestController_script;
    public GameObject RM;

    public GameObject ControllerBonus; //бонус контроллер 

    public GameObject Bread; // Хлеб в процессе игры
    public GameObject Tooth; // Зуб в процессе игры
    public GameObject Carrot; // Морковка в процессе игры

    public GameObject Panel_win; // Панель при выигрыше
    public GameObject Bread_win; // Хлеб в процессе игры
    public GameObject Tooth_win; // Зуб в процессе игры

    public GameObject Panel_defeath; // Панель при поражении
    public GameObject Bread_defeath; // Хлеб в процессе игры
    public GameObject Tooth_defeath; // Зуб в процессе игры

    public DB dB;

    public PovokZKA Povozka;

    public Fly_mob_controller FMBC;

    bool FIX_BUG_Draw_Win_USE_ONE = false;

    void Start () {
        QuestController_script = GameObject.FindGameObjectWithTag ("Povozka").GetComponent<QuestController> ();
        DrawStats ();
        // Draw_Defeath ();
    }
    void CompleteLvl () {
        PlayerPrefs.SetString ("Level_" + PlayerPrefs.GetInt ("Current_opened_level"), "complete"); //Уровень завершен успещно
        PlayerPrefs.SetString ("Level_" + (PlayerPrefs.GetInt ("Current_opened_level") + 1), "open"); //Открыть следуйщий уровень
    }
    private void Update () {
        //  DrawStats ();
    }

    public void DrawStats () {
        RM.gameObject.GetComponent<ResourcesManager> ().Animation_bread (ControllerBonus.gameObject.GetComponent<LevelStats> ().Bread);
        RM.gameObject.GetComponent<ResourcesManager> ().Animation_tooth (ControllerBonus.gameObject.GetComponent<LevelStats> ().Tooth);
        //  Carrot.gameObject.GetComponent<Text> ().text = "" + PlayerPrefs.GetInt ("Carrot");
    }

    public void Delete_mobs () //Удалить мобов
    {
        /*
                GameObject[] Zombies;
                Zombies = GameObject.FindGameObjectsWithTag ("Zombi1");
                foreach (GameObject z in Zombies) {
                    Destroy (z);
                }
        */

        Delete_all_by_tag ("Zombi1");
        Delete_all_by_tag ("Fly_mob");
        // FMBC.CanSpawn=false;//Отключение спавна летающих мобов

    }

    public void Delete_all_by_tag (string tag_name) { //Удаление по всех обьектов с тегом
        GameObject[] arr_some_objs;

        arr_some_objs = GameObject.FindGameObjectsWithTag (tag_name);
        if (arr_some_objs.Length > 0) {
            foreach (GameObject some_one_arr_element in arr_some_objs) {
                Destroy (some_one_arr_element);
            }
        }
    }

    public void Draw_Win () {
        if (FIX_BUG_Draw_Win_USE_ONE == false) {

            QuestController_script.AddValueToQuest ("Q_Levels", 1);
            //  dB.SetRating (gameObject.GetComponent<LevelStats> ().Bread);//Старый рейтинг
            dB.SetRating (PlayerPrefs.GetInt ("Kill_mobs")); //Новый рейтинг(текущий)
            Povozka.Stop_on_win_or_defeat ();

            Panel_win.transform.gameObject.SetActive (true);
            // Bread_win.gameObject.GetComponent<Text> ().text = "" + gameObject.GetComponent<LevelStats> ().Bread;
            // Tooth_win.gameObject.GetComponent<Text> ().text = "" + gameObject.GetComponent<LevelStats> ().Tooth;
            CompleteLvl ();
            IncrementIntText (gameObject.GetComponent<LevelStats> ().Bread, Bread_win);
            IncrementIntText (gameObject.GetComponent<LevelStats> ().Tooth, Tooth_win);
            Delete_mobs ();
            FIX_BUG_Draw_Win_USE_ONE = true;
        }
    }

    public void Draw_Defeath () {
        //  dB.SetRating (gameObject.GetComponent<LevelStats> ().Bread);//Старый рейтинг
        dB.SetRating (PlayerPrefs.GetInt ("Kill_mobs")); //Новый рейтинг(текущий)

        Povozka.Stop_on_win_or_defeat ();

        Panel_defeath.transform.gameObject.SetActive (true);
        //StartCoroutine ("SlowIncrement", 100);
        IncrementIntText (gameObject.GetComponent<LevelStats> ().Bread, Bread_defeath);
        IncrementIntText (gameObject.GetComponent<LevelStats> ().Tooth, Tooth_defeath);
        Delete_mobs ();
        //   Bread_defeath.gameObject.GetComponent<Text> ().text = "" + gameObject.GetComponent<LevelStats> ().Bread;
        //   Debug.Log ("Хлеба за раунд " + gameObject.GetComponent<LevelStats> ().Bread);
        //Tooth_defeath.gameObject.GetComponent<Text> ().text = "" + gameObject.GetComponent<LevelStats> ().Tooth;
    }

    public async void IncrementIntText (float Target, GameObject SomeText) {
        int Time = 1000; // Время за которое требуеться завершить все операции в миллисекундах (1000 == 1 секунда)
        int Delay = 50; //Задержка между отрисовкой чисел (плавность отрисовки)
        int Limit = ((Time + 1000) / Delay); //Не обязательное ограничение на случай превышения времени (Time+1000 миллисекунд) и завершения отрисовки
        float Step = Time / Target; // Количество времени на 1 шаг

        System.Diagnostics.Stopwatch sw; //Создаем счётчик
        sw = System.Diagnostics.Stopwatch.StartNew (); //Запускаем счетчик

        for (int Stop = 0;
            (int) sw.ElapsedMilliseconds <= Time; Stop++) {
            if (SomeText != null) {
                SomeText.GetComponent<Text> ().text = "" + (int) (sw.ElapsedMilliseconds / Step);
            } else {
                break;
            }
            await Task.Delay (50);
            if (Stop >= Limit) {
                Debug.Log ("Ошибка!!!");
                break;
            }
        }
        if (SomeText != null) {
            SomeText.GetComponent<Text> ().text = "" + (int) Target;
        }
    }

    //IEnumerator SlowIncrement (int Target) {
    //    float Time = 5f; // Время за которое требуеться завершить все операции
    //    float Delay = Time / (Target + 1); // Задержка между каждой опирацией
    //    Debug.Log ("Target:" + Target);
    //    Debug.Log ("Delay:" + Delay);
    //    for (int i = 0; i <= Target; i++) {
    //        Bread_defeath.gameObject.GetComponent<Text> ().text = "" + i;
    //        Debug.Log ("Time:" + i);
    //        yield return new WaitForSeconds (Delay);
    //    }

}