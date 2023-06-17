using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ObjectExplosion2 : MonoBehaviour {
    public GameObject explosionPrefab;
    public Material blackMaterial;
    public float SetExplosionForce = 30f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.K)) {
            Explode();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        // Check if the collision involves another object
        if (collision.gameObject != null) {
            if (collision.gameObject.CompareTag("Player_Projectile")) {
                Explode();
                SoundManager.THIS.PlaySound_Enemy_Dies();
            }
        }
    }

    private void Explode() {
        // Create a new explosion object as a sibling
        GameObject explosionObject = new GameObject("Explosion");
        explosionObject.transform.parent = transform.parent;

        // Attach a new instance of MyCustomScript to the cloned object
        MyCustomScript myCustomScript = explosionObject.AddComponent<MyCustomScript>();
        myCustomScript.Initialize(); // Optionally, initialize the script if needed

        // Clone all children objects and parent them to the explosion object
        foreach (Transform child in transform) {
            GameObject childObject = Instantiate(child.gameObject, child.position, child.rotation);
            childObject.transform.parent = explosionObject.transform;

            // Add a Rigidbody component to the cloned object if it doesn't exist
            Rigidbody childRigidbody = childObject.GetComponent<Rigidbody>();
            if (childRigidbody == null) {
                childRigidbody = childObject.AddComponent<Rigidbody>();
                childRigidbody.mass = 0.5f; // Set the mass to 0.5
            }

            // Remove texture from the cloned object
            Renderer childRenderer = childObject.GetComponent<Renderer>();
            if (childRenderer != null) {
                childRenderer.material = blackMaterial;
            }

            // Remove colliders from the cloned object
            Collider childCollider = childObject.GetComponent<Collider>();
            if (childCollider != null) {
                Destroy(childCollider);
            }

            // Set the color of the cloned object to black
            SetObjectColor(childObject, new Color(0f, 0f, 0f, 0.8f));

            // Add a force to the cloned object in a random upward direction
            if (childRigidbody != null) {
                float lol = SetExplosionForce;
                Vector3 explosionForce = Quaternion.Euler(Random.Range(-lol, lol), Random.Range(-lol, lol), Random.Range(-lol, lol)) * Vector3.up;
                childRigidbody.AddForce(explosionForce * 10f, ForceMode.Impulse);
            }

            // Apply a random rotation on the x, y, and z axes
            Vector3 randomRotation = new Vector3(Random.Range(360f, 720f), Random.Range(360f, 720f), Random.Range(360f, 720f));
            childObject.transform.Rotate(randomRotation * Time.deltaTime);

            //StartCoroutine(FadeObject(childObject, 2f));
        }

        // Deactivate the original object
        gameObject.SetActive(false);

        // Destroy the explosion object after two seconds
        StartCoroutine(DestroyExplosionObject(explosionObject, 2f));
    }

    private IEnumerator DestroyExplosionObject(GameObject explosionObject, float delay) {
        yield return new WaitForSeconds(delay);
        explosionObject.SetActive(false);
        //Destroy(explosionObject);
    }

    //private IEnumerator RotateObjectContinuously(GameObject obj, float rotationSpeed) {
    //    while (true) {
    //        obj.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    //        obj.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    //        obj.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    //        yield return null;
    //    }
    //}

    private float GenerateRandomRotationSpeed(float minSpeed, float maxSpeed) {
        return Random.Range(minSpeed, maxSpeed);
    }

    private void SetObjectColor(GameObject obj, Color color) {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null) {
            renderer.material.color = color;
        }

        foreach (Transform child in obj.transform) {
            SetObjectColor(child.gameObject, color);
        }
    }

    private GameObject CreateEmptyObjectSibling() {
        GameObject emptyObject = new GameObject("ExplosionHelper");
        emptyObject.transform.parent = transform.parent;
        return emptyObject;
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











/*

using System.Collections;
using UnityEngine;

public class ObjectExplosion2 : MonoBehaviour {
    public GameObject explosionPrefab;
    public Material blackMaterial;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Explode();
        }
    }

    private void Explode() {
        // Create a new explosion object as a sibling
        GameObject explosionObject = new GameObject("Explosion");
        explosionObject.transform.parent = transform.parent;

        // Clone all children objects and parent them to the explosion object
        foreach (Transform child in transform) {
            GameObject childObject = Instantiate(child.gameObject, child.position, child.rotation);
            childObject.transform.parent = explosionObject.transform;

            // Add a Rigidbody component to the cloned object if it doesn't exist
            Rigidbody childRigidbody = childObject.GetComponent<Rigidbody>();
            if (childRigidbody == null) {
                childRigidbody = childObject.AddComponent<Rigidbody>();
            }

            // Remove texture from the cloned object
            Renderer childRenderer = childObject.GetComponent<Renderer>();
            if (childRenderer != null) {
                childRenderer.material = blackMaterial;
            }

            // Remove colliders from the cloned object
            Collider childCollider = childObject.GetComponent<Collider>();
            if (childCollider != null) {
                Destroy(childCollider);
            }

            // Set the color of the cloned object to black
            SetObjectColor(childObject, Color.black);

            // Add a force to the cloned object in a random upward direction
            //Rigidbody childRigidbody = childObject.GetComponent<Rigidbody>();
            if (childRigidbody != null) {
                Vector3 explosionForce = Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(-30f, 30f), Random.Range(-30f, 30f)) * Vector3.up;
                childRigidbody.AddForce(explosionForce * 10f, ForceMode.Impulse);
            }

            // Apply a random rotation on the x, y, and z axes
            Vector3 randomRotation = new Vector3(Random.Range(360f, 720f), Random.Range(360f, 720f), Random.Range(360f, 720f));
            childObject.transform.Rotate(randomRotation * Time.deltaTime);
        }

        // Deactivate the original object
        gameObject.SetActive(false);
    }

    private void SetObjectColor(GameObject obj, Color color) {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null) {
            renderer.material.color = color;
        }

        foreach (Transform child in obj.transform) {
            SetObjectColor(child.gameObject, color);
        }
    }

    private GameObject CreateEmptyObjectSibling() {
        GameObject emptyObject = new GameObject("ExplosionHelper");
        emptyObject.transform.parent = transform.parent;
        return emptyObject;
    }
}
 
 
*/
















/*

using UnityEngine;

public class ObjectExplosion2 : MonoBehaviour {
    public GameObject explosionPrefab;
    public Material blackMaterial;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Explode();
        }
    }

    private void Explode() {

        // Create a new explosion object
        GameObject explosionObject = CreateEmptyObjectSibling(); // Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Clone all children objects and parent them to the explosion object
        foreach (Transform child in transform) {
            GameObject childObject = Instantiate(child.gameObject, child.position, child.rotation);
            childObject.transform.parent = explosionObject.transform;

            // Remove texture from the cloned object
            Renderer childRenderer = childObject.GetComponent<Renderer>();
            if (childRenderer != null) {
                childRenderer.material = blackMaterial;
            }

            // Remove colliders from the cloned object
            Collider childCollider = childObject.GetComponent<Collider>();
            if (childCollider != null) {
                Destroy(childCollider);
            }

            // Set the color of the cloned object to black
            SetObjectColor(childObject, Color.black);

            // Set the color of the cloned object to black
            SetObjectColor(childObject, Color.black);

            // Add a force to the cloned object in a random upward direction
            Rigidbody childRigidbody = childObject.GetComponent<Rigidbody>();
            if (childRigidbody != null) {
                Vector3 explosionForce = Quaternion.Euler(Random.Range(-15f, 15f), Random.Range(-15f, 15f), Random.Range(-15f, 15f)) * Vector3.up;
                childRigidbody.AddForce(explosionForce, ForceMode.Impulse);
            }
        }

        // Deactivate the original object
        gameObject.SetActive(false);

    }

    private void SetObjectColor(GameObject obj, Color color) {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null) {
            renderer.material.color = color;
        }

        foreach (Transform child in obj.transform) {
            SetObjectColor(child.gameObject, color);
        }
    }

    private GameObject CreateEmptyObjectSibling() {
        GameObject emptyObject = new GameObject("ExplosionHelper");
        emptyObject.transform.parent = transform.parent;
        return emptyObject;
    }
}
*/

/*
using UnityEngine;

public class ObjectExplosion2 : MonoBehaviour {
    public GameObject explosionPrefab;
    public Material blackMaterial;
    public float explosionForce = 10f;
    public float rotationSpeed = 100f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Explode();
        }
    }

    private void Explode() {
        // Create a new explosion object
        GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Clone all children objects and parent them to the explosion object
        foreach (Transform child in transform) {
            GameObject childObject = Instantiate(child.gameObject, child.position, child.rotation);
            childObject.transform.parent = explosionObject.transform;

            // Remove texture from the cloned object
            Renderer childRenderer = childObject.GetComponent<Renderer>();
            if (childRenderer != null) {
                childRenderer.material = blackMaterial;
            }

            // Remove colliders from the cloned object
            Collider childCollider = childObject.GetComponent<Collider>();
            if (childCollider != null) {
                Destroy(childCollider);
            }

            // Set the color of the cloned object to black
            SetObjectColor(childObject, Color.black);

            // Apply explosion force to the cloned object
            Rigidbody childRigidbody = childObject.GetComponent<Rigidbody>();
            if (childRigidbody != null) {
                Vector3 explosionDirection = (childObject.transform.position - transform.position).normalized;
                childRigidbody.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);
            }

            // Make the cloned object rotate randomly
            childObject.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotationSpeed;
        }

        // Deactivate the original object
        gameObject.SetActive(false);
    }

    private void SetObjectColor(GameObject obj, Color color) {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null) {
            renderer.material.color = color;
        }

        foreach (Transform child in obj.transform) {
            SetObjectColor(child.gameObject, color);
        }
    }
}

*/




/*
using UnityEngine;

public class ObjectExplosion2 : MonoBehaviour {
    public GameObject explosionPrefab;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Explode();
        }
    }
    private void Explode() {
        // Create a new explosion object
        GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Clone all children objects and parent them to the explosion object
        foreach (Transform child in transform) {
            GameObject childObject = Instantiate(child.gameObject, child.position, child.rotation);
            childObject.transform.parent = explosionObject.transform;
        }

        // Deactivate the original object
        gameObject.SetActive(false);
    }

}
*/
