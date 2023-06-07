using UnityEngine;

public class ObjectDeactivationDetection : MonoBehaviour {
    public GameObject prefabToInstantiate;

    private void OnDisable() {
        // Instantiate the prefab at the position of the deactivated object
        Instantiate(prefabToInstantiate, transform.position, transform.rotation);
    }
}