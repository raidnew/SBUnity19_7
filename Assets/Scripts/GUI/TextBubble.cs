using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TextBubble : MonoBehaviour
{
    [SerializeField] private RectTransform _background;
    [SerializeField] private TextMeshProUGUI _textField;
    [SerializeField] private int _backgroundMargin = 10;

    private static TextBubble __instance;

    private bool _needRecalcSizeBackground;

    private void Awake()
    {
        __instance = this;
        __instance.Hide();
        _needRecalcSizeBackground = false;
        _textField.OnPreRenderText += RecalcSize;
    }

    public static void Message(string message)
    {
        __instance.ShowBubble(message);
    }

    private void ShowBubble(string message)
    {
        StartCoroutine(ShowMessage(message));
    }

    private void RecalcSize(TMP_TextInfo textInfo)
    {
        _needRecalcSizeBackground = true;
    }

    private void Update()
    {
        if (_needRecalcSizeBackground)
            _background.sizeDelta = new Vector2(_textField.textInfo.textComponent.textBounds.size.x + _backgroundMargin * 2, _textField.textInfo.textComponent.textBounds.size.y + _backgroundMargin * 2);
    }

    private void Hide()
    {
        _background.gameObject.SetActive(false);
        _textField.gameObject.SetActive(false);
    }

    private void Show()
    {
        _background.gameObject.SetActive(true);
        _textField.gameObject.SetActive(true);
    }

    private IEnumerator ShowMessage(string message)
    {
        Show();
        _textField.SetText(message);
        yield return new WaitForSeconds(3);
        Hide();
        yield return null;
    }

}
