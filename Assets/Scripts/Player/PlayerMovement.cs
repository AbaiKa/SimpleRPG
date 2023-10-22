using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField]
    private float _speed;

    public float Speed => _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = new Vector2(direction.x * Speed, direction.y * Speed);
        transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);  
    }
}
