using UnityEngine.Events;
using UnityEngine;

public class Enemy : Rocket
{
    public event UnityAction Damaged;
    
    public override void Damage()
    {
        base.Damage();
        Damaged?.Invoke();
    }
}
