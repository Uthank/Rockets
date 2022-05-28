using UnityEngine;

public class Looker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _lookOffset;

    private void Update()
    {
        var direction =
            (new Vector3(_player.transform.position.x, _player.transform.position.y,
                transform.position.z + _lookOffset) - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
    }
}
