using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;
    bool shake = false;
    public bool alive = true; //Состояние повозки,true если жива
    float MinShake;
    float MaxShake;
    GameObject TextRating;

    private void Awake () {
        if (!target) target = FindObjectOfType<PovokZKA> ().transform;
        UpdatePatch ();
    }

    public void ShakeCamera (float InputMinShake, float InputMaxShake) {
        MinShake = InputMinShake;
        MaxShake = InputMaxShake;
        shake = true;
        Invoke ("ShakeCameraOff", 0.1f);
    }
    void ShakeCameraOff () {
        shake = false;
    }

    private void Update () {
        if (alive == true) {
            //   Vector3 position = target.position; 
            Vector3 position = new Vector3 (target.position.x + 3f, 0.0f, -5.0F);
            //  position.z = -10.0F;
            //  position.y = 0.0F;

            if (shake == true) {
                transform.position = new Vector3 ((transform.position.x + Random.Range (MinShake, MaxShake)), transform.position.y, transform.position.z);
            }
            transform.position = Vector3.Lerp (transform.position, position, speed * Time.deltaTime);

        }

    }
    ////////////////////////// Патчи,обновления(внизу) ///////////////////////
    void UpdatePatch () {
        //  Instantiate (prefab,parent);
        //  Instantiate(Resources.Load(pathOfPrefabDirectory+prefabName));
        //  GameObject.FindGameObjectsWithTag("Canvas");
        TextRating = Instantiate (Resources.Load ("Rating", typeof (GameObject)), GameObject.FindGameObjectsWithTag ("Canvas") [0].transform) as GameObject;
        TextRating.GetComponent<Text> ().text = "" + Language.GameMain[0] + "" + +PlayerPrefs.GetInt ("Kill_mobs");
        InvokeRepeating ("UpdateText", 1f, 1f);
    }

    void UpdateText () {
        TextRating.GetComponent<Text> ().text = "" + Language.GameMain[0] + "" + +PlayerPrefs.GetInt ("Kill_mobs");

    }

}