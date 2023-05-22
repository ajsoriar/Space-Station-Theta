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
            transform.GetChild(0).gameObject.SetActive(true);
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //SetState(GameStates.MainMenu);
        SetState(GameStates.Playing);
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
    }

    public void SetState(GameStates newGameState)
    {
        gameState = newGameState;
        switch (gameState) {
            case GameStates.None:
                break;

            case GameStates.MainMenu:
                break;

            case GameStates.Loading:
                break;

            case GameStates.Playing:

                Time.timeScale = 1f;
                break;

            case GameStates.GamePaused:

                Time.timeScale = 0f;
                break;
        }

    }
}

public enum GameStates
{
    None,
    MainMenu,
    Loading,
    Playing,
    GamePaused
}
