using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FallingRockTutorial : MonoBehaviour
{
    GameObject tutorialMenuUI;
    GameObject tutorialTextObject;
    Rigidbody rigidBody;
    Material material;
    private float upForce = 500f;
    private bool hasHitPlayer = false;
    Color color;
    private GameObject rockInstantiator;
    private float rockTimer;
    private float maxSpeed = 10f;
    public AudioClip clip;
    AudioSource audioSource;
    private float tutorialMenuTimer = 7f;
    private bool isRocketShown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
        color =  material.color;
        tutorialMenuUI = GameObject.Find("TutorialMenu");
        tutorialTextObject = tutorialMenuUI.transform.Find("TutorialText").gameObject;
        rockInstantiator = GameObject.Find("Falling Rocks");
        rockTimer = 12;
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a <= 0f){
            Destroy(gameObject);
        }
        else if (rockTimer <= 0 || hasHitPlayer){
            color.a -= 0.2f * Time.deltaTime;
            material.color = color;
        }

        if(rigidBody.velocity.magnitude > maxSpeed)
         {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
         }
         
         if(tutorialMenuTimer > 0f && tutorialMenuTimer <= 4f && !FallingRockInstantiationTutorial.hasRockFallen){
            tutorialTextObject.GetComponent<TextMeshProUGUI>().SetText("Watch out for meteorites falling from the sky!<br>You will lose some O2 if you get hit, even when they are on the ground!");
            tutorialMenuUI.SetActive(true);
            Time.timeScale = 0f;
            FallingRockInstantiationTutorial.hasRockFallen = true;
         } else if (tutorialMenuTimer <= 0f && !isRocketShown){
            tutorialTextObject.GetComponent<TextMeshProUGUI>().SetText("Get to your space-rocket before your O2 runs out to secure your score and finish!");
            tutorialMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isRocketShown = true;
         }
        rockTimer -= Time.deltaTime;
        tutorialMenuTimer -= Time.deltaTime;
    }

     void OnCollisionEnter (Collision collision)
     {
         if (collision.gameObject.tag == "Terrain" && upForce > 1f) 
         {
            if (upForce == 500f){
            GetComponent<AudioSource>().PlayOneShot(clip);
            }
            rigidBody.AddForce(transform.up * upForce);
            upForce -= 50f;
         }
         else if (collision.gameObject.tag == "Player" && hasHitPlayer == false){
            O2Controller.O2Remaining -= 10f;
            rigidBody.AddForce(transform.up * upForce);
            upForce -= 50f;
            hasHitPlayer = true;
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        maxSpeed = 5f;
     }   
}

