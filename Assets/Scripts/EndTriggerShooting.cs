using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTriggerShooting : MonoBehaviour
{
    public GameManager gM;
    public TargetManagement tM;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    bool empty = true;
    void Start()
    {
        timerIsRunning = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining <= 6) { timeText.color = Color.red; timeText.transform.position = new Vector2(Screen.width/2, Screen.height/2); }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            
        }
        else
        {
            timeRemaining = 0; timerIsRunning = false;
            for (int i = 0; i < 6 && tM.instantiatedObject[i] != null; i++){empty = false;}
            if (empty) { gM.Won(); }
            else { gM.EndGame(); }
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
