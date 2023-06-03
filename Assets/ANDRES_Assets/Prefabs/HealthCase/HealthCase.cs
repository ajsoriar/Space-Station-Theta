using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCase : MonoBehaviour
{
    public int healthLevel = 50;

    void Start() {
        healthLevel = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.THIS.PlaySound_GetCoin();
            gameObject.SetActive(false);
            GameManager.THIS.playerData.healthCaseCount += 1;

            // Calculate and update the damage bar
            increasePlayerHealth(healthLevel);
        }
    }

    public void increasePlayerHealth(int healthToAdd) {
        Debug.Log("[Steps|Bar] increasePlayerHealth() healthToAdd: " + healthToAdd);
        if (GameManager.THIS.playerData.health + healthToAdd >= 100) {
            GameManager.THIS.playerData.health = 100;
        } else {
            GameManager.THIS.playerData.health += healthToAdd;
        }
        PercentageBar.THIS.refreshBar();
    }

}