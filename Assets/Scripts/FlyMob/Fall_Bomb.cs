using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Fall_Bomb : MonoBehaviour
{
    public int Fall_bomb_damage;
    [SerializeField] private UnityEvent _onBoom;

    private Animator _animator;
    private Rigidbody2D _rigidbody2d;
    private Vector3 _startPosition;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    public void Trow()
    {
        _rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
    }
    public void Boom()
    {
        _animator.SetTrigger("Boom");
        
        _rigidbody2d.bodyType = RigidbodyType2D.Static;
        _rigidbody2d.velocity = Vector2.zero;
    }
    public void OnBoomComplete()
    {
        _onBoom.Invoke();
    }
    public void Restart()
    {
        transform.localPosition = _startPosition;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable dmagable))
        {
            Debug.Log("Урон от бомбы "+Fall_bomb_damage);
            dmagable.GetDamage(Fall_bomb_damage);
        }

        Boom();
    }
}