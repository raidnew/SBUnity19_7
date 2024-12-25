using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour, IAmUsable
{
    public static Action OnCollect;

    private Animator _animator;

    public bool CanUse => true;

    public void Use()
    {
        _animator.SetTrigger("Collect");
    }

    private void Collected()
    {
        OnCollect?.Invoke();
        Destroy(gameObject);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
