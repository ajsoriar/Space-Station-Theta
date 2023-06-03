using UnityEngine;

public class DamageLava : MonoBehaviour {
    private bool isPlayerInside = false;
    private float timer = 0f;
    public float damageInterval = 0.5f; // Time interval in seconds between damage ticks

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the lava
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the lava
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }

    private void Update() { 
    //private void FixedUpdate() {
        // Check if the player is inside the lava
        if (isPlayerInside) {
            // Increment the timer
            timer += Time.deltaTime;

            // Check if the damage interval has passed
            if (timer >= damageInterval)
            {
                // Decrease the player's health by 1
                //GameManager.THIS.playerData.health -= 10;
                AJSR_Player_PrimeraPersona_2.THIS.decreaseHeath(5);
                Debug.Log("[Health] Player's Health: " + GameManager.THIS.playerData.health);

                // Reset the timer
                timer = 0f;
            }
        }
    }
}
