using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public int TargetScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter(Collider other) {
       if (other.CompareTag("Player")) {
            //SoundManager.THIS.PlaySound_GetCoin();
            //gameObject.SetActive(false);
            //GameManager.THIS.playerData.coinsCounter += 1;
            RouterManager.THIS.AJSR_Action_GotoScene(TargetScene);
       }
   }


}
