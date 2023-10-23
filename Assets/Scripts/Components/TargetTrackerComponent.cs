using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class TargetTrackerComponent : MonoBehaviour
{
    [SerializeField]
    private LayerMask _targetLayer;
    [SerializeField]
    private string _targetTag;

    [SerializeField]
    [Range(0f, 10f)]
    private float _interactionRange;

    [SerializeField] private bool _autoResetTarget;
    [SerializeField] private bool _alwaysTrack;

    public Transform Target { get; private set; }


    private CircleCollider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _collider.isTrigger = true;
        _collider.radius = _interactionRange;

        _rigidbody.isKinematic = true;
        _rigidbody.freezeRotation = true;
    }
    private void Update()
    {
        if (_alwaysTrack == false)
            return;

        if (Target != null)
        {
            return;
        }


        Collider2D[] res = Physics2D.OverlapCircleAll(transform.position, _interactionRange, _targetLayer.value);

        if (res == null || res.Length <= 0)
            return;

        Debug.Log($"Count: {res.Length}");

        Collider2D collider = res[Random.Range(0, res.Length - 1)];

        if (collider == null)
        {
            Target = null;
            return;
        }

        Target = collider.transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Target != null)
            return;

        if (collision.CompareTag(_targetTag))
        {
            Target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_autoResetTarget)
            return;

        if (collision.CompareTag(_targetTag))
        {
            Target = null;
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
