using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WindowStartLevel : BaseWindow
{
    public static Action<int> OnSelectLevel;

    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private Transform _buttonsContainer;
    [SerializeField] private LevelList _levelList;

    private List<Button> _levelButtons;

    private void OnEnable()
    {

        _levelButtons = new List<Button>();
        int i = 0;

        foreach(string level in _levelList.LevelScenes())
        {
            LevelButton newlevelButon = Instantiate(_levelButtonPrefab, _buttonsContainer, true);
            newlevelButon.SceneName = level;
            newlevelButon.SceneIndex = i;
            TextMeshProUGUI text = newlevelButon.GetComponentInChildren<TextMeshProUGUI>();
            text.text = level;
            newlevelButon.GetComponent<RectTransform>().localPosition = new Vector3(0, -40 * i++, 0);
            newlevelButon.onClick.AddListener(delegate { StartLevel(newlevelButon.SceneIndex); });
            _levelButtons.Add(newlevelButon);
        }
    }

    private void StartLevel(int levelName)
    {
        OnSelectLevel?.Invoke(levelName);
        Close();
    }

    private void OnDisable()
    {
        foreach (LevelButton button in _levelButtons)
        {
            Destroy(button.gameObject);
        }
    }


}
