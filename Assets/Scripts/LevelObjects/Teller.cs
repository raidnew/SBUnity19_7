using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teller : MonoBehaviour, IAmUsable
{
    [SerializeField] private string _message;

    public bool CanUse { get => true; }

    public void Use()
    {
        TextBubble.Message(_message);
    }
}
