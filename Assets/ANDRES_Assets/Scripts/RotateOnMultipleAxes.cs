using UnityEngine;

public class RotateOnMultipleAxes : MonoBehaviour
{
    public float rotationSpeedX = 2f;
    public float rotationSpeedY = 1f;
    public float rotationSpeedZ = 1f;

    void Update()
    {
        // Rotate the object on each axis based on the specified rotation speeds
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;

        transform.Rotate(rotationX, rotationY, rotationZ);
    }
}