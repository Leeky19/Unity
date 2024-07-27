using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Vitesse de d�placement

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Clic droit
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // R�cup�re l'entr�e horizontale (axe X)
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}

