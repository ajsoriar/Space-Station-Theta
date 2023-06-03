using System.Collections;
using UnityEngine;

public class ShowRayOfLight : MonoBehaviour {
    public float visibilityDurationLimit = 1f; // Duration in seconds to show the "index" child
    public float checkInterval = 2.5f; // Interval in seconds to check if the player is near the object
    public float playerDistanceThreshold = 5f; // Distance threshold for the player to be considered near the object
    public float damageThreshold = 3.5f;
    public int damageGenerated = 10;

    private GameObject indexChild;
    private float timer = 0f;
    private bool isPlayerNear = false;
    float distance;
    GameObject player;

    private void Start() {
        indexChild = transform.Find("index").gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        HideRay();
        InvokeRepeating("tryShowDangerousBlueRay", 0f, checkInterval);
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        refreshPlayerDistance();
    }

    private void tryShowDangerousBlueRay() {

        if (isPlayerNear) { //} && timer < visibilityDurationLimit) {
            ShowRay();
            if (distance <= damageThreshold) {
                //HideRay();
                // cause damage
                AJSR_Player_PrimeraPersona_2.THIS.decreaseHeath(damageGenerated);

                // damage sound here 

            }

            StartCoroutine(ExecuteAfterDelay(0.6f));
        } 



    }

    private IEnumerator ExecuteAfterDelay(float delay) {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Call the function you want to execute after the delay
        HideRay();
    }

    private void refreshPlayerDistance() {
        distance = Vector3.Distance(transform.position, player.transform.position);
        isPlayerNear = (distance <= playerDistanceThreshold);
    }

    private void HideRay() { 
        indexChild.SetActive(false);
    }

    private void ShowRay() {

        indexChild.SetActive(true);

    }
}
