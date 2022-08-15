using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRockInstantiation : MonoBehaviour
{
    public GameObject rock;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    private int rockNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateCollectableRock(20);
    }
    public void InstantiateCollectableRock(int rockAmount){
        for (int i = 0; i < rockAmount; i++) 
        {
            Transform transform = GameObject.Find("Glowing Rocks").transform;
            int xPos = Random.Range(xMin, xMax);
            int zPos = Random.Range(zMin, zMax);
            Vector3 position = new Vector3(xPos, 0, zPos);
            position.y = Terrain.activeTerrain.SampleHeight(position) + 1; 
            var currentInstance = Instantiate(rock, position, Quaternion.identity, transform);
            currentInstance.name = ("Glowing Rock" + rockNumber);
            rockNumber += 1;
        }
    }
}
