using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float walkingSpeed = 0.5f;
    public float runningSpeed = 1.5f;
    public float stoppingDistance = 2f;
    public float stopDistance2 = 10f;
    public float startDistance = 5f;

    private bool isRunning;
    private bool isMoving = false;

    private void Start()
    {
        // Genera un valor aleatorio para isRunning
        isRunning = Random.value < 0.5f;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found in the scene.");
        }
    }

    private void Update()
    {
        // Comienza el avance si estamos m�s lejos que startDistance
        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) < startDistance) {
            isMoving = true;
        }

        if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) > stopDistance2)
        {
            isMoving = false;
        }

        // Calcula la velocidad actual seg�n si est� corriendo o caminando
        float speed = isRunning ? runningSpeed : walkingSpeed;

        // Calcula la direcci�n hacia el jugador
        Vector3 direction = playerTransform.position - transform.position;

        // Verifica la distancia al jugador
        float distanceToPlayer = direction.magnitude;
        if (distanceToPlayer > stoppingDistance)
        {
            // Normaliza la direcci�n para mantener una velocidad constante
            direction.Normalize();

            // Mueve el GameObject en la direcci�n hacia el jugador a la velocidad adecuada
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // Detiene el movimiento cuando estamos lo suficientemente cerca del jugador
            isMoving = false;
        }
    }

    public void SetRunning(bool value)
    {
        isRunning = value;
    }
}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public float walkingSpeed = 0.5f;
    public float runningSpeed = 1.5f;
    public float stoppingDistance = 2f;

    private bool isRunning;

    private void Start()
    {
        // Genera un valor aleatorio para isRunning
        isRunning = Random.value < 0.5f;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found in the scene.");
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Calcula la velocidad actual seg�n si est� corriendo o caminando
            float speed = isRunning ? runningSpeed : walkingSpeed;

            // Calcula la direcci�n hacia el jugador
            Vector3 direction = playerTransform.position - transform.position;

            // Verifica la distancia al jugador
            if (direction.magnitude > stoppingDistance)
            {
                // Normaliza la direcci�n para mantener una velocidad constante
                direction.Normalize();

                // Mueve el GameObject en la direcci�n hacia el jugador a la velocidad adecuada
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    public void SetRunning(bool value)
    {
        isRunning = value;
    }
}

*/