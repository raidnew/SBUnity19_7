using System;
using UnityEngine;

public interface ITalkBubble
{
    public Action OnDestroy { get; set; }
    public void ShowMessage(string message, Transform position, int time);
}

