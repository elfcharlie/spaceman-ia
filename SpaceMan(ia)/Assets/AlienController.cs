using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienController : MonoBehaviour
{
    private Animator anim;
    private float currentSpeed = 2f;
    private Transform player;
    private Transform UFO;
    private Vector3 goalPosition;
    private float health = 100;
    private float yPos;
    private float roamTimer;
    private bool isPlayerWithinRadius = false;
    private bool hasHitPlayer = false;
    private float viewRadius = 10;
    public float rotationSpeed = 4f;

    private Quaternion rotGoal;
    private Vector3 directionToGoal;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        UFO = GameObject.FindWithTag("UFO").transform;
        goalPosition = GetNewGoalPos();
    }

    // Update is called once per frame
    void Update()
    {   
        LookForPlayer();
        // Roaming
        if (!hasHitPlayer && !isPlayerWithinRadius && Vector3.Distance(transform.position, goalPosition) >= 2f) { 
            currentSpeed += 0.1f;
            if (currentSpeed > 2.1f) {
            currentSpeed = 2f;
        }
        }
        // Close to roam-position
        else if (!hasHitPlayer && !isPlayerWithinRadius && Vector3.Distance(transform.position, goalPosition) < 2f) {
            currentSpeed -= 0.1f;
        }
        else if (!hasHitPlayer && isPlayerWithinRadius) {
            goalPosition = GetNewGoalPos();
        }
        else if (hasHitPlayer) {
            goalPosition = GetUFOPosition();
            if (currentSpeed < 5f){
                currentSpeed += 0.1f;
            }
            rotationSpeed = 400f; 
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * rotationSpeed);
        }

        // Rotate towards goalposition
        if (!hasHitPlayer) {
            rotationSpeed = 300f;
            directionToGoal = (goalPosition - transform.position).normalized;
            rotGoal = Quaternion.LookRotation(directionToGoal);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, goalPosition, currentSpeed * Time.deltaTime);
        

        // Handling the animations
        if (currentSpeed > 0.1){
            anim.SetBool("isMoving", true);
        }
        else {
            anim.SetBool("isMoving", false);
        }
        if (health <= 0){
            anim.SetTrigger("isDead");
        }
        if (isPlayerWithinRadius && !hasHitPlayer) {
            if (!anim.GetBool("isSeeingPlayer")){
                anim.SetTrigger("isSeeingPlayerTrigger");
                anim.SetBool("isSeeingPlayer", true);
            }
        }
        else {
            anim.SetBool("isSeeingPlayer", false);
        }

    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            O2Controller.O2Remaining -= 10;
        }
        hasHitPlayer = true;
    }

    public Vector3 GetNewGoalPos(){
        // If player within range
        if (isPlayerWithinRadius){
            return player.position;
        }
        // Else roam around
        float xSign = Mathf.Sign(Random.Range(-1,1));
        float ySign = Mathf.Sign(Random.Range(-1,1));
        float newXPos = xSign * Random.Range(transform.position.x + 1.1f, transform.position.x + 20);
        float newZPos = ySign * Random.Range(transform.position.z + 1.1f, transform.position.z + 20);

        // Check terrain boundary
        if (newXPos < -115) newXPos = -115;
        if (newXPos > 115) newXPos = 115;
        if (newZPos < -115) newZPos = -115;
        if (newZPos > 115) newZPos = 115;

        float newYPos = Terrain.activeTerrain.SampleHeight(new Vector3(newXPos, 0, newZPos)) + 0.5f;

        return new Vector3(newXPos, newYPos, newZPos);
    }
    public void LookForPlayer() {
        if (Vector3.Distance(transform.position, player.position) < viewRadius) {
            isPlayerWithinRadius = true;
        }
        else {
            isPlayerWithinRadius = false;
        }
    }
    public Vector3 GetUFOPosition() {
        return UFO.position;
    }
}
