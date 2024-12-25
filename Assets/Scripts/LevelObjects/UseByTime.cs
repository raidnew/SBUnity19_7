using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(IAmUsable))]
public class UseByTime : MonoBehaviour
{
    [SerializeField] private int _delayTime;
    private IAmUsable[] _iAmIsUsed;
    private void Awake()
    {
        _iAmIsUsed = GetComponents<IAmUsable>();
        StartCoroutine(Execute());
    }

    private IEnumerator Execute()
    {
        yield return new WaitForSeconds(_delayTime);
        foreach(IAmUsable usable in _iAmIsUsed)
            if (usable.CanUse) usable.Use();
    }
}
