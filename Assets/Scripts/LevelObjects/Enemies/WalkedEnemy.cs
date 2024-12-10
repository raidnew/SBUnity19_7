using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Sceleton : Enemy
{
    [SerializeField] private EnemySword _sword;
    [SerializeField] private float _timeBeetweenAttack;
    [SerializeField] private int _baseSpeed;
    [SerializeField] private Vector3 _leftLimitMove;
    [SerializeField] private Vector3 _rightLimitMove;
    [SerializeField] private BrokenObject _life;

    private Animator _animator;
    private Rigidbody2D _rb;
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
        _life.OnDied += Die;
    }

    public override bool CanAttack()
    {
        return !IsAttack && _life.Percent > 0 && Time.time > _lastAttackTime + _timeBeetweenAttack && !IsDied();
    }

    public override bool CanMove()
    {
        return !IsDied();
    }

    public override bool IsDied()
    {
        return _life.Percent == 0;
    }

    public override void Move(float direction)
    {
        SetHSpeed((int)(direction * _baseSpeed));
    }

    public override void Wait()
    {
        SetHSpeed(0);
    }

    public override void Attack()
    {
        IsAttack = true;
    }

    private void Die()
    {
        _animator.SetBool("IsAlive", false);
    }

    private void SetHSpeed(float speed)
    {
        if (speed != 0) Flip(speed < 0);
        _rb.velocity = new Vector2(speed, 0);
        _animator.SetInteger("HSpeed", (int)speed);
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

}
