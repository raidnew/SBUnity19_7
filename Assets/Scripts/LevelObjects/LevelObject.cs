using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collission"+collision.collider);
    }
}
