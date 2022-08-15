using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject HighScoreMenuUI;
    public GameObject LevelSelectMenuUI;
    public GameObject MainMenuUI;
    public GameObject marsHighScore;
    public GameObject moonHighScore;
    public GameObject HighScoreManagerObject;
    private string marsHighScoreString;
    private string moonHighScoreString;

    public void Start() {
        MainMenuUI.SetActive(true);
        LevelSelectMenuUI.SetActive(false);
        HighScoreMenuUI.SetActive(false);
    }
    public void StartGame (){
        LevelSelectMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }
    public void ShowHighScore (){
        HighScoreMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
        HighScoreManagerObject.GetComponent<HighScoreManager>().LoadAllHighScores();
        PrintAllHighScores();
    }
    public void PrintAllHighScores(){
        marsHighScoreString = "";
        moonHighScoreString = "";
        for (int i = 0; i < HighScoreManager.highScoreLength; i++){
            marsHighScoreString = marsHighScoreString + HighScoreManager.marsHighScores[i].ToString() + "<br>";
            moonHighScoreString = moonHighScoreString + HighScoreManager.moonHighScores[i].ToString() + "<br>"; 
        }
        marsHighScore.GetComponent<TextMeshProUGUI>().text = marsHighScoreString;
        moonHighScore.GetComponent<TextMeshProUGUI>().text = moonHighScoreString;
    }
    public void HideHighScore(){
        HighScoreMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
    public void ResetHighScore(){
        PlayerPrefs.DeleteAll();
        marsHighScoreString = "";
        moonHighScoreString = "";
        ShowHighScore();
    }
    public void goToTutorial(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
    public void goToMars(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void goToMoon(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void goBackFromLevelSelect(){
        MainMenuUI.SetActive(true);
        LevelSelectMenuUI.SetActive(false);
    }
    public void ExitGame () {
        Application.Quit();
    }
}
