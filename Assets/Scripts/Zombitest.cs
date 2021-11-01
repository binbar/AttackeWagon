using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombitest : MonoBehaviour
{
    float speed = 1.2f;
    public float minimum = 0.3F;
    public float maximum = 0.2F;
    public GameObject povozka;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, povozka.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, speed * Time.deltaTime), -2, -2);
        
    }
}

