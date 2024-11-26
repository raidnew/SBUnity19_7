using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour, IProgressBar
{

    [SerializeField] private SpriteRenderer _progressBar;
    private float _currentValue = 1;

    private void Awake()
    {
        SetProgress(_currentValue);
    }

    public void Full()
    {
        SetProgress(1);
    }

    public void SetProgress(float value)
    {
        _currentValue = value;
        _progressBar.size = new Vector2(value, _progressBar.size.y);
    }
}
