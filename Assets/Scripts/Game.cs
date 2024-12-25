using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LevelList))]
public class Game : MonoBehaviour
{
    public static Action<int> OnCountCoinsChanged;

    private static bool firstLoad = true;

    [SerializeField] private WindowsManager _windowsManager;

    private LevelList _levelList;
    private int _currentLevelIndex;
    private int _countCoins;

    public int CointCoins
    {
        get => _countCoins;
        set
        {
            _countCoins = value;
            OnCountCoinsChanged?.Invoke(_countCoins);
        }
    }

    private void Awake()
    {
        _levelList = GetComponent<LevelList>();
        if (firstLoad)
            InitAction();
    }

    private void Start()
    {
        if (firstLoad)
        {
            _windowsManager.ShowWindowMain();
            firstLoad = false;
        }
    }

    private void InitAction()
    {
        WindowMain.OnPlay += _windowsManager.ShowWindowStartLevel;
        WindowStartLevel.OnSelectLevel += LevelHasSelected;
        WindowWin.OnNextLevel += StartNextLevel;
        Level.OnLose += LevelHasLoosed;
        Level.OnWin += LevelHasWon;
        Level.OnStart += LevelHasStarted;
        Coin.OnCollect += OnCoinCollect;

        CointCoins = 0;
    }

    private void LevelHasLoosed()
    {
        LoadMainScene();
        _windowsManager.ShowWindowDie();
    }

    private void LevelHasWon()
    {
        LoadMainScene();
        _windowsManager.ShowWindowWin();
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

    private void LevelHasSelected(int levelIndex)
    {
        _currentLevelIndex = levelIndex;
        StartCurrentLevel();
    }

    private void StartCurrentLevel()
    {
        SceneManager.LoadScene(_levelList.GetLevelName(_currentLevelIndex));
    }

    private void StartNextLevel()
    {
        _currentLevelIndex++;
        StartCurrentLevel();
    }

    private void OnCoinCollect()
    {
        CointCoins++;
    }

}
