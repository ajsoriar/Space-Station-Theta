using UnityEngine;

public class ShowRayOfLight : MonoBehaviour {
    public float visibilityDuration = 1f; // Duration in seconds to show the "index" child
    public float checkInterval = 3f; // Interval in seconds to check if the player is near the object
    public float playerDistanceThreshold = 5f; // Distance threshold for the player to be considered near the object

    private GameObject indexChild;
    private float timer = 0f;
    private bool isPlayerNear = false;

    private void Start() {
        HideIndexChild();
        InvokeRepeating("CheckPlayerDistance", 0f, checkInterval);
    }

    private void Update() {
        timer += Time.deltaTime;

        if (isPlayerNear && timer >= visibilityDuration) {
            ShowIndexChild();
            timer = 0f;
        } else if (!isPlayerNear) {
            HideIndexChild();
        }
    }

    private void CheckPlayerDistance() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            isPlayerNear = distance <= playerDistanceThreshold;
        }
    }

    private void HideIndexChild() {
        if (indexChild == null) {
            indexChild = transform.Find("index").gameObject;
        }

        if (indexChild != null) {
            indexChild.SetActive(false);
        }
    }

    private void ShowIndexChild() {
        if (indexChild == null) {
            indexChild = transform.Find("index").gameObject;
        }

        if (indexChild != null) {
            indexChild.SetActive(true);
        }
    }
}
