using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityFallDie : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            AJSR_Player_PrimeraPersona_2.THIS.die();
        }
    }
}
