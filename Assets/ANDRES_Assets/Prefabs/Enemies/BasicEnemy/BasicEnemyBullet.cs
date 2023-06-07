using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag("Player")) {
            AJSR_Player_PrimeraPersona_2.THIS.decreaseHeath(5);

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