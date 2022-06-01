using UnityEngine;
using UnityEngine.Events;

public class Rocket : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _fuel = 25;
    [SerializeField] protected ParticleSystem _deadParticles;

    public event UnityAction Killed;
    
    public virtual void Damage()
    {
        _fuel--;

        if (_fuel <= 0)
            Die();
    }
    
    protected void Die()
    {
        Killed?.Invoke();
        var particles = Instantiate(_deadParticles, transform.position, Quaternion.identity);
        Destroy(particles.gameObject, particles.main.duration);
        Destroy(gameObject);
    }
}
