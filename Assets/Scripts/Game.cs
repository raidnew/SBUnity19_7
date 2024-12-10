using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    [SerializeField] private WindowsManager _windowsManager;

    private void Awake()
    {
        InitAction();
    }

    private void Start()
    {
        _windowsManager.ShowWindowMain();
    }

    private void InitAction()
    {
        WindowMain.OnPlay += _windowsManager.ShowWindowStartLevel;
        WindowStartLevel.OnSelectLevel += LevelHasSelected;
        Level.OnLose += LevelHasLoosed;
        Level.OnWin += LevelHasWon;
        Level.OnStart += LevelHasStarted;
    }

    private void LevelHasLoosed()
    {
        LoadMainScene();
    }

    private void LevelHasWon()
    {
        LoadMainScene();
    }

    private void LevelHasStarted()
    {
        _windowsManager.ShowUserInterface();
    }

    private void LoadMainScene() 
    {
        _windowsManager.HideUserInterface();
        SceneManager.LoadScene("Main");
    }

    private void LevelHasSelected(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
