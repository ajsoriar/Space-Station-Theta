using UnityEngine;

public class RotateForeverAllMyLife : MonoBehaviour {
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 30f;

    private void Update() {
        // Rotate the object continuously
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}