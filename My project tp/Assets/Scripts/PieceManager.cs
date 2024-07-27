using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public GameObject[] pieces; // Assignez vos pièces dans l'Inspector

    void Start()
    {
        // Réinitialisez les pièces à leur position initiale si nécessaire
    }

    public void ResetPieces()
    {
        // Réinitialise la position des pièces
        foreach (GameObject piece in pieces)
        {
            piece.SetActive(true); // Assurez-vous que les pièces sont actives
            // Réinitialisez leur position à celle de départ
            piece.transform.position = piece.GetComponent<PieceReset>().initialPosition;
        }
    }
}
