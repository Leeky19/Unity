using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private float timeRemaining = 180f; // Durée initiale du timer
    private bool isGameOver = false;
    public GameObject victoryCanvas; // Canvas pour l'écran de victoire

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        UpdateTimerText();
        victoryCanvas.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                isGameOver = true;
                GameOver(); // Appelle la méthode GameOver quand le temps est écoulé
            }
        }

        // Vérifie si toutes les pièces ont été collectées
        if (score >= 210 && !isGameOver)
        {
            isGameOver = true;
            Victory();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Max(0, Mathf.RoundToInt(timeRemaining)).ToString();
        }
    }

    public void ResetScoreAndTimer()
    {
        score = 0;
        timeRemaining = 180f;
        isGameOver = false;
        UpdateScoreText();
        UpdateTimerText();
        Debug.Log("Score and Timer Reset");
    }

    void GameOver()
    {
        // Implémentez ici l'affichage de l'écran Game Over
        Debug.Log("Game Over");
        GameOverManager.Instance.ShowGameOverScreen();
    }

    void Victory()
    {
        // Calcul du score final
        int finalScore = score + Mathf.RoundToInt(timeRemaining);
        VictoryManager.Instance.ShowVictoryScreen(finalScore);
    }
}
