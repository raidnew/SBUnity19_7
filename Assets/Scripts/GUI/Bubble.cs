using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bubble : MonoBehaviour
{
    [SerializeField] private TalkBubble _bubblePrefab;
    [SerializeField] private Camera _camera;

    private static Bubble __instance;

    private List<ITalkBubble> _showedBubbls;

    private void Awake()
    {
        __instance = this;
        _showedBubbls = new List<ITalkBubble>();
    }

    public static void Message(string message, Transform teller)
    {
        __instance.ShowBubble(message, teller);
    }

    private void ShowBubble(string message, Transform teller)
    {
        ITalkBubble newBubble = Instantiate(_bubblePrefab, transform);
        newBubble.ShowMessage(message, teller, _camera, 3);
        newBubble.OnRemoveBubble += OnDestroyBubble;
        _showedBubbls.Add(newBubble);
    }

    private void OnDestroyBubble(ITalkBubble Bubble)
    {
        _showedBubbls?.Remove(Bubble);
    }

}
