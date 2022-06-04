using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Finish : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private CameraBehavior _mainCamera;
    [SerializeField] private GameObject _confetti;
    [SerializeField] private GameObject _complitedUI;
    [SerializeField] private GameObject _continueUI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(PrepareBattle(player));
        }
    }

    private void OnEnable()
    {
        _enemy.Killed += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _enemy.Killed -= OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        _confetti.SetActive(true);
        _complitedUI.SetActive(true);
        _continueUI.SetActive(true);
    }

    private IEnumerator PrepareBattle(Player player)
    {
        player.GetComponent<Mover>().Stop();
        _mainCamera.MoveCloser();
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<Attacker>().Activate(_enemy);
        _enemy.GetComponent<Attacker>().Activate(player);
    }
}
