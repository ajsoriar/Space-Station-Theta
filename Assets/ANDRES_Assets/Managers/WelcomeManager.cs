using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeManager : MonoBehaviour
{
    public static WelcomeManager THIS;

    private void Awake() {
        THIS = this;
    }

    public void AJSR_Action_Btn_MainMenu() {
        Debug.Log("[Btn] (A) AJSR_Action_Btn_MainMenu()");
        SceneManager.LoadScene(1);
        GameManager.THIS.SetState(GameStates.MainMenu);
    }

    public void AJSR_ByByWelcomeSceneButton() {
        SoundManager.THIS.PlaySound_ClickButton();
    }
}
