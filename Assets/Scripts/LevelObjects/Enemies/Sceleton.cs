using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Sceleton : BaseEnemy
{
    [SerializeField] private EnemySword _sword;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Collider2D _visionArea;

    private Animator _animator;
    private Rigidbody2D _rb;
    private ISight _sight;

    private bool _isAttack;
    private double _lastAttackTime;

    private bool IsAttack
    {
        get { return _isAttack; }
        set
        {
            _animator.SetBool("IsAttack", value);
            _isAttack = value;
        }
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //_sight.VisionArea = _visionArea;
        base.InitHealth();
    }

    void FixedUpdate()
    {
        if (IsNeedAttack())
            Attack();
    }

    private bool IsNeedAttack()
    {
        if(_health == null) return false;
        return !IsAttack && _health.CurrentPercent > 0 && Time.time > _lastAttackTime + _attackDelay;
    }

    private void Attack()
    {
        IsAttack = true;
    }

    private void Hit()
    {
        _sword.StartHit();
    }

    private void OnFinishAttack()
    {
        _sword.StopHit();
        IsAttack = false;
        _lastAttackTime = Time.time;
    }

    protected override void Die()
    {
        _animator.SetBool("IsALive", false);
    }

}
