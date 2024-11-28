using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerInteraction _player;
    [SerializeField] private LevelFinish _levelFinish;

    private void Awake()
    {
        _player.OnDied += OnPlayerDied;
        _levelFinish.OnFinishComplete += OnLevelComplete;
    }

    private void OnLevelComplete()
    {
        Notice.FastNotice("Level complete!");
    }

    private void OnPlayerDied()
    {
        Notice.FastNotice("You died!");
    }
}
