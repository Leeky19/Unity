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
        Time.timeScale = 0; // Arrête le temps du jeu pour afficher l'écran de Game Over
    }

    public void Replay()
    {
        Time.timeScale = 1; // Redémarre le temps du jeu
        gameOverCanvas.SetActive(false);
        scoreManager.ResetScoreAndTimer();
        // Réinitialisez d'autres éléments nécessaires pour le jeu ici
    }
}
