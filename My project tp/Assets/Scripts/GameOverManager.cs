using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public GameObject gameOverCanvas;
    public ScoreManager scoreManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0; // Arr�te le temps du jeu pour afficher l'�cran de Game Over
    }

    public void Replay()
    {
        Time.timeScale = 1; // Red�marre le temps du jeu
        gameOverCanvas.SetActive(false);
        scoreManager.ResetScoreAndTimer();
        // R�initialisez d'autres �l�ments n�cessaires pour le jeu ici
    }
}
