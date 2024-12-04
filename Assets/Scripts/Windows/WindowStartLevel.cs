using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WindowStartLevel : BaseWindow
{
    [SerializeField] private SceneAsset[] _levelScenes;
    [SerializeField] private LevelButton _levelButtonPrefab;

    private List<Button> _levelButtons;

    private void OnEnable()
    {
        for (int i = 0; i < _levelScenes.Length; i++)
        {
            LevelButton newlevelButon = Instantiate(_levelButtonPrefab, transform);
            newlevelButon.transform.position = new Vector3(0, 40 * i, 0);
            newlevelButon.onClick.AddListener(delegate { StartLevel(_levelScenes[i]); } );
        }
    }

    private void StartLevel(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    private void OnDisable()
    {
        
    }


}
