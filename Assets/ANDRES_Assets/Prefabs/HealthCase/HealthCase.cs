using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCase : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SoundManager.THIS.PlaySound_GetCoin(); 
            GameManager.THIS.playerData.healthCaseCount += 1;
            GameManager.THIS.playerData.health = 100;
            PercentageBar.THIS.refreshBar();
            gameObject.SetActive(false);
        }
    }
}