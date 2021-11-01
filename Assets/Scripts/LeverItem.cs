using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverItem : MonoBehaviour
{
    public GameObject Charcter_1;
    public GameObject Horse_1;
    public GameObject Cab_1;
    public GameObject Wagon_1;
    private State currentState; //текущее состояние (стреляет, перезаряжается или ничего не делает?)

    private void Start()
    {
        SetState(State.Charcter);
    }
    private void SetState(State state)
    {
        currentState = state;
        Charcter_1.SetActive(state == State.Charcter);
        Horse_1.SetActive(state == State.Horse);
        Cab_1.SetActive(state == State.Cab);
        Wagon_1.SetActive(state == State.Wagon);
    }
    private enum State
    {
        Charcter,
        Horse,
        Cab,
        Wagon
    }
  public  void CharcterOn ()
    {
        SetState(State.Charcter);
    }
   public void HorseOn()
    {
        SetState(State.Horse);
    }
   public void CabOn()
    {
        SetState(State.Cab);
    }
    public void WagonOn()
    {
        SetState(State.Wagon);
    }
}

