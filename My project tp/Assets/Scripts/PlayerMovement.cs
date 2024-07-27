using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float rotationSpeed = 100f;
    public float slideForce = 5f;
    public float slideDuration = 1f;

    private Camera playerCamera;
    private bool isGameOver = false; // État pour savoir si le jeu est terminé

    void Start()
    {
        playerCamera = Camera.main; // Assure-toi que la caméra principale est correctement assignée
    }

    void Update()
    {
        if (isGameOver) return; // Ignorer les entrées si le jeu est terminé

        // Déplacement
        float moveDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 move = transform.forward * moveDirection;
        controller.Move(move);

        // Rotation
        float rotationDirection = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationDirection, 0);

        // Faire glisser le cube avec le clic droit de la souris
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(SlideObject());
        }
    }

    IEnumerator SlideObject()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Pushable"))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 slideDirection = transform.right;
                    rb.AddForce(slideDirection * slideForce, ForceMode.Impulse);
                    yield return new WaitForSeconds(slideDuration);
                    rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
    }

    // Méthode pour activer/désactiver les contrôles
    public void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }
}
