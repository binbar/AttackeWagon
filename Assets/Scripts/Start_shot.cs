using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Start_shot : MonoBehaviour 
{
    public Stvol UnityEvent;
    public bool OnPointerEnter = false;
    //public bool OnPointerExet = false;
    public bool CanShoot = true;

     void Update () {
         if (OnPointerEnter )
         {
            if (CanShoot == true)
            {
             UnityEvent.Shoot_Button();
            }
         }
 
         else if ( !OnPointerEnter )
         {
          
         }
     }
     public void onPointerDownRaceButton()
     {
         OnPointerEnter = true;
     }
     public void onPointerUpRaceButton()
     {
         OnPointerEnter = false;
     }
 }

