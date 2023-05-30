using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("[Btn] (B) AJSR_Action_Btn_MainMenu()");
            WelcomeManager.THIS.AJSR_ByByWelcomeSceneButton();
            WelcomeManager.THIS.AJSR_Action_Btn_MainMenu();
        }
    }

}
