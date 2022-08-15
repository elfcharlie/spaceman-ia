using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockInstantiationTutorial : MonoBehaviour
{
    public GameObject rock;
    public static bool hasRockFallen;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    private int rockNumber = 1;

    void Start(){
        hasRockFallen = false;
    }
    
    public void InstantiateFallingRock(int rockAmount){
        for (int i = 0; i < rockAmount; i++) 
        {
            Transform transform = GameObject.Find("Falling Rocks").transform;
            int xPos = Random.Range(xMin, xMax);
            int zPos = Random.Range(zMin, zMax);
            Vector3 position = new Vector3(xPos, 0, zPos);
            position.y = 40;// Terrain.activeTerrain.SampleHeight(position) + 50; 
            var currentInstance = Instantiate(rock, position, Quaternion.identity, transform);
            currentInstance.name = ("Falling Rock" + rockNumber);
            rockNumber += 1;
        }
    }
}
