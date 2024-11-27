using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bubble : MonoBehaviour
{
    /*
    [SerializeField] private RectTransform _background;
    [SerializeField] private TextMeshProUGUI _textField;
    */
    [SerializeField] private TalkBubble _bubblePrefab;
//    [SerializeField] private int _backgroundMargin = 10;
    [SerializeField] private Camera _camera;

    private static Bubble __instance;

    private List<ITalkBubble> _showedBubbls;
    //private bool _needRecalcSizeBackground;

    private void Awake()
    {
        __instance = this;
        _showedBubbls = new List<ITalkBubble>();
        //__instance.Hide();
        //_needRecalcSizeBackground = false;
        //_textField.OnPreRenderText += RecalcSize;
    }

    public static void Message(string message, Transform teller)
    {
        __instance.ShowBubble(message, teller);
    }

    private void ShowBubble(string message, Transform teller)
    {
        //StartCoroutine(ShowMessage(message, teller));
        ITalkBubble newBubble = Instantiate(_bubblePrefab);
        _showedBubbls.Add(newBubble);
    }

    /*
    private void RecalcSize(TMP_TextInfo textInfo)
    {
        //_needRecalcSizeBackground = true;
    }
    */
    /*
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
    */

    /*
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
    */
}
