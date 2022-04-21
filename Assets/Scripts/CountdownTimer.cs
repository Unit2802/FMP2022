using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public string levelToLoad;

    float currentTime = 0f;
    float StartingTime = 60f;
   
    [SerializeField] Text countdownText;

    private void Start()
    {
        currentTime = StartingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        if (currentTime <= 0)
        {
            Application.LoadLevel(1);
        }
    }
    
}

