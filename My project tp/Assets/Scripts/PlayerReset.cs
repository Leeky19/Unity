using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // Stocke la position initiale du joueur
        initialPosition = transform.position;
    }

    public void ResetPosition()
    {
        // Réinitialise la position du joueur
        transform.position = initialPosition;
    }
}
