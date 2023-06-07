using UnityEngine;

public class RestrictedRotation2 : MonoBehaviour {
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 10f;
    public float leftLimit = -10f;
    public float rightLimit = 10f;

    private float currentAngle;

    private void Start() {
        currentAngle = 0f;
    }

    private void Update() {
        // Update the current angle based on the rotation speed and time
        currentAngle += rotationSpeed * Time.deltaTime;

        // Restrict the angle within the specified limits
        if (currentAngle > rightLimit) {
            currentAngle = rightLimit;
            rotationSpeed *= -1f; // Reverse the rotation direction
        } else if (currentAngle < leftLimit) {
            currentAngle = leftLimit;
            rotationSpeed *= -1f; // Reverse the rotation direction
        }

        // Apply the rotation to the object
        transform.localRotation = Quaternion.AngleAxis(currentAngle, rotationAxis);
    }
}
