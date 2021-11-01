using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject Weapon_1;
    public GameObject Boom_1;
    public GameObject Money_1;
    private State currentState; 

    private void Start()
    {
        WeaponOn();
        SetState(State.Weapon);
    }
    private void SetState(State state)
    {
        currentState = state;
        Weapon_1.SetActive(state == State.Weapon);
        Boom_1.SetActive(state == State.Boom);
        Money_1.SetActive(state == State.Money);
     
    }
    private enum State
    {
       Weapon,
       Boom,
       Money
    }
    public void WeaponOn()
    {
        SetState(State.Weapon);
    }
    public void BoomOn()
    {
        SetState(State.Boom);
    }
    public void MoneyOn()
    {
        SetState(State.Money);
    }
  
}
