using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootDelay = .5f;
    
    private bool _isActive = false;
    private Rocket _target;
    private float _nextShootTime;

    private void Awake()
    {
        _nextShootTime = Time.time + _shootDelay;
    }

    private void Update()
    {
        if (_isActive == true && _target != null)
        {
            if (Time.time > _nextShootTime)
            {
                _nextShootTime = Time.time + _shootDelay;
                var launchAngle = Random.Range(0, 2 * Mathf.PI);
                var launchOffsetPosition = new Vector3(Mathf.Cos(launchAngle), Mathf.Sin(launchAngle), 0);
                var bullet = Instantiate(_bullet, transform.position + launchOffsetPosition, Quaternion.FromToRotation(Vector3.forward, launchOffsetPosition));
                bullet.Init(_target);
            }
        }
    }

    public void Activate(Rocket target)
    {
        _target = target;
        _isActive = true;
    }
}
