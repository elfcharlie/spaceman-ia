using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInstantiation : MonoBehaviour
{
    public GameObject alien;
    private Transform UFO;
    public int amountOfAlien = 1;
    private int alienNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        UFO = GameObject.FindWithTag("UFO").transform;
        InstantiateAlien(amountOfAlien);
    }

    public void InstantiateAlien(int alienAmount){
        for (int i = 0; i < alienAmount; i++) 
        {
            Transform transform = GameObject.Find("Aliens").transform;
            // int xPos = Random.Range(xMin, xMax);
            // int zPos = Random.Range(zMin, zMax);
            Vector3 position = UFO.position; 
            var currentInstance = Instantiate(alien, position, Quaternion.identity, transform);
            currentInstance.name = ("Alien" + alienNumber);
            alienNumber += 1;
        }
    }
}
