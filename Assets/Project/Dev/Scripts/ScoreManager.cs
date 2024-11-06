using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    [SerializeField] 
    private TMP_Text scoreText;
    
    private int _currentScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);
    }

    public void AddScore(int amount)
    {
        _currentScore += amount;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return _currentScore;
    }

    public void Reset()
    {
        _currentScore = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {_currentScore}";
        }
    }
}