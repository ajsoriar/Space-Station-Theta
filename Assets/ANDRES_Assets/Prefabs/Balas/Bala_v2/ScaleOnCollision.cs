using UnityEngine;

public class ScaleOnCollision : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        // Check if the collision involves another object
        if (collision.gameObject != null) {
            // Increase the scale of the object by tripling its current scale
            transform.localScale *= 4f;
        }
    }
}
