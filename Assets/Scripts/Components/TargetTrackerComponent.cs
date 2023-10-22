using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class TargetTrackerComponent : MonoBehaviour
{
    [SerializeField]
    private string _targetTag;

    [SerializeField]
    [Range(0f, 10f)]
    private float _interactionRange;

    public Transform Target => _target;


    private CircleCollider2D _collider;
    private Rigidbody2D _rigidbody;

    private Transform _target;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _collider.isTrigger = true;
        _collider.radius = _interactionRange;

        _rigidbody.isKinematic = true;
        _rigidbody.freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_target != null)
            return;

        if (collision.CompareTag(_targetTag))
        {
            _target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.CompareTag(_targetTag))
        {
            _target = null;

            Debug.Log($"_target is: {_target} Target is: {Target}");
        }
    }

    #region Helpers
    private void OnValidate()
    {
        if (_collider == null) _collider = GetComponent<CircleCollider2D>();
        if(_rigidbody == null) _rigidbody = GetComponent<Rigidbody2D>();

        _collider.isTrigger = true;
        _collider.radius = _interactionRange;

        _rigidbody.isKinematic = true;
        _rigidbody.freezeRotation = true;
    }
    #endregion
}
