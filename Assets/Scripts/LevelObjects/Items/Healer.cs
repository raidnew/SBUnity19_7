using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour, IHealer, IAmUsable
{
    [SerializeField] private int _healValue;
    public int Value => _healValue;

    public bool CanUse => true;

    public void Use()
    {
        Destroy(gameObject);
    }
}
