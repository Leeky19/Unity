using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int pointValue = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(pointValue);
            Destroy(gameObject); // D�truire la sph�re une fois collect�e
        }
    }
}
