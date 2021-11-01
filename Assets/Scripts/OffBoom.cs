using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffBoom : MonoBehaviour
{

    private void FixedUpdate()
    {
        Destroy(gameObject, 0.95f);
    }
}

