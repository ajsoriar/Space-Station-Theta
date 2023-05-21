using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// chatGPT prompt:
// I need a function that moves up and down a little an object that will be the 
// player's right hand in a video game. The game is in 1st person so while the 
// player walks the hand will go up and down to simulate the walking or running 
// movement. 

public class HandMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public float amplitude = 0.1f;  // Amplitude of the sine wave
    public float frequency = 1f;   // Frequency of the sine wave
    public float offset = 0f;      // Offset of the sine wave
    private Vector3 initialPosition;    // Initial position of the hand

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (AJSR_Player_PrimeraPersona_2.THIS.playerIsMoving) {
            // Calculate the new position of the hand based on the sine wave
            float yOffset = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time + offset);
            Vector3 newPosition = initialPosition + Vector3.up * yOffset;

            // Update the position of the hand
            transform.localPosition = newPosition;
        }
    }
}
