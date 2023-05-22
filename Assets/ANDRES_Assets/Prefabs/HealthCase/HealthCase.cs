using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCase : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.THIS.PlaySound_GetCoin();
            gameObject.SetActive(false);
            GameManager.THIS.playerData.healthCaseCount += 1;

            // Calculate and update the damage bar
        }
    }
}
