using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowWin : BaseWindow
{
    public static Action OnNextLevel;

    [SerializeField] private Button _nextButton;

    private void Awake()
    {
        _nextButton.onClick.AddListener(ClickNextLevel);
    }

    private void ClickNextLevel()
    {
        OnNextLevel?.Invoke();
        Close();
    }
}
