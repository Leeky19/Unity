using UnityEngine;

public class PieceReset : MonoBehaviour
{
    public Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }
}
