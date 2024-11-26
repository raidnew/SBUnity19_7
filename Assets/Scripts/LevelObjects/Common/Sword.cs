using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Collider2D _damageArea;

    public float Damage
    {
        get { return _damage; }
    }

    private void Awake()
    {
        StopHit();
    }

    public void StartHit()
    {
        _damageArea.enabled = true;
    }

    public void StopHit()
    {
        _damageArea.enabled = false;
    }
}
