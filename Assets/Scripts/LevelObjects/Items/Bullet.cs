using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IWeapon
{
    [SerializeField] private float _damage;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Vector3 _speed;
    private Rigidbody2D _rb;
    private float _bornTime;
    private bool _removing = false;

    public float Damage => _damage;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _bornTime = Time.time;
    }

    public void Start()
    {
        _rb.velocity = _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.gravityScale = 1;
        OnStartRemove();
    }

    private void Update()
    {
        if(_bornTime + _lifeTime > Time.time)
            OnStartRemove();
    }

    private void OnStartRemove()
    {
        if (_removing) return;
        _removing = true;
        StartCoroutine(Remove());
    }

    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        yield return false;
    }
}
