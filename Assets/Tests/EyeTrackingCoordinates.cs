using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;
using UnityEngine.UI;

public class EyeTrackingCoordinates : MonoBehaviour
{
    private Text textET;

    private void Awake()
    {
        textET = transform.Find("Message").Find("Text").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textET.text = "Initializing";
    }

    // Update is called once per frame  
    void Update()
    {
       textET.text = " Coordinates are:" + TobiiAPI.GetGazePoint().ToString();
    }
}
