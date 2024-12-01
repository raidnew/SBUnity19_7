using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterExplose : MonoBehaviour
{
    private bool _wasExplosive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IExplosion explosion;
        PointEffector2D pointEffector;
        if (collision.gameObject.TryGetComponent<PointEffector2D>(out pointEffector) && collision.gameObject.TryGetComponent<IExplosion>(out explosion))
        {
            StartCoroutine(WasBang());
        }
    }

    IEnumerator WasBang()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        yield return false;
    }
}
