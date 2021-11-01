using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour {
    QuestController QuestController_script;
    public int Bread; //Хлеб за раунд
    public int Tooth; //Зубы за раунд
    public int DeatZombi;

    public void RewardInt (string name, int count) {
        PlayerPrefs.SetInt (name, PlayerPrefs.GetInt (name) + count);
        if (name == "Bread") {
            Bread += count;
QuestController_script.AddValueToQuest ("Q_Money", count);
     //       Debug.Log ("Добавлено " + count + " хлеба,теперь за раунд " + Bread + "хлеба");
        } else if (name == "Tooth") {
            Tooth += count;
        }

    }

    // Start is called before the first frame update
    void Start () {
        QuestController_script = GameObject.FindGameObjectWithTag ("Povozka").GetComponent<QuestController> ();
        Bread = 0;
        Tooth = 0;
    }

    // Update is called once per frame
    void Update () {

    }
}