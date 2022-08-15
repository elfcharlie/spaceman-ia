using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
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
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material;
        audioSource = GetComponent<AudioSource>();
        color =  material.color;
        rockInstantiator = GameObject.Find("Falling Rocks");
        rockTimer = Random.Range(5,12);
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a <= 0f){
            rockInstantiator.GetComponent<FallingRockInstantiation>().InstantiateFallingRock(1);
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
        rockTimer -= Time.deltaTime;
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

