using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootDelay = .5f;
    [SerializeField] private ParticleSystem _attackParticles;
    [SerializeField] private Vector3 _particlesOffset;
    
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
                var attackParticles = Instantiate(_attackParticles, transform.position + _particlesOffset, quaternion.identity);
                Destroy(attackParticles.gameObject, attackParticles.main.duration);
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
