using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerInteraction _player;
    [SerializeField] private LevelFinish _levelFinish;
    [SerializeField] private Transform _container;

    private void Awake(int playerHealth, UsersItems[] playerItems)
    {
        _player.OnDied += OnPlayerDied;
        _player.OnCreateBullet += OnCreateObject;
        _levelFinish.OnFinishComplete += OnLevelComplete;
    }

    private void OnLevelComplete()
    {
        Notice.FastNotice("Level complete!");
    }

    private void OnCreateObject(Bullet bullet)
    {
        bullet.transform.parent = _container;
    }

    private void OnPlayerDied()
    {
        Notice.FastNotice("You died!");
    }
}
