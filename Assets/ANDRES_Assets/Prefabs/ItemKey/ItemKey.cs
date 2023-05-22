using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.THIS.PlaySound_GetCoin();
            gameObject.SetActive(false);
            GameManager.THIS.playerData.keysCounter += 1;
        }
    }
}
