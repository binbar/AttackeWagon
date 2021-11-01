using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost {
    public bool cd = false;
    public PovokZKA povozka;
    public bool Effect = false;

    public void Use () { //Ефект
        if (cd == true) {
            //            Debug.Log ("Ускорение");
            Effect = true;

            povozka.speed = 5.5f + povozka.speed_default;

            povozka.Boost_animation ();
            cd = false;
            Cooldown ();
        }
    }

    public void Cooldown () {
        //  animator.SetBool ("1234", true);
    }

    public void End () { //Конец ефекта
        povozka.speed = povozka.speed_default;
        if (povozka.Removing_log_process == false) {
            povozka.Boost_animation_Idle ();
        }
        Effect = false;
    }

    public void End_A () { //Кулдаун после анимации кнопки
        cd = true;
    }

}

public class Skills : MonoBehaviour {
    public PovokZKA povozka;
    public Boost skill_boost;
    public GameObject A_button_skill_boost;
    public UPGRADE_controller upg_c;

    // private Animator animator;

    void Start () {

        //  animator = GetComponent<Animator>();
        //   animator.SetBool ("1234", false);
        //   animator.Stop();

        //  skill_boost = new Boost { povozka = povozka, cd = false, animator = animator };
        skill_boost = new Boost { povozka = povozka, cd = true };

        //  skill_boost.Cooldown ();//Нужно разкоментировать

    }

    public void Use_boost () { //Использовать ускорение

        skill_boost.Use ();
        Invoke ("End_boost", (((float)upg_c.Upgrade("Speed_skill")) / 10f)); //Длительность ефекта ускорения

        // Debug.Log ("Speed_skill ==" + ((float) upg_c.P ("Speed_skill")));
    }

    public void End_animation () //Закончить анимацию кнопки
    {
        skill_boost.End_A ();
    }

    public void End_boost () { //Закончить ефект ускорения
        skill_boost.End ();
    }

}