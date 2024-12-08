using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WindowStartLevel : BaseWindow
{
    [SerializeField] private string[] _levelScenes;
    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private Transform _buttonsContainer;

    private List<Button> _levelButtons;

    private void OnEnable()
    {
        for (int i = 0; i < _levelScenes.Length; i++)
        {
            LevelButton newlevelButon = Instantiate(_levelButtonPrefab, transform, true);
            newlevelButon.SceneName = _levelScenes[i];
            newlevelButon.GetComponent<RectTransform>().localPosition = new Vector3(0, 40 * i, 0);
            newlevelButon.onClick.AddListener(delegate { StartLevel(newlevelButon.SceneName); });
        }
    }

    private void StartLevel(string scene)
    {
        SceneManager.LoadScene(scene);
        Close();
    }

    private void OnDisable()
    {

    }


}
