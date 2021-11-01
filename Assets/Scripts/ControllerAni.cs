using UnityEngine;

public class ControllerAni : MonoBehaviour
{
    public Skills skill_container;

    public GameObject[] Wheels;
    public bool Rotation = true;
    public void RotateWheels(float gradus)
    {
        if (Rotation == true)
        {
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i].transform.Rotate(0, 0, gradus);
            }
        }
    }
    void Start() { }

    void FixedUpdate()
    {
        if (skill_container.skill_boost.Effect == true)
        { 
            RotateWheels(5.5f); //Вращать вращение колеса быстрее
        }
        else
        {
            RotateWheels(4.5f); //Вращать вращение колеса
        }

    }

}