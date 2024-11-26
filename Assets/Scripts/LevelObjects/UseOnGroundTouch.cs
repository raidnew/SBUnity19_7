using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseOnGroundTouch : MonoBehaviour
{
    [SerializeField] private ShowOnAction _usableObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ground ground;
        if (collision.gameObject.TryGetComponent<Ground>(out ground))
        {
            _usableObject.Use();
            Destroy(gameObject);
        }
    }
}
