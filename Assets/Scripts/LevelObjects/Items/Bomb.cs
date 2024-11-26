using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Bomb : MonoBehaviour, IAmUsable, IBomb
{
    [SerializeField] private float _explosePower = 100;

    private bool _canUse = true;
    public bool CanUse { get => _canUse; }

    public void Use()
    {
        if (CanUse)
            StartCoroutine(Explose());
    }

    IEnumerator Explose()
    {
        _canUse = false;
        PointEffector2D _explosion;
        CircleCollider2D _collider;
        _collider = gameObject.AddComponent<CircleCollider2D>();
        _collider.usedByEffector = true;
        _collider.radius = 10;

        _explosion = gameObject.AddComponent<PointEffector2D>();
        _explosion.forceMagnitude = _explosePower;
        _explosion.forceVariation = 20;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        yield return false;
    }
}
