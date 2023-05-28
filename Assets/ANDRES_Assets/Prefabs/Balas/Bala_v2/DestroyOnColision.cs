/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/

using UnityEngine;

public class DestroyOnColision : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        // Check if the collision involves another object
        if (collision.gameObject != null) {
            // Hide the object by disabling its renderer
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null) {
                renderer.enabled = false;
            }

            // Disable any colliders on the object to prevent further collisions
            Collider collider = GetComponent<Collider>();
            if (collider != null) {
                collider.enabled = false;
            }
        }
    }
}

