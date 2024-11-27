using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkBubble : MonoBehaviour, ITalkBubble
{
    [SerializeField] private RectTransform _background;
    [SerializeField] private TextMeshProUGUI _textField;

    public Action OnDestroy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void ShowMessage(string message, Transform position, int time)
    {
        
    }
    private void Update()
    {
        if (_needRecalcSizeBackground)
            _background.sizeDelta = new Vector2(_textField.textInfo.textComponent.textBounds.size.x + _backgroundMargin * 2, _textField.textInfo.textComponent.textBounds.size.y + _backgroundMargin * 2);
    }

    private IEnumerator ShowMessage(string message, Transform teller)
    {
        Show();

        Vector3 pos = _camera.WorldToScreenPoint(teller.position);

        RectTransform rt = __instance.GetComponent<RectTransform>();

        rt.position = pos;


        _textField.SetText(message);
        yield return new WaitForSeconds(3);
        Hide();
        yield return null;
    }

}
