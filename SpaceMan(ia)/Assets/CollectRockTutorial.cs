using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectRockTutorial : MonoBehaviour
{
    Collider rockCollider;
    private Points pointsAmount;
    private GameObject rockInstantiator;
    public GameObject tutorialTextObject;
    public GameObject tutorialMenuUI;
    public GameObject fallingRock;
    public AudioClip clip;
    AudioSource audioSource;
    
    void Start()
    {
        rockCollider = GetComponent<Collider>();
        GameObject pointsObject = GameObject.Find("PointsText");
        pointsAmount = pointsObject.GetComponent<Points>();
        audioSource = GetComponent<AudioSource>();
        rockInstantiator = GameObject.Find("Glowing Rocks");
    }

    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Points.collectedPoints += 1;
            GetComponent<AudioSource>().PlayOneShot(clip);
            GetComponent<MeshRenderer>().enabled = false;
            this.enabled = false;
            StartCoroutine (holdBeforeDestroy());
            O2Controller.O2Remaining += 4;
        }
        tutorialTextObject.GetComponent<TextMeshProUGUI>().SetText("You just picked up a glowing rock and got 1 point! Check the top left corner for your current score!<br>You also got a boost in your O2 level, check your current level at the top.");
        tutorialMenuUI.SetActive(true);
        Time.timeScale = 0f;
        fallingRock.SetActive(true);
    }
    IEnumerator holdBeforeDestroy(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
