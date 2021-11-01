using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Ani : MonoBehaviour
{
    public GameObject[] Light;
    // Start is called before the first frame update
    void Start()
    {
        
    }
  public void RotateLight (float gradus) {
            for (int i = 0; i < Light.Length; i++) {
                Light[i].transform.Rotate (0, 0, gradus);


            }
        }
    
     void FixedUpdate () {
            RotateLight (0.5f); //Вращать вращение колеса
        
    }
}
