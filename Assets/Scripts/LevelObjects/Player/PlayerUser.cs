using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUser : MonoBehaviour, ICanUse
{
    [Serializable]
    private class ItemLink{
        public UsersItems item;
        public GameObject view;
    }

    [SerializeField] private ItemLink[] _usersItems;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItemContainer itemContainer;
        if (collision.TryGetComponent<IItemContainer>(out itemContainer))
        {
            IItemContainer[] usableCompoenents = collision.GetComponents<IItemContainer>();
            foreach (IItemContainer components in usableCompoenents)
                if(itemContainer.CanUse) HasUsedItem(itemContainer.UserItem);
        }

        IAmUsable usableObject;
        if (collision.TryGetComponent<IAmUsable>(out usableObject))
        {
            IAmUsable[] usableCompoenents = collision.GetComponents<IAmUsable>();
            foreach (IAmUsable components in usableCompoenents)
                if (components.CanUse) components.Use();
        }

    }

    private void HasUsedItem(UsersItems item)
    {
        ItemLink link = Array.Find<ItemLink>(_usersItems, link => link.item == item);
        if(link != null)
            link.view.SetActive(true);
    }
}
