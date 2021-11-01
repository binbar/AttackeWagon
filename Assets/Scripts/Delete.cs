using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {
    public float TimeToDestroy;
    void Start () {
       // TimeToDestroy=2f;
        Destroy (gameObject, TimeToDestroy);
    }

}