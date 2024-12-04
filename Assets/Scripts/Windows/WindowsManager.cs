using UnityEngine;

public class WindowsManager : BaseWindow
{
    [SerializeField] private WindowMain _windowMain;
    [SerializeField] private WindowWin _windowWin;
    [SerializeField] private WindowDie _windowDied;
    [SerializeField] private WindowStartLevel _windowStartLevel;

    private IWindow _currentOpenedWindow;

    private void Start()
    {
        InitActions();
        ShowWindowMain();
    }

    private void InitActions()
    {
        _windowMain.OnPlay += ShowWindowStartLevel;
    }

    private void ShowWindowMain()
    {
        ShowWindow(_windowMain);
    }

    private void ShowWindowStartLevel()
    {
        ShowWindow(_windowStartLevel);
    }

    private void ShowWindow(IWindow window)
    {
        CloseCurrentWindow();
        _currentOpenedWindow = window;
        _currentOpenedWindow.Open();

    }

    private void CloseCurrentWindow()
    {
        if (_currentOpenedWindow != null)
            _currentOpenedWindow.Close();
        _currentOpenedWindow = null;
    }
}
