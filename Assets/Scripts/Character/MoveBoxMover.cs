using UnityEngine;

public class MoveBoxMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * Vector3.forward;
    }

    public void Stop()
    {
        _speed = 0;
    }
}
