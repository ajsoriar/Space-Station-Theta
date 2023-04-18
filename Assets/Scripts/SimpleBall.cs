using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Create a script that is applied to an object and makes it move from its position to y+3.
// After that, the object should return to its original position and repeat the movement in a loop.
public class SimpleBall : MonoBehaviour
{
    private Vector3 originalPosition;   // Store the original position of the object
    private bool isMovingUp = true;     // Flag to track if the object is moving up or down

    public float moveSpeed = 2f;        // Speed of the movement
    public float moveDistance = 3f;     // Distance to move on the y-axis

    private void Start()
    {
        originalPosition = transform.position;   // Store the original position of the object
    }

    private void Update()
    {
        // Calculate the target position based on the current movement direction
        Vector3 targetPosition = isMovingUp ? originalPosition + new Vector3(0f, moveDistance, 0f) : originalPosition;

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            // If the object has reached the target position, toggle the movement direction
            isMovingUp = !isMovingUp;
        }
    }
}
