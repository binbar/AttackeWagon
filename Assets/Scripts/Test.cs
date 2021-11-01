using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        for (int zombi = 1; zombi <= 5; zombi +=2)
        {
            Debug.Log("Зобми" + zombi);
        }
    }
}
