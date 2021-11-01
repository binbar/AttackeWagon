using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILog : MonoBehaviour
{
    private Transform bar;

   private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetSizeLog(float sizeNormalized)
    {
        bar.localScale =  new Vector3(sizeNormalized, 1f);
//           Debug.Log("Сит Сайз = " + sizeNormalized);
    }
}