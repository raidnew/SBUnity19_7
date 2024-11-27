using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dray : MonoBehaviour, ICanUse, IGround
{
    private Rigidbody2D _rb;
    public Vector2 Speed 
    {
        get => _rb.velocity;
    }

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bomb bomb;
        if (collision.gameObject.TryGetComponent<Bomb>(out bomb))
            bomb.Use();
    }
}
