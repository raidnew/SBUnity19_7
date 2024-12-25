using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

[Serializable]
struct Phrase
{
    public Transform linkBubble;
    public string phrase;
}

public class Dialog : MonoBehaviour, IAmUsable
{
    public Action OnDialogFinish;
    [SerializeField] private Phrase[] _phrases;

    public bool CanUse => true;

    public void Use()
    {
        StartCoroutine(ShowDialog());
    }

    IEnumerator ShowDialog()
    {
        for (int i = 0; i < _phrases.Length; i++)
        {
            Bubble.Message(_phrases[i].phrase, _phrases[i].linkBubble);
            yield return new WaitForSeconds(3);
        }
        OnDialogFinish?.Invoke();
        yield return true;
    }
}
