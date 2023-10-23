using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public abstract class AItem : MonoBehaviour
{
    [field: SerializeField] public ItemType ItemType { get; private set; }

    [SerializeField] protected CircleCollider2D cCollider;
    [SerializeField] protected Rigidbody2D rigidbody2;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    public abstract void OnUse(PlayerController player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var p = collision.GetComponentInParent<PlayerController>();

            p.Inventory.AddItem(new ItemBase(ItemType, spriteRenderer.sprite));
            Destroy(gameObject);
        }
    }

    private void OnValidate()
    {
        cCollider = GetComponent<CircleCollider2D>();
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        cCollider.isTrigger = true;
        rigidbody2.isKinematic = true;
    }
}
