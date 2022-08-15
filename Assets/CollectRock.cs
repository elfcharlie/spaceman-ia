using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRock : MonoBehaviour
{
    Collider rockCollider;
    private GameObject rockInstantiator;
    public AudioClip clip;
    AudioSource audioSource;
    
    void Start()
    {
        rockCollider = GetComponent<Collider>();
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
             rockInstantiator.GetComponent<CollectableRockInstantiation>().InstantiateCollectableRock(1);
             O2Controller.O2Remaining += 4;
         }
     }
     IEnumerator holdBeforeDestroy(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
     }
}
