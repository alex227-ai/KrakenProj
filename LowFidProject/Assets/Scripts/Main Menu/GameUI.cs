using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public enum GameState { MainMenu, Paused, Playing, GameOver};
    public GameState currentState;
    public GameObject mainMenuPanel, gameSettingsPanel, gameCreditsPanel, pauseMenuPanel, gameOverPanel, titleText;
    // Start is called before the first frame update
    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            CheckGameState(GameState.MainMenu);
        }
        else
        {
            CheckGameState(GameState.Playing);
        }
    }
    
    public void CheckGameState(GameState newGameState)
    {
        currentState = newGameState;
        switch (currentState)
        {
            case GameState.MainMenu:
                MainMenuSetup();                
                break;
            case GameState.Paused:
                GamePaused();
                Time.timeScale = 0f;
                break;
            case GameState.Playing:
                GameActive();
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                GameOver();
                Time.timeScale = 0f;
                break;
        }
    }

    public void MainMenuSetup()
    {
        mainMenuPanel.SetActive(true);
        gameSettingsPanel.SetActive(false);
        gameCreditsPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }

    public void GameActive()
    {
        mainMenuPanel.SetActive(true);
        gameSettingsPanel.SetActive(false);
        gameCreditsPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }

    public void GamePaused()
    {
        mainMenuPanel.SetActive(false);
        gameSettingsPanel.SetActive(false); 
        gameCreditsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }

    public void GameOver()
    {
        mainMenuPanel.SetActive(false);
        gameSettingsPanel.SetActive(false);
        gameCreditsPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        titleText.SetActive(true);
    }

    public void GameCredits()
    {
        mainMenuPanel.SetActive(false);
        gameSettingsPanel.SetActive(false);
        gameCreditsPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }

    public void GameSettings()
    {
        mainMenuPanel.SetActive(false);
        gameSettingsPanel.SetActive(true);
        gameCreditsPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        titleText.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                CheckGameState(GameState.Paused);
            }else if (currentState == GameState.Paused)
            {
                CheckGameState(GameState.Playing);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        CheckGameState(GameState.Playing);
    }

    public void PauseGame()
    {
        CheckGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        CheckGameState(GameState.Playing);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        CheckGameState(GameState.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}



