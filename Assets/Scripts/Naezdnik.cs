using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naezdnik : MonoBehaviour {
    public UPGRADE_controller upg_c;

    public float speed = 1;
    public bool second = false;
    public GameObject Povozka;
    public PovokZKA povokzka;
    public GameObject Bochka;
    public Transform Pos_povozka;

    public bool Move;
    public bool Damage_on;
    public bool onLog;
    private Animator animator;

    public void OnStart () {

        Move = false;
        Damage_on = true;
        onLog = true;
        animator.SetBool ("isJump", false);
        animator.SetBool ("isRun", false);
        animator.SetBool ("isAttake", false);
        animator.SetBool ("isRunRight", false);
        animator.SetBool ("CabIdle", true);

    //    Debug.Log ("Сбрасываю ");
    }

    private void Start () {
        PlayerPrefs.SetInt ("Carrot", PlayerPrefs.GetInt ("Carrot") + 10);
        animator = GetComponent<Animator> ();
        Move = false;
        Damage_on = true;
        onLog = true;
    }

    public void is_jump () {
        animator.SetBool ("isJump", true);
        Move = true;
    }

    private void Update () {
        if (Move == true) {
//            Debug.Log (" я в Апдейте_Мув " + Move);
            if (Bochka) {
             //   Debug.Log (" я в Апдейте_Бочка " + Bochka);
                RunNaezdnik ();
            } else {
                // RunNaezdnik();
                Move = false;
            }

        }
        if (onLog == false) {
            RunNaezdnikWagon ();
        }
    }

    public void RunNaezdnik () // идем к бревну
    {
        if (Move == true) {
            if (Bochka) {
                // animator.SetBool("isJump", false);
                animator.SetBool ("isAttake", false);
                animator.SetBool ("isRun", true);
//                Debug.Log ("Движение к бочке");
                Vector3 direction = -transform.right;
                transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);
                Move = true;
            } else {
                Move = false;
            }
        }

    }

    public void RunNaezdnikWagon () //возвращаемся к повозке 
    {
        animator.SetBool ("isAttake", false);
        animator.SetBool ("isJump", false);
        animator.SetBool ("isRunRight", true);
        animator.SetBool ("CabIdle", false);
      //  Debug.Log ("Движение к Повозке");
        Vector3 direction = transform.right;
        transform.position = Vector3.MoveTowards (transform.position, Pos_povozka.position + direction, speed * Time.deltaTime);
        if (Vector2.Distance (transform.position, Pos_povozka.position) < 0.1f) {
            onLog = true;
            animator.SetBool ("isJump", false);
            animator.SetBool ("CabIdle", true);
            povokzka.StartMove ();
            povokzka.Removing_log_process = false;
            OnStart ();

         //   Debug.Log ("Прыжок на повозку!!!!!");

        }

        //  do some

    }
    // при столкновении с обьектом вызвается функция
    private void OnTriggerEnter2D (Collider2D collision) {
        if (Move == true) {
            if (collision.gameObject.tag == "Bochka") {

                Move = false;
                Bochka = collision.gameObject;
                animator.SetBool ("isRun", false);
                animator.SetBool ("isAttake", true);
                Damage_on = true;

            //    Debug.Log ("DAMAGE!!!!!!!!!!!!!!!!!!!!");
                //StartDamage(); 
            }
        }
    }

    public void StartDamage () {
     //   Debug.Log ("StartDamage");
        Damage (Bochka, -(upg_c.Upgrade ("Power")) ); // отнимаем хп у бревна 

        if (Damage_on == true) {
            Invoke ("StartDamage", 1.0F); // вызывает функцию каждую секунду
        } else {
            onLog = false;
       //     Debug.Log ("Бочка уничтожена");

        }
    }

    public void Damage (GameObject Bochka_obj, int Damage) {
        if (Bochka_obj != null) {
        //    Debug.Log ("Damage");
            Damage_on = Bochka_obj.gameObject.GetComponent<Bochka> ().BochkaController (Damage); // отнимает хп
        }
    }

    public void GoLogColor () {
        if (Bochka != null) {
            Bochka.GetComponent<SpriteRenderer> ().color = new Color (1f, 0.4f, 0f, 1f);
            StartDamage ();
        }
    }

    public void LogColor () {
        if (Bochka != null) {
            Bochka.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
        }
    }
}