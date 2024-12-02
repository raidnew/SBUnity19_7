using UnityEngine;

public class Bomb : MonoBehaviour, IAmUsable, IBomb
{
    [SerializeField] private Explosion _explosion;
    private Animator _animator;

    public bool CanUse { get; private set; }

    private void Awake()
    {
        CanUse = true;
        TryGetComponent<Animator>(out _animator);
    }

    public void Use()
    {
        if (!CanUse) return;
        CanUse = false;
        if (_animator != null)
            _animator.SetTrigger("Explode");
        _explosion.gameObject.SetActive(true);
    }

    public void OnEndExplode()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWeapon weapon;
        if (collision.gameObject.TryGetComponent<IWeapon>(out weapon))
            Use();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IWeapon weapon;
        if (collision.gameObject.TryGetComponent<IWeapon>(out weapon))
            Use();
    }
}
