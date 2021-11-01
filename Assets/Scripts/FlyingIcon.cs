using UnityEngine;
using UnityEngine.Events;

using Lean.Pool;

using DG.Tweening;
using System;

public class FlyingIcon : MonoBehaviour, IPoolable
{
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private GameObject _onSpawn;
    [SerializeField] private GameObject _onDeSpawn;

    public void Fly(Transform target, Action onComplete = null)
    {
        transform
            .DOMove(target.position, _duration)
            .OnComplete( () => 
            {
                onComplete?.Invoke();
                LeanPool.Despawn(this);
            } );
    }
    public void OnDespawn()
    {
        _onSpawn.SetActive(true);
    }

    public void OnSpawn()
    {
        _onDeSpawn.SetActive(true);
    }
}
