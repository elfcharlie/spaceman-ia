using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RocketTutorial : MonoBehaviour
{
    private Points pointsAmount;
    public GameObject finishMenuUI;
    public GameObject newHighScoreMenuUI;
    public GameObject newHighScoreMenuUIText;
    
    public GameObject pointsText;
    
    private int courseHighScore;
    // Start is called before the first frame update
    void Start()
    {
        pointsText.SetActive(true);
        finishMenuUI.SetActive(false);
        //LoadCourseHighScore();
        
    }
    void OnTriggerEnter (Collider collision)
    {
            finishMenuUI.transform.Find("ScoreText").gameObject.GetComponent<TextMeshProUGUI>().text =
                "Your score<br>was: " + Points.collectedPoints.ToString();
            newHighScoreMenuUI.transform.Find("ScoreText").gameObject.GetComponent<TextMeshProUGUI>().text =
                "Your score<br>was: " + Points.collectedPoints.ToString();
        /*if (collision.gameObject.tag == "Player" && Points.collectedPoints > HighScoreManager.courseHighScores[0]) 
        {   
            Debug.Log("ROCKET");
            PauseMenu.isGameFinished = true;
            pointsText.SetActive(false);
            newHighScoreMenuUI.SetActive(true);
            newHighScoreMenuUIText.GetComponent<TextMeshProUGUI>().text = "New High<br>Score!";
            Time.timeScale = 0f;
            
        } else if (collision.gameObject.tag == "Player" && Points.collectedPoints > HighScoreManager.courseHighScores[4]){
            Debug.Log("ROCKET");
            PauseMenu.isGameFinished = true;
            pointsText.SetActive(false);
            newHighScoreMenuUI.SetActive(true);
            newHighScoreMenuUIText.GetComponent<TextMeshProUGUI>().text = "You got into top 5!";
            Time.timeScale = 0f;

        } else */if (collision.gameObject.tag == "Player"){
            Debug.Log("ROCKET");
            PauseMenu.isGameFinished = true;
            pointsText.SetActive(false);
            finishMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
    void LoadCourseHighScore(){
        if (SceneManager.GetActiveScene().buildIndex == 1){
            courseHighScore = PlayerPrefs.GetInt("marsHighScore", 0);
        } else if (SceneManager.GetActiveScene().buildIndex == 2){
            courseHighScore = PlayerPrefs.GetInt("moonHighScore", 0);
        }
    }
}
