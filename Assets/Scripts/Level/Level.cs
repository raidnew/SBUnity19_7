using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Action OnWin;
    public static Action OnLose;
    public static Action OnStart;

    [SerializeField] private PlayerInteraction _player;
    [SerializeField] private LevelFinish _levelFinish;
    [SerializeField] private Transform _container;


    private void Awake()
    {
        _player.OnDied += OnPlayerDied;
        _player.OnCreateBullet += OnCreateObject;
        _levelFinish.OnFinishComplete += OnLevelComplete;
    }

    private void Start()
    {
        OnStart?.Invoke();
    }

    private void OnLevelComplete()
    {
        OnWin?.Invoke();
    }

    private void OnCreateObject(Bullet bullet)
    {
        bullet.transform.parent = _container;
    }

    private void OnPlayerDied()
    {
        OnLose?.Invoke();
    }
}
