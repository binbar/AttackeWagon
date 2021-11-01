using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHorse : MonoBehaviour {

  public float distance; // Дистанция 
  public PovokZKA stopPovozka;
  public Naezdnik naezdnik;
  public bool onRay;

public void Start (){
  onRay = true;
}
  void Update () {

    var origin = new Vector2 (transform.position.x, transform.position.y);
    var dir = new Vector2 (-1, 0);
    RaycastHit2D hit2D = Physics2D.Raycast (origin, dir,3);
if(onRay == true)
{
    if (hit2D.collider != null) {

     // Debug.DrawRay (transform.position, -transform.right * distance, Color.green);

      if (hit2D.collider.gameObject.tag == "Bochka") {
      //  Debug.Log ("Впереди бревно");
        naezdnik.Bochka = hit2D.collider.gameObject;
        stopPovozka.StopMove ();
        onRay = false;

      }
   // Debug.Log ("Райкаст вижу " + hit2D.collider.gameObject.name + "#TAG#" + hit2D.collider.gameObject.tag);

    }
  //  Debug.Log ("Райкаст вижу " + hit2D.collider.gameObject.name + "#TAG#" + hit2D.collider.gameObject.tag);

  }
  }
}