using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teller : MonoBehaviour, IAmUsable
{
    [SerializeField] private string _message;
    [SerializeField] private Transform _linkBubble;

    public bool CanUse { get => true; }

    public void Use()
    {
        Bubble.Message(_message, _linkBubble);
    }
}
