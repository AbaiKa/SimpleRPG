using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField]
    private float _speed;

    public float Speed => _speed;

    private Rigidbody2D _rigidbody;

    private bool _rotated;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
        _rigidbody.freezeRotation = true;
    }

    public void Move(Vector2 direction)
    {
        if (direction.x == 0 && direction.y == 0)
            direction = transform.forward;

        _rigidbody.velocity = new Vector2(direction.x * Speed, direction.y * Speed);

        if (_rotated == direction.x >= 0)
            return;

        _rotated = direction.x >= 0;

        Vector3 euler = new Vector3(0, direction.x >= 0 ? 0 : 180, 0);
        transform.rotation = Quaternion.Euler(euler);
    }

    private void OnValidate()
    {
        if(_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.isKinematic = true;
        _rigidbody.freezeRotation = true;
    }
}
