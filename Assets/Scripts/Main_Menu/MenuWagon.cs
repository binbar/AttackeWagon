using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWagon : MonoBehaviour
{
    public GameObject Wagon_0;
    public GameObject Boat_1;
    public GameObject Brougham_1;
    public GameObject Train_1;
    private State currentState; //текущее состояние (стреляет, перезаряжается или ничего не делает?)

    private void Start()
    {
        SetState(State.Wagon0);
    }
    private void SetState(State state)
    {
        currentState = state;
        Wagon_0.SetActive(state == State.Wagon0);
        Boat_1.SetActive(state == State.Boat);
        Brougham_1.SetActive(state == State.Brougham);
        Train_1.SetActive(state == State.Train);
    }
    private enum State
    {
        Wagon0,
        Boat,
        Brougham,
        Train
    }
    public void Wagon0On()
    {
        SetState(State.Wagon0);
    }
    public void BoatOn()
    {
        SetState(State.Boat);
    }
    public void BroughamOn()
    {
        SetState(State.Brougham);
    }
    public void TrainOn()
    {
        SetState(State.Train);
    }
}
