using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour, IItemContainer
{
    [SerializeField] private UsersItems _containedItem;
    [SerializeField] private bool _removeAfterGet;

    public UsersItems UserItem { get => _containedItem; }

    private bool _canUse = true;
    public bool CanUse { get => _canUse; }

    public void Use()
    {
        _canUse = false;
        if (_removeAfterGet)
        {
            Destroy(gameObject);
        }
    }
}
