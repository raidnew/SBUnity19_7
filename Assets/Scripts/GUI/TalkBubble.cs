using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkBubble : MonoBehaviour, ITalkBubble
{
    [SerializeField] private RectTransform _background;
    [SerializeField] private TextMeshProUGUI _textField;

    private int _backgroundMargin = 10;
    private bool _needRecalcSizeBackground = true;
    private Camera _camera;
    private Transform _linkPoint;
    private RectTransform _rt;

    public Action<ITalkBubble> OnRemoveBubble { get; set; }

    public void ShowMessage(string message, Transform position, Camera camera, int time)
    {
        _rt = GetComponent<RectTransform>();
        _linkPoint = position;
        _camera = camera;
        StartCoroutine(ShowMessage(message, time));
    }

    private void Update()
    {
        if (_needRecalcSizeBackground)
        {
            _needRecalcSizeBackground = false;
            _background.sizeDelta = new Vector2(_textField.textInfo.textComponent.textBounds.size.x + _backgroundMargin * 2, _textField.textInfo.textComponent.textBounds.size.y + _backgroundMargin * 2);
        }

        _rt.localPosition = _camera.WorldToScreenPoint(_linkPoint.position); 
    }

    private IEnumerator ShowMessage(string message, int time)
    {
        _textField.SetText(message);
        yield return new WaitForSeconds(time);
        OnRemoveBubble?.Invoke(this);
        Destroy(gameObject);
        yield return null;
    }

}
