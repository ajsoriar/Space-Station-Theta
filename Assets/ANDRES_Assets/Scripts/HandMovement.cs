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
    //public Rigidbody playerRb;
    public GameObject player;
    private bool isMoving = false;
    public float amplitude = 0.1f;  // Amplitude of the sine wave
    public float frequency = 1f;   // Frequency of the sine wave
    public float offset = 0f;      // Offset of the sine wave

    private Vector3 initialPosition;    // Initial position of the hand


    //private PlayerMovement playerMovement;

    void Start()
    {
        // Store the initial position of the hand
        initialPosition = transform.localPosition;
        //PlayerObject = 
        //playerRb = GetComponent<Rigidbody>();
        // Get the parent GameObject
        //GameObject parentObject = transform.parent.gameObject;
        // Get the parent of the parent GameObject
        //GameObject grandparentObject = parentObject.transform.parent.gameObject;
        // Print the name of the grandparent GameObject
        //Debug.Log("Grandparent Object: " + grandparentObject.name);
        //Script parentScript = grandparentObject.GetComponent<ParentScript>();
    }

    void Update()
    {
        /*
        float velocityMagnitude = rb.velocity.magnitude;
        string velocityString = velocityMagnitude.ToString("F2");
        UpdateTextMesh("HolaText2", "Is moving! velocity: " + velocityString);

        if (rb.velocity.magnitude > 0 && !isMoving)
        {
            isMoving = true;
            //UpdateTextMesh("HolaText2", "Is moving!" + velocityString);
        }
        else if (rb.velocity.magnitude == 0 && isMoving)
        {
            isMoving = false;
            //UpdateTextMesh("HolaText2", "Is not moving.");
        }

        if (isMoving) {
            // Calculate the new position of the hand based on the sine wave
            float yOffset = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time + offset);
            Vector3 newPosition = initialPosition + Vector3.up * yOffset;

            // Update the position of the hand
            transform.localPosition = newPosition;
        }
        */

        //bool isMoving = player.gameObject.active; // GetBool("puertaAbierta");  //playerIsMoving;

        if (isMoving)
        {
            // Calculate the new position of the hand based on the sine wave
            float yOffset = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time + offset);
            Vector3 newPosition = initialPosition + Vector3.up * yOffset;

            // Update the position of the hand
            transform.localPosition = newPosition;
        }

    }

    /*
   
    // move to utils library?
    public void UpdateTextMesh(string textMeshName, string newText) // Thanks ChatGPT
    {
        GameObject gameObjectWithTextMesh = GameObject.Find(textMeshName);
        if (gameObjectWithTextMesh != null)
        {
            TextMesh textMeshComponent = gameObjectWithTextMesh.GetComponentInChildren<TextMesh>();
            if (textMeshComponent != null)
            {
                textMeshComponent.text = newText;
            }
            else
            {
                Debug.LogError("No TextMesh component found on game object: " + textMeshName);
            }
        }
        else
        {
            Debug.LogError("Could not find game object: " + textMeshName);
        }
    }

    */
}

/*
 
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
    public bool isMoving = false;
    public float amplitude = 0.1f;  // Amplitude of the sine wave
    public float frequency = 1f;   // Frequency of the sine wave
    public float offset = 0f;      // Offset of the sine wave

    //If the IsKinematic property of a Rigidbody is set to true, the physics engine will not 
    //simulate the motion of the Rigidbody. Therefore, the rb.velocity.magnitude will always 
    //be zero, and the isMovingUp boolean will never be set to true.
    //To solve this issue, you can use a different method to detect the movement of the Rigidbody. 

    private Vector3 initialPosition;    // Initial position of the hand
    private Vector3 previousPosition;
    private float movementThreshold = 0.01f; // adjust this value to your needs
    private bool isMovingUp;

    void Start()
    {
        // Store the initial position of the hand
        initialPosition = transform.localPosition;
        previousPosition = rb.position;
    }
    void Update()
    {
        // Method based on IsKinematic set to true
        //if (rb.velocity.magnitude > 0 && !isMovingUp)
        //{
        //    isMovingUp = true;
        //    // Call your function here
        //}
        //else if (rb.velocity.magnitude == 0 && isMovingUp)
        //{
        //    isMovingUp = false;
        //}

        // Method that does not depend on IsKinematic
        Vector3 currentPosition = rb.position;
        float distance = Vector3.Distance(currentPosition, previousPosition);

        if (distance > movementThreshold)
        {
            isMovingUp = !isMovingUp; // toggle the value of isMovingUp
        }

        previousPosition = currentPosition;
    }
    private void FixedUpdate()
    {
        if (isMovingUp)
        {
            // Calculate the new position of the hand based on the sine wave
            float yOffset = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time + offset);
            Vector3 newPosition = initialPosition + Vector3.up * yOffset;

            // Update the position of the hand
            transform.localPosition = newPosition;
        }
    }
}

*/

