using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : Button
{
    [SerializeField] private TextMeshProUGUI _buttonLabel;
    public string SceneName { get; set; }
    public int SceneIndex { get; set; }

}
