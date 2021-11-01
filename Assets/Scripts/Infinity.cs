using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinity : MonoBehaviour {
    public Spawner Spawner_script;
    public GameObject Povozka;

    int Wave = 1; //Текущая должна начинаться с 1(текущая)
    const int Stage_Limit = 3; //Количество стадий
    float Distance_wave = 50f; //!Дистанция смены волны(каждых X расстояния будет новая волна,чем дальше от точки тем больше волна)

    int Stage_now; //Стадия на данный момент(текущая)
    int Multipiler_now; //Стадия на данный момент(текущая)

    //Наземные мобы(зомби)
    // int Count_default = 10; //Базовое количество (множиться на волну(Wave))
    int Hp_default = 265; //!Базовое количество хп (множиться на множитель(Multipiler_now))

    //  float Damage_default = 100; //Урон (множиться на множитель(Multipiler_now))

    //Летающие мобы(коробки)
    int Fly_Count_default = 10; //Базовое количество (множиться на волну(Wave))
    float Fly_Hp_default = 100; //Базовое количество хп (множиться на множитель(Multipiler_now))
    float Fly_Damage_default = 100; //Урон (множиться на множитель(Multipiler_now))

    void Set_Stage_And_Multipiler_By_Wave (int input_wave) { //Определить стадию,и множитель по волне и вызвать установку параметров
        int Multipiler = (input_wave / Stage_Limit) + 1; //+1 Чтоб начинался не с нуля

        int output_stage = ((input_wave % Stage_Limit));
        if (output_stage == 0) {
            output_stage = Stage_Limit; //
            Multipiler--;
        }
        if (Stage_now != output_stage || Multipiler_now != Multipiler) {
            Stage_now = output_stage;
            Multipiler_now = Multipiler;
            //  SetParametrs (); //Устанавливает параметры в зависимости от стадии и множителя
            int NewHp=(Hp_default * Stage_now)+(Hp_default * Multipiler_now);
            Spawner_script.SetNodesParametrs (NewHp); //Устанавливает параметры в зависимости от стадии и множителя
        }

        Debug.Log ("Wave= " + input_wave + " Stage= " + output_stage + " Multipiler= " + Multipiler);
    }

    void ClaculateWave () { //Определить волну в зависимости от дистанции 
        float input_distance = (Povozka.transform.position.x * -1);

      //  Debug.Log ("input_distance=" + input_distance);
        int ClaculatedWave = ((int) (input_distance / Distance_wave));
     //   Debug.Log ("ClaculatedWave=" + ClaculatedWave);

        if (ClaculatedWave < 1) {
            ClaculatedWave = 1;
            Debug.Log ("ClaculatedWave CHANGE TO 1");
        }

        if (ClaculatedWave != Wave) //Волна изменилась
        {
            Wave = ClaculatedWave;
            Set_Stage_And_Multipiler_By_Wave (Wave);

        }
    }

    void Start () {
        ClaculateWave ();
        InvokeRepeating ("ClaculateWave", 1f, 1f);
        for (int i = 1; i <= 12; i++) {

        }

    }

    // Update is called once per frame
    void Update () {

    }
}