using System.Collections.Generic;
using UnityEngine;

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
        int controlsumm = GetControlSumm(message, teller.GetInstanceID());
        if (!CheckAlreadyBubble(controlsumm))
        {
            ITalkBubble newBubble = Instantiate(_bubblePrefab, transform);
            newBubble.CheckSumm = controlsumm;
            newBubble.ShowMessage(message, teller, _camera, 3);
            newBubble.OnRemoveBubble += OnDestroyBubble;
            _showedBubbls.Add(newBubble);
        }
    }

    private int GetControlSumm(string text, int tellerId)
    {
        return tellerId * 1000 + text.Length;
    }

    private bool CheckAlreadyBubble(int checkSumm)
    {
        foreach (ITalkBubble bubble in _showedBubbls) 
            if(bubble.CheckSumm == checkSumm) return true;
        return false;
    }

    private void OnDestroyBubble(ITalkBubble Bubble)
    {
        _showedBubbls?.Remove(Bubble);
    }

}
