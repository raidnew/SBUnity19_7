using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SceletonBehaviour : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private EnemyObserver _sight;

    private IEnemy _enemy;
    private Transform _transform;
    private Vector3? _targetPosition;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _transform = GetComponent<Transform>(); 
        InitSight();
    }

    private void InitSight()
    {
        _sight.OnFoundPlayer += OnStartAttack;
        _sight.OnLostPlayer += OnStopAttack;
        _sight.OnWatchPlayer += OnContinueAttack;
    }

    private void OnStartAttack(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;

    }

    private void OnStopAttack(Vector3 targetPosition)
    {
        _targetPosition = null;
    }

    private void OnContinueAttack(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    private void ChooseMyAction()
    {
        if (_targetPosition != null)
            AttackTarget();
        else
            _enemy.Wait();

    }

    private void AttackTarget()
    {
        if (GetDistanceToTarget() > _attackDistance && _enemy.CanMove())
        {
            float directionMove = GetVectorToTarget().x > 0 ? 1 : -1;
            _enemy.Move(directionMove);
        }
        else if (GetDistanceToTarget() <= _attackDistance && _enemy.CanAttack())
        {
            _enemy.Attack();
            _enemy.Move(0);
        }
    }

    private Vector3 GetVectorToTarget()
    {
        return (Vector3)(_targetPosition - _transform.position);
    }

    private float GetDistanceToTarget()
    {
        return GetVectorToTarget().magnitude;
    }

    private void FixedUpdate()
    {
        ChooseMyAction();
    }
}

