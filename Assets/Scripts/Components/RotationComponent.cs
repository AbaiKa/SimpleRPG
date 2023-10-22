using UnityEngine;

public class RotationComponent : MonoBehaviour
{
    private bool _rotated = false;
    public void Rotate(Transform target)
    {
        float distance = target.position.x - transform.position.x;

        if (_rotated == distance >= 0)
            return;

        Vector3 euler = new Vector3(0, distance >= 0 ? 0 : 180, 0);
        transform.rotation = Quaternion.Euler(euler);
        _rotated = distance >= 0;
    }
}
