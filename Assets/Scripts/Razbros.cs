using System.Collections;
using UnityEngine;
public class Razbros : MonoBehaviour {
    float iy;
    float x;
    Vector3 povorot;
    Vector3 povorotx;
   public float minRazbros = -0.1f;
   public float maxRazbros = 0.1f;
    float minR;


    public void Update () {
        /*
                x = Random.Range(minRazbros, maxRazbros);
                iy = Random.Range(minRazbros, maxRazbros);




                povorot = transform.localRotation.eulerAngles;
                povorot.y = iy;
                Debug.Log(povorot);
                transform.localRotation = Quaternion.Euler(povorot);

                povorotx = transform.localRotation.eulerAngles;
                povorotx.x = x;
                transform.localRotation = Quaternion.Euler(povorotx);
*/

        x = Random.Range (minRazbros, maxRazbros);
       // y = Random.Range (minRazbros, maxRazbros);
        transform.position = new Vector3 (x, transform.position.y, transform.position.z);

    }
}