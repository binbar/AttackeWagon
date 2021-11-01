using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Hp_Zombi : MonoBehaviour
{
    [SerializeField] private Transform bar;

    public void SetSize(float sizeNormalized)
    {
      //  Debug.Log("sizeNormalized="+sizeNormalized);
        if (sizeNormalized >= 0)
        {
            bar.localScale = new Vector3(sizeNormalized, 1f);
        }
        else if (sizeNormalized<=1f)
        {
            bar.localScale = new Vector3(sizeNormalized, 0);
        }
    }

}