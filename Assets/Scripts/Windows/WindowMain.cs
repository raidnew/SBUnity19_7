using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowMain : BaseWindow, IWindow
{
    public Action OnPlay;

    [SerializeField] private Button _playButton;

    private void OnEnable() => _playButton.onClick.AddListener(OnClickPlayButton);

    private void OnDisable() => _playButton.onClick.RemoveListener(OnClickPlayButton);

    private void OnClickPlayButton()
    {
        OnPlay?.Invoke();
    }
}
