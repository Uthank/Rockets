using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Ring : MonoBehaviour
{
    [SerializeField] [Range(8, 100)] private int _subdivide;
    [SerializeField] private float _radius;
    [SerializeField] private float _alphaSpeed;
    [SerializeField] float _alpha = 1f;
    [SerializeField] float _maxAlpha = .5f;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        Vector3[] positions = new Vector3[_subdivide];

        for (int i = 0; i < _subdivide; i++)
        {
            positions[i] = new Vector3(Mathf.Cos(2 * Mathf.PI / _subdivide * i), Mathf.Sin(2 * Mathf.PI / _subdivide * i), 0) * _radius;
        }

        _lineRenderer.positionCount = _subdivide;
        _lineRenderer.SetPositions(positions);
        
    }

    private void Update()
    {
        if (_alpha < _maxAlpha)
            _alpha += Time.deltaTime * _alphaSpeed;
        
        _lineRenderer.material.color = new Color(_lineRenderer.material.color.r, _lineRenderer.material.color.g, _lineRenderer.material.color.b, _alpha);
    }

    public void ResetAlpha()
    {
        _alpha = 0;
    }
}
