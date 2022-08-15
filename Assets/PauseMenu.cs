using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public static bool isGameFinished = false;
    public GameObject pauseMenuUI;
    public GameObject finishMenuUI;
    public GameObject newHighScoreMenuUI;
    public GameObject nameInput;
    public GameObject HighScoreManagerObject;

    void Start()
    {
        isGamePaused = false;
        isGameFinished = false;
        pauseMenuUI.SetActive(false);
        finishMenuUI.SetActive(false);
        newHighScoreMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isGameFinished){
            if (isGamePaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void RestartLevel(){
        Time.timeScale = 1f;
        isGameFinished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitToMainMenu() {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isGameFinished = false;
        SceneManager.LoadScene(0);
    }
    public void goToMoon(){
        Time.timeScale = 1f;
        isGameFinished = false;
        SceneManager.LoadScene(2);
    }
    public void goToMars(){
        Time.timeScale = 1f;
        isGameFinished = false;
        SceneManager.LoadScene(1);
    }
    public void ConfirmHighScore(){
        newHighScoreMenuUI.SetActive(false);
        HighScoreManagerObject.GetComponent<HighScoreManager>().SaveHighScore();
        finishMenuUI.SetActive(true);
    }
}
