using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<Mover>().Stop();
            player.GetComponent<Attacker>().Activate(_enemy);
            _enemy.GetComponent<Attacker>().Activate(player);
        }
    }
}
