using System.Collections;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _lookOffset;
    [SerializeField] private Vector3 _closerPosition;

    private void Update()
    {
        var playerPosition = _player.transform.position;
        var position = transform.position;
        var direction = (new Vector3(playerPosition.x, playerPosition.y, position.z + _lookOffset) - position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
    }

    public void MoveCloser()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (transform.localPosition != _closerPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _closerPosition, Time.deltaTime);
            yield return null;
        }
    }
}
