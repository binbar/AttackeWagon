using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Balloon : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTrow;
    private Animator _animator;
    private Action _onCompleteBoom;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Boom(Action onComplete = null)
    {
        _onCompleteBoom = onComplete;
        _animator.SetTrigger("Boom");
    }
    public void Restat()
    {
        gameObject.SetActive(true);
    }
    public void Trow()
    {
        _onTrow.Invoke();
    }
    public void Disable()
    {
        _onCompleteBoom?.Invoke();
        gameObject.SetActive(false);
    }
}
