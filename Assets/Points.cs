using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public static int collectedPoints = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        collectedPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
         GetComponent<TextMeshProUGUI>().text = "Points: " + collectedPoints;
    }
}
