using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager THIS;
    public GameStates gameState;
    public PlayerData playerData;

    private void Awake()
    {
        if (THIS == null) {// SINGLETON
            THIS = this;
            transform.SetParent(null);
            //transform.GetChild(0).gameObject.SetActive(true);
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //SetState(GameStates.MainMenu);
        //SetState(GameStates.Playing);
        ResetPlayerData();
    }

    void ResetPlayerData()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (gameState == GameStates.Playing)
            {
                SetState(GameStates.GamePaused);
            }
            else if (gameState == GameStates.GamePaused)
            {
                SetState(GameStates.Playing);
            }
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            if (gameState == GameStates.Playing) {
                GameManager.THIS.playerData.health = 0;
                GameManager.THIS.playerData.oxygen = 0;
                SetState(GameStates.Die);
            } 
        }
    }

    public void SetState(GameStates newGameState)
    {
        gameState = newGameState;
        switch (gameState) {
            //case GameStates.None:
            //    break;

            case GameStates.WelcomeScreen:
            //    //MusicManager.THIS.Play_WelcomeScreenMusic();
                break;

            case GameStates.MainMenu:
                //MusicManager.THIS.Play_MainMenuMusic();
                break;

            //case GameStates.Loading:
            //    break;

            case GameStates.Playing:
                AJSR_Player_PrimeraPersona_2.THIS.enablePauseLayer(false);
                //MusicManager.THIS.Play_GamePlayMusic();
                Time.timeScale = 1f;
                break;

            case GameStates.GamePaused:
                //MusicManager.THIS.Play_GamePlayMusic();
                AJSR_Player_PrimeraPersona_2.THIS.enablePauseLayer(true);
                Time.timeScale = 0f;
                break;

            case GameStates.Die:
                //MusicManager.THIS.Play_WelcomeScreenMusic();
                break;

            case GameStates.Win:
                //MusicManager.THIS.Play_WelcomeScreenMusic();
                break;
        }

    }

    public GameStates getGameState() {
        return gameState;
    }
}

public enum GameStates
{
    //None,
    WelcomeScreen,
    MainMenu,
    //Loading,
    Playing,
    GamePaused,
    Die,
    Win
}
