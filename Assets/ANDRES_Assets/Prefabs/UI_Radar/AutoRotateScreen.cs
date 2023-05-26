using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine;

using UnityEngine;

public class AutoRotateScreen : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 5f;

    private void Start()
    {
        // Find the player object by tag or assign it manually
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Get the player's Z-rotation and apply it to the object's Z-rotation
            float playerRotationZ = playerTransform.eulerAngles.z;
            Vector3 targetEulerAngles = new Vector3(0f, 0f, playerRotationZ);
            Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

/*
public class AutoRotateScreen : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 5f;

    private void Start()
    {
        // Find the player object by tag or assign it manually
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Get the player's Y-rotation and apply it to the object's Y-rotation
            float playerRotationY = playerTransform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0f, playerRotationY, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
*/

/*
using UnityEngine;

public class AutoRotateScreen : MonoBehaviour
{
    public Transform playerTransform;
    private Quaternion initialRotation;

    private void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation;

        // Find the player object by tag or assign it manually
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            // Get the player's Y-rotation and apply it to the object
            float playerRotationY = playerTransform.eulerAngles.y;
            //Quaternion newRotation = Quaternion.Euler(initialRotation.eulerAngles.x, playerRotationY, initialRotation.eulerAngles.z);
            Quaternion newRotation = Quaternion.Euler(0, playerRotationY, 0);
            transform.rotation = newRotation;
        }
    }
}
*/