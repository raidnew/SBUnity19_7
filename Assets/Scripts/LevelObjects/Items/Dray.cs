using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dray : MonoBehaviour, ICanUse
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bomb bomb;
        if (collision.gameObject.TryGetComponent<Bomb>(out bomb))
            bomb.Use();
    }
}
