using System;
using UnityEngine;

public class LevelFinish : MonoBehaviour, ILevelFinish, IAmUsable
{
    public bool CanUse => true;

    public Action OnFinishComplete { get; set; }

    public void Use()
    {
        OnFinishComplete?.Invoke();
    }
}

