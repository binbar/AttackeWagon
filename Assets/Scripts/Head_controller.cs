using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_controller : MonoBehaviour, IDamagable
{
    [SerializeField] private Zombi1 _zombie; // Ссылка на нашего Зомби
    [SerializeField] private int _damageMultiplayer = 3; // Множитель урона
    public void GetDamage(int damage)
    {
        int valueDamage = damage * _damageMultiplayer;

        // Debug.Log($"Head damage:  {damage}   x{_damageMultiplayer}: ({valueDamage})");//! что здесь в консоль выводиться?

        _zombie.GetDamage(valueDamage);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        
    }

}