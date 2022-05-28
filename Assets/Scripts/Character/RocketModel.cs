using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketModel : MonoBehaviour
{
    [SerializeField] private float _dissolveSpeed = 1;

    private const string _dissolveParametr = "_dissolve";
    private IEnumerator _routine;

    private List<Material> _materials = new List<Material>();

    private void Awake()
    {
        var renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            _materials.Add(renderer.material);
        }
    }

    public void Dissolve()
    {
        _routine = DissolveCourutine();
        StartCoroutine(_routine);
    }

    public void Resolve()
    {
        gameObject.SetActive(true);
        _routine = ResolveCourutine();
        StartCoroutine(_routine);
    }

    private IEnumerator ResolveCourutine()
    {
        for (float i = 1; i > 0; i -= Time.deltaTime * _dissolveSpeed)
        {
            foreach (var material in _materials)
            {
                material.SetFloat(_dissolveParametr, i);
            }
            
            yield return null;
        }
    }

    private IEnumerator DissolveCourutine()
    {
        for (float i = 0; i < 1; i += Time.deltaTime * _dissolveSpeed)
        {
            foreach (var material in _materials)
            {
                material.SetFloat(_dissolveParametr, i);
            }
            
            yield return null;
        }
        
        gameObject.SetActive(false);
    }
}
