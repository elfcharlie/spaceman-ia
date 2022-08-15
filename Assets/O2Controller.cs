using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Controller : MonoBehaviour
{
    public Image O2RemainingImage;
    public float startingO2;
    public GameObject deadMenuUI;
    public static float O2Remaining;
    
    void Start()
    {
        Time.timeScale = 1f;
        O2Remaining = startingO2;
        deadMenuUI.SetActive(false);
    }

    void Update()
    {
        if (O2Remaining > startingO2){
            O2Remaining = startingO2;
        } else if (O2Remaining > 0){
            O2Remaining -= Time.deltaTime;
            O2RemainingImage.fillAmount = O2Remaining / startingO2;
        } else {
            O2RemainingImage.fillAmount = 0;
            Dead();
        }
    }
    public void Dead() {
        deadMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
