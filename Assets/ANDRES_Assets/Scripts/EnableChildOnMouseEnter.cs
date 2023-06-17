using UnityEngine;

public class EnableChildOnMouseEnter : MonoBehaviour {
    private GameObject secondChild;

    private void Start() {
        // Check if the object has at least two children
        if (transform.childCount >= 2) {
            // Get the reference to the second child
            secondChild = transform.GetChild(1).gameObject;

            // Disable the second child initially
            secondChild.SetActive(false);
        }
    }

    private void OnMouseEnter() {
        // Check if the second child is available
        if (secondChild != null) {
            // Enable the second child on mouse enter
            secondChild.SetActive(true);
        }
    }

    private void OnMouseExit() {
        // Check if the second child is available
        if (secondChild != null) {
            // Disable the second child on mouse exit
            secondChild.SetActive(false);
        }
    }
}