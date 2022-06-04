using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 30;


    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0,360), 0);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }
}
