using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public GameObject[] pieces; // Assignez vos pi�ces dans l'Inspector

    void Start()
    {
        // R�initialisez les pi�ces � leur position initiale si n�cessaire
    }

    public void ResetPieces()
    {
        // R�initialise la position des pi�ces
        foreach (GameObject piece in pieces)
        {
            piece.SetActive(true); // Assurez-vous que les pi�ces sont actives
            // R�initialisez leur position � celle de d�part
            piece.transform.position = piece.GetComponent<PieceReset>().initialPosition;
        }
    }
}
