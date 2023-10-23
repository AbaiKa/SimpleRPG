using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CirlceRendererComponent : MonoBehaviour
{
    private LineRenderer _line;

    [SerializeField] 
    [Range(0, 100)]
    private int _segments = 50;

    [SerializeField]
    [Range(0, 5)]
    private float _radius = 5;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();

        _line.positionCount = _segments + 1;
        _line.useWorldSpace = false;
    }

    private void Start()
    {
        CreatePoints();
    }

    private void CreatePoints()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (_segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * _radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * _radius;

            _line.SetPosition(i, new Vector2(x, y));

            angle += (360f / _segments);
        }
    }

    private void OnValidate()
    {
        if(_line == null)
        _line = GetComponent<LineRenderer>();

        _line.positionCount = _segments + 1;
        _line.useWorldSpace = false;
        CreatePoints();
    }
}
