using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class BrokenObject : MonoBehaviour
{
    protected Health _health;
    void Awake()
    {
        InitHealth();
    }

    protected void InitHealth()
    {
        _health = GetComponent<Health>();
        _health.OnDied += Die;
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWeapon weapon;
        if (collision.gameObject.TryGetComponent<IWeapon>(out weapon))
            _health.Damage(weapon.Damage);
    }
}
