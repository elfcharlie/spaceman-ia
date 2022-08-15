using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{

    private int currentScore;
    private int currentScene;
    public static int[] courseHighScores;
    public static int highScoreLength = 5;
    public static int[] marsHighScores;
    public static int[] moonHighScores;
    private int[] setScoreTo;

    void Start(){
        
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            currentScene = 1;
        } else if (SceneManager.GetActiveScene().buildIndex == 2){
            currentScene = 2;
        }
        LoadAllHighScores();
        LoadCourseHighScore();
    }

    /*void Update(){
        if (PauseMenu.isGameFinished && Time.timeScale != 0f){
            //SaveHighScore();
        }
    }*/

    public void LoadCourseHighScore(){
        if (currentScene == 1){
            courseHighScores = marsHighScores;
        } else if (currentScene == 2){
            courseHighScores = moonHighScores;
        }
    }

    /*public void SaveHighScore2() {
        LoadCourseHighScore();
        currentScore = Points.collectedPoints;
        if (courseHighScore < currentScore){
            PlayerPrefs.SetInt("HighScore" + currentScene.ToString(), currentScore);
            //marsHighScore = currentScore;
            Debug.Log("YOU GOT A NEW HIGH SCORE");
            // "YOU GOT A NEW HIGH SCORE" ON SCREEN
        } else {
            Debug.Log("YOU DID NOT GET A NEW HIGH SCORE");
            // "YOU DIDNT GET A NEW HIGH SCORE"
        }
        Time.timeScale = 0f;

    }*/
    public void LoadAllHighScores() {
        marsHighScores = new int[5];
        moonHighScores = new int[5];
        for (int i = 0; i < highScoreLength; i++){
            
            marsHighScores[i] = PlayerPrefs.GetInt("HighScore1" + i.ToString());
            
            moonHighScores[i] = PlayerPrefs.GetInt("HighScore2" + i.ToString());
        }

        Array.Sort(marsHighScores);
        Array.Reverse(marsHighScores);
        Array.Sort(moonHighScores);
        Array.Reverse(moonHighScores);
    }

    public void SaveHighScore(){
        currentScore = Points.collectedPoints;
        LoadAllHighScores();

        if (currentScene == 1) {
            setScoreTo = marsHighScores;
        } else if (currentScene == 2){
            setScoreTo = moonHighScores;
        }
        
        if (currentScore > setScoreTo[4]){
            
        }
        for (int i = 0; i < highScoreLength; i++){
            {
                
                PlayerPrefs.SetInt("HighScore" + currentScene.ToString() + i.ToString(), setScoreTo[i]);
            }
                PlayerPrefs.SetInt("HighScore" + currentScene.ToString() + 4, currentScore);
        }
        Time.timeScale = 0f;
    }
}
