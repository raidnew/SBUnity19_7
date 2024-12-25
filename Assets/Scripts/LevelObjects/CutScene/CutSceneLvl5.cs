using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneLvl5 : MonoBehaviour, IAmUsable
{
    [SerializeField] private Dialog _dialog;
    [SerializeField] private CinemachineVirtualCamera _cutSceneCamera;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private GameObject _sceleton;

    public bool CanUse => true;

    public void Use()
    {
        _userInput.enabled = false;
        _cutSceneCamera.Priority = 20;
        _dialog.OnDialogFinish += AddSceleton;
        _dialog.Use();
    }

    private void AddSceleton()
    {
        StartCoroutine(ShowSceleton());        
    }

    private IEnumerator ShowSceleton()
    {
        yield return new WaitForSeconds(3);
        _sceleton.SetActive(true);
        yield return new WaitForSeconds(3);
        StopCutScene();
    }

    private void StopCutScene()
    {
        _cutSceneCamera.Priority = 1;
        _userInput.enabled = true;
    }

}
