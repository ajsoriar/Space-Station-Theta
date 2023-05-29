using System.Collections;
using UnityEngine;

public class MyCustomScript : MonoBehaviour {
    public void Initialize() {
        StartCoroutine(DestroyAfterDelay(4f));
        //StartCoroutine(FadeObject(gameObject, 2f));
    }

    private IEnumerator DestroyAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    /*
    private IEnumerator FadeObject(GameObject obj, float duration) {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null) {
            // Get the initial color
            Color startColor = renderer.material.color;
            Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // Transparent color

            // Perform the fade over the specified duration
            float startTime = Time.time;
            float elapsedTime = 0f;
            while (elapsedTime < duration) {
                float t = elapsedTime / duration;
                renderer.material.color = Color.Lerp(startColor, targetColor, t);
                elapsedTime = Time.time - startTime;
                yield return null;
            }

            // Ensure the object becomes fully transparent
            renderer.material.color = targetColor;
        }
    }
    */

}