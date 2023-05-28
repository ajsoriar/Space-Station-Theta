using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosionOnCollision : MonoBehaviour {
    public GameObject spherePrefab;

    private void OnCollisionEnter(Collision collision) {
        // Check if the collision involves another object
        if (collision.gameObject != null) {
            // Get the collision point relative to the world
            Vector3 collisionPoint = collision.contacts[0].point;

            // Instantiate a sphere at the collision point
            Instantiate(spherePrefab, collisionPoint, Quaternion.identity);
        }
    }
}