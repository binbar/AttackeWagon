using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Off : MonoBehaviour
{
    public GameObject Character_C;
   // public GameObject Character_B;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CharacterOn()
    {
        if (Character_C)
        {
            Character_C.SetActive(true);
        }
        else
        {
            Character_C.SetActive(false);
        }
    }

}
