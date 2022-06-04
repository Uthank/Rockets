using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private TMP_Text _scoreText;
    private int _score = 0;
    
    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoreText.text = "";
    }

    private void OnEnable()
    {
        _enemy.Damaged += OnEnemyHit;
        
    }

    private void OnDisable()
    {
        _enemy.Damaged -= OnEnemyHit;
    }

    private void OnEnemyHit()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
