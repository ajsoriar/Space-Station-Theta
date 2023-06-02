using UnityEngine;

public class DebugCircle : MonoBehaviour {
    public float radius = 5f;
    public int segments = 20;

    private void OnDrawGizmos() {
        // Set the color for the circle
        Gizmos.color = Color.white;

        // Calculate the angle between each segment
        float angleIncrement = 360f / segments;

        // Draw the circle by connecting each segment
        for (int i = 0; i < segments; i++) {
            float angle = i * angleIncrement;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            Vector3 point = transform.position + new Vector3(x, 0f, z);
            Gizmos.DrawLine(point, point + Vector3.up); // Draw a line from the circle to its center
        }
    }
}