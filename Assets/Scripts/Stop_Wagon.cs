using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Wagon : MonoBehaviour {
    public PovokZKA speedpovozka;
    public Naezdnik naezdnik;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Povozka") {
            speedpovozka.StopMove ();
            Invoke ("Start_jump", 0.40f);
        }
    }
    public void Start_jump () {
        naezdnik.is_jump();
    }

}