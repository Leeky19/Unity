using UnityEngine;
using TMPro;

public class VictoryManager : MonoBehaviour
{
    public static VictoryManager Instance;
    public GameObject victoryCanvas;
    public TextMeshProUGUI finalScoreText;
    public PlayerReset playerReset; // Référence au script PlayerReset
    public PieceManager pieceManager; // Référence au script PieceManager

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
        victoryCanvas.SetActive(false);
    }

    public void ShowVictoryScreen(int finalScore)
    {
        victoryCanvas.SetActive(true);
        finalScoreText.text = "Final Score: " + finalScore.ToString();
        Time.timeScale = 0; // Arrête le temps du jeu pour afficher l'écran de victoire
    }

    public void Replay()
    {
        Time.timeScale = 1; // Redémarre le temps du jeu
        victoryCanvas.SetActive(false);
        ScoreManager.instance.ResetScoreAndTimer();
        playerReset.ResetPosition(); // Réinitialiser la position du joueur
        pieceManager.ResetPieces(); // Réinitialiser les pièces
        // Réinitialisez d'autres éléments nécessaires pour le jeu ici
    }

    public void QuitGame()
    {
        // Code pour quitter le jeu
        Application.Quit();
#if UNITY_EDITOR
        // Code pour arrêter le jeu dans l'éditeur
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
