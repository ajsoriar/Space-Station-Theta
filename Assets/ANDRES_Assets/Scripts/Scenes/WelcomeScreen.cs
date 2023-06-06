using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour {

    void Start() {
        GameManager.THIS.SetState(GameStates.WelcomeScreen);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) goNextScreen();
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) goNextScreen();
    }

    private void goNextScreen() {
        SoundManager.THIS.PlaySound_ClickButton();
        //RouterManager.THIS.AJSR_ByByWelcomeSceneButton();
        RouterManager.THIS.AJSR_Action_Btn_MainMenu();        
    }
}
