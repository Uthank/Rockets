using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Dissolver), typeof(Collider))]
public class Interactor : MonoBehaviour
{
    [SerializeField] private int _fuelValue;
    [SerializeField] private ParticleSystem _OnCapturedEffect;

    private Dissolver _dissolver;
    
    private void Awake()
    {
        _dissolver = GetComponent<Dissolver>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) == true)
        {
            var onCapturedEffect = Instantiate(_OnCapturedEffect, player.transform.position - player.transform.forward,
                quaternion.identity);
            Destroy(onCapturedEffect.gameObject, onCapturedEffect.main.duration);
            player.AddFuel(_fuelValue);
            Destroy(gameObject);
        }
        
        
        if (other.TryGetComponent<MoveBoxMover>(out MoveBoxMover moveBoxMover) == true)
        {
            _dissolver.Dissolve();
        }
    }
}
