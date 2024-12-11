using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelList : MonoBehaviour
{
    [SerializeField] private string[] _levelScenes;

    public string GetLevelName(int index)
    {
        return _levelScenes[index];
    }

    public IEnumerable<string> LevelScenes()
    {
        return _levelScenes;
    }
}
