using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterExplose : MonoBehaviour
{
    private bool _wasExplosive;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bomb bomb;
        PointEffector2D pointEffector;
        if(collision.gameObject.TryGetComponent<PointEffector2D>(out pointEffector) && collision.gameObject.TryGetComponent<Bomb>(out bomb))
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
