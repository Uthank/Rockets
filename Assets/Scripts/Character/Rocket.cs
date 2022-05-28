using UnityEngine;
using UnityEngine.Events;

public class Rocket : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _fuel = 25;

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
        Destroy(gameObject);
    }
}
