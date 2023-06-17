using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RouterManager : MonoBehaviour
{
    public static RouterManager THIS;

    private void Awake() {
        THIS = this;
    }

    // --- DEBUG MODE KEYS ---

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha0)) { // WELCOME
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { // MAIN MENU
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) { // LEVEL 1
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) { // LEVEL 2
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) { // TEST 1
            SceneManager.LoadScene(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)) { // TEST 2
            SceneManager.LoadScene(5);
        }
    }

    // --- WELCOME ---
    public void AJSR_Action_Btn_MainMenu() {
        Debug.Log("[Btn] (A) AJSR_Action_Btn_MainMenu()");
        SceneManager.LoadScene(1);
        GameManager.THIS.SetState(GameStates.MainMenu);
    }

    // --- Play mode ---

        public void AJSR_Action_GotoScene( int sceneNumber ) {
            if (sceneNumber < 0 || sceneNumber > 5) {
                // error   
            }
            SceneManager.LoadScene(sceneNumber);
        }

        // GAME OVER
        public void AJSR_Action_Btn_Game_Over_GotoMainMenu() {
            Debug.Log("[Btn] AJSR_Action_Btn_Game_Over_GotoMainMenu()");
            SceneManager.LoadScene(1);
            GameManager.THIS.SetState(GameStates.MainMenu);
        }
        public void AJSR_Action_Btn_Game_Over_PlayItAgainSam() {
            AJSR_Action_Btn_PLAY();
        }

    // --- MAIN MENU ---
    public void AJSR_Action_Btn_PLAY() {
        Debug.Log("[Btn] (A) AJSR_Action_Btn_Game_Over_PlayItAgainSam()");
        SceneManager.LoadScene(2);
        GameManager.THIS.SetState(GameStates.MainMenu);
    }

}
