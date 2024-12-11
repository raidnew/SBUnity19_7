using UnityEngine;

public class WindowsManager : BaseWindow
{
    [SerializeField] private WindowMain _windowMain;
    [SerializeField] private WindowWin _windowWin;
    [SerializeField] private WindowDie _windowDied;
    [SerializeField] private WindowStartLevel _windowStartLevel;
    [SerializeField] private UserInterface _userInterface;

    private IWindow _currentOpenedWindow;

    public void ShowWindowMain()
    {
        ShowWindow(_windowMain);
    }

    public void ShowWindowDie()
    {
        ShowWindow(_windowDied);
    }

    public void ShowWindowWin()
    {
        ShowWindow(_windowWin);
    }

    public void ShowWindowStartLevel()
    {
        ShowWindow(_windowStartLevel);
    }

    private void ShowWindow(IWindow window)
    {
        CloseCurrentWindow();
        _currentOpenedWindow = window;
        _currentOpenedWindow.Open();

    }

    public void ShowUserInterface()
    {
        _userInterface.gameObject.SetActive(true);
    }

    public void HideUserInterface()
    {
        _userInterface.gameObject.SetActive(false);
    }

    private void CloseCurrentWindow()
    {
        if (_currentOpenedWindow != null)
            _currentOpenedWindow.Close();
        _currentOpenedWindow = null;
    }
}
