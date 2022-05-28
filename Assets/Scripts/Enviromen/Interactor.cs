using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private int _fuelValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) == true)
        {
            player.AddFuel(_fuelValue);
            Destroy(gameObject);
        }
    }
}
