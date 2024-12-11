using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : Button
{
    public string SceneName { get; set; }
    public int SceneIndex { get; set; }
    public string Text { get; set; }
}
