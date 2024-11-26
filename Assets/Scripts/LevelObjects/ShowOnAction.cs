using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnAction : MonoBehaviour, IAmUsable
{
    [SerializeField] private GameObject _item;

    public bool CanUse { get => true; }

    public void Use()
    {
        _item.transform.position = transform.position;
        _item.SetActive(true);
    }
}
