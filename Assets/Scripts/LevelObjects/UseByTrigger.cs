using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(IAmUsable))]
[RequireComponent(typeof(Collider2D))]
public class UseByTrigger : MonoBehaviour
{
    private IAmUsable[] _iAmIsUsed;
    private void Awake()
    {
        _iAmIsUsed = GetComponents<IAmUsable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICanUse user;
        if (collision.gameObject.TryGetComponent<ICanUse>(out user))
            foreach(IAmUsable usable in _iAmIsUsed)
                if(usable.CanUse) usable.Use();
    }

}
