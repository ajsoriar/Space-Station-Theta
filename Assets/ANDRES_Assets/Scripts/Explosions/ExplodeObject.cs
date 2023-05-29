using UnityEngine;

public class ExplodeObject : MonoBehaviour {
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 2f;
    public float explosionDuration = 2f;

    private bool isExploded = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isExploded) {
            Explode();
        }
    }

    private void Explode() {
        isExploded = true;

        // Disable any colliders or physics interactions
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders) {
            collider.enabled = false;
        }

        // Apply explosion force to all rigidbodies within the explosion radius
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies) {
            Vector3 direction = rb.transform.position - transform.position;
            float distance = direction.magnitude;

            if (distance <= explosionRadius) {
                float normalizedDistance = Mathf.Clamp01(1f - (distance / explosionRadius));
                float force = normalizedDistance * explosionForce;

                rb.AddExplosionForce(force, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            }
        }

        // Destroy the object after the explosion duration
        Destroy(gameObject, explosionDuration);
    }
}