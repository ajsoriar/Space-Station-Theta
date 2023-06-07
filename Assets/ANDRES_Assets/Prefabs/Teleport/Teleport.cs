using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public bool OutOfOrder = false;
    public bool GameWin = false;
    public int TargetScene;

    // Start is called before the first frame update
    void Start()
    {
        if (OutOfOrder) {

            // Disable green lights
            GameObject objt = transform.Find("GreenLights").gameObject;
            objt.SetActive(false);

            // Enable red lights
            objt = transform.Find("RedLights").gameObject;
            objt.SetActive(true);
        } 

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



            if (OutOfOrder) {

                // Just do nothing!

            } else if(GameWin) {

                AJSR_Player_PrimeraPersona_2.THIS.win();

            } else { 
            
                RouterManager.THIS.AJSR_Action_GotoScene(TargetScene);
            }

            
       }
   }


}
