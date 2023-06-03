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

    private float speed;
    private bool isMoving = false;

    private bool isPlayerNear = false;
    public float checkInterval = 3f;
    public float playerDistanceThreshold = 5f;
    private GameObject player;

    private void Start()
    {
        speed = GetRandomVelocity();
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerTransform = player.transform;
        } else {
            Debug.LogWarning("Player object not found in the scene.");
        }
        InvokeRepeating("CheckPlayerDistance", 0f, checkInterval);
    }

    private void Update()
    {

        Vector3 direction = playerTransform.position - transform.position;
        float distanceToPlayer = direction.magnitude;


        if (isMoving) {


            if (distanceToPlayer < stoppingDistance) {
                isMoving = true;
            } else {
                isMoving = false;
            }

        } else { 

            if (isPlayerNear) {
                isMoving = true;
            } else {
                isMoving = false;
            }        
        
        }

        if (isMoving) {
            // Normaliza la dirección para mantener una velocidad constante
            direction.Normalize();

            // Mueve el GameObject en la dirección hacia el jugador a la velocidad adecuada
            transform.position += direction * speed * Time.deltaTime;
        } else {
            // Detiene el movimiento cuando estamos lo suficientemente cerca del jugador
            isMoving = false;
        }
    }

    private void CheckPlayerDistance() {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            isPlayerNear = distance <= playerDistanceThreshold;
        }
    }

    private float GetRandomVelocity() {
        // Generate a random value between walkingSpeed and runningSpeed
        float randomVelocity = Random.Range(walkingSpeed, runningSpeed);
        return randomVelocity;
    }
}