using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonClick : MonoBehaviour {
    public string gameButtonAction;

    private void OnMouseDown() {
        Debug.Log("[Btn] Clicked on " + gameObject.name + ", Action: " + gameButtonAction);

        // --- GAME OVER ---

        if (gameButtonAction == "BTN_GO_TO_MAIN_MENU") {
            RouterManager.THIS.AJSR_Action_Btn_Game_Over_GotoMainMenu();
        }

        if (gameButtonAction == "BTN_PLAY_IT_AGAIN_SAM") {
            RouterManager.THIS.AJSR_Action_Btn_Game_Over_PlayItAgainSam();
        }

        // --- MAIN MENU ---

        // BTN_PLAY
        if (gameButtonAction == "BTN_PLAY") {
            SoundManager.THIS.PlaySound_MouseClick();
            RouterManager.THIS.AJSR_Action_Btn_Game_Over_PlayItAgainSam();
        }

        // BTN_HELP / OPTIONS
        if (gameButtonAction == "BTN_OPTIONS") {
            SoundManager.THIS.PlaySound_MouseClick();
            MainMenuManager.THIS.DisableObject("1_Main_Menu");
            MainMenuManager.THIS.DisableObject("3_About");
            MainMenuManager.THIS.EnableObject("2_Options");
        }

        // BTN_ABOUT
        if (gameButtonAction == "BTN_ABOUT") {
            SoundManager.THIS.PlaySound_MouseClick();
            MainMenuManager.THIS.DisableObject("1_Main_Menu");
            MainMenuManager.THIS.DisableObject("2_Options");
            MainMenuManager.THIS.EnableObject("3_About");
        }

        // BTN_BACK
        if (gameButtonAction == "BTN_BACK") {
            SoundManager.THIS.PlaySound_MouseClick();
            MainMenuManager.THIS.DisableObject("2_Options");
            MainMenuManager.THIS.DisableObject("3_About");
            MainMenuManager.THIS.EnableObject("1_Main_Menu");
        }

        if (gameButtonAction == "BTN_EXIT_GAME") {
            SoundManager.THIS.PlaySound_MouseClick();
            Application.Quit();
        }

    }

    private void OnMouseEnter() {
        Debug.Log("[Btn] Mouse entered " + gameObject.name);
        SoundManager.THIS.PlaySound_MouseHover();
    }

    private void OnMouseExit() {
        Debug.Log("[Btn] Mouse exited " + gameObject.name);
    }

} 