using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private PlayerInteraction _player;

    private void Awake()
    {
        _player.OnDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        Notice.FastNotice("You died!");
    }
}
