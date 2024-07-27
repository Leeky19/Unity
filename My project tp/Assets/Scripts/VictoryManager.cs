using UnityEngine;
using TMPro;

public class VictoryManager : MonoBehaviour
{
    public static VictoryManager Instance;
    public GameObject victoryCanvas;
    public TextMeshProUGUI finalScoreText;
    public PlayerReset playerReset; // R�f�rence au script PlayerReset
    public PieceManager pieceManager; // R�f�rence au script PieceManager

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
        Time.timeScale = 0; // Arr�te le temps du jeu pour afficher l'�cran de victoire
    }

    public void Replay()
    {
        Time.timeScale = 1; // Red�marre le temps du jeu
        victoryCanvas.SetActive(false);
        ScoreManager.instance.ResetScoreAndTimer();
        playerReset.ResetPosition(); // R�initialiser la position du joueur
        pieceManager.ResetPieces(); // R�initialiser les pi�ces
        // R�initialisez d'autres �l�ments n�cessaires pour le jeu ici
    }

    public void QuitGame()
    {
        // Code pour quitter le jeu
        Application.Quit();
#if UNITY_EDITOR
        // Code pour arr�ter le jeu dans l'�diteur
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
