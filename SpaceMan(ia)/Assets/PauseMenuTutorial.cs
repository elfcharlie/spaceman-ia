using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuTutorial : MonoBehaviour
{
    public static bool isGamePaused = false;
    public static bool isGameFinished = false;
    public GameObject pauseMenuUI;
    public GameObject finishMenuUI;
    public GameObject newHighScoreMenuUI;
    public GameObject tutorialMenuUI;
    public GameObject tutorialTextObject;
    public GameObject nameInput;
    public GameObject HighScoreManagerObject;
    private float tutorialMenuTimer = 2;
    private bool isTutorialShown = false;

    void Start()
    {
        isGamePaused = false;
        isGameFinished = false;
        pauseMenuUI.SetActive(false);
        finishMenuUI.SetActive(false);
        newHighScoreMenuUI.SetActive(false);
        tutorialMenuUI.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isGameFinished && tutorialMenuUI.activeSelf == false){
            if (isGamePaused){
                Resume();
            } else {
                Pause();
            }
        }
        if (tutorialMenuTimer > 0){
            tutorialMenuTimer -= Time.deltaTime;
        } else if(tutorialMenuTimer <= 0 && !isTutorialShown){
            isTutorialShown = true;
            tutorialTextObject.GetComponent<TextMeshProUGUI>().SetText("Use W,A,S,D to move and the mouse to look around.<br>See that blue glowing rock? Try running into it!");
            tutorialMenuUI.SetActive(true);
            Time.timeScale = 0f;
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
    public void ResumeTutorial() {
        tutorialMenuUI.SetActive(false);
        Time.timeScale = 1f;
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
        Points.collectedPoints = 0;
    }
    public void goToMars(){
        Time.timeScale = 1f;
        isGameFinished = false;
        SceneManager.LoadScene(1);
        Points.collectedPoints = 0;
    }
    public void ConfirmHighScore(){
        //string highScoreName = nameInput.GetComponent<TMP_InputField>().text;
        //PlayerPrefs.SetString("HighScoreName" + SceneManager.GetActiveScene().buildIndex.ToString(), highScoreName);
        newHighScoreMenuUI.SetActive(false);
        finishMenuUI.SetActive(true);
        HighScoreManagerObject.GetComponent<HighScoreManager>().SaveHighScore();

    }
}
