/*
To achieve the desired effect of gradually scaling an object like an explosion in 10 steps 
while making it more transparent until it completely disappears, you can use a combination 
of scaling and adjusting the object's material transparency. Here's an example script that 
demonstrates this behavior:
*/

using UnityEngine;

public class ExplosionEffect : MonoBehaviour {
    public float duration = 1f; // Duration of the explosion effect in seconds
    public AnimationCurve scaleCurve; // Animation curve for scaling over time
    public AnimationCurve alphaCurve; // Animation curve for transparency over time

    private float timer; // Timer to track the current time
    private Renderer objectRenderer; // Reference to the object's renderer
    private Material objectMaterial; // Reference to the object's material

    private void Start() {
        objectRenderer = GetComponent<Renderer>();
        objectMaterial = objectRenderer.material;

        // Initialize the timer
        timer = 0f;
    }

    private void Update() {
        // Update the timer based on the elapsed time
        timer += Time.deltaTime;

        // Calculate the normalized time based on the duration
        float normalizedTime = Mathf.Clamp01(timer / duration);

        // Scale the object using the animation curve
        float scale = scaleCurve.Evaluate(normalizedTime);
        transform.localScale = new Vector3(scale, scale, scale);

        // Adjust the object's transparency using the animation curve
        Color objectColor = objectMaterial.color;
        objectColor.a = alphaCurve.Evaluate(normalizedTime);
        objectMaterial.color = objectColor;

        // Check if the explosion effect has ended
        if (normalizedTime >= 1f) {
            // Destroy the object
            //Destroy(gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}