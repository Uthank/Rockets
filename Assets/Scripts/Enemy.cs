using UnityEngine.Events;
using UnityEngine;

public class Enemy : Rocket
{
    [SerializeField] private ParticleSystem _hitParticle;
    public event UnityAction Damaged;
    
    public override void Damage()
    {
        base.Damage();
        Damaged?.Invoke();
        var hitParticle = Instantiate(_hitParticle, transform.position, Quaternion.identity);
        Destroy(hitParticle.gameObject, hitParticle.main.duration);
    }
}
