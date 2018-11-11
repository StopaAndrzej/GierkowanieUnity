using System.Collections;
using UnityEngine;
using System;
using System.Globalization;
using System.Collections.Generic;

public class Clock : MonoBehaviour {


    //connected objects
	[SerializeField]
	GameObject minutesHand;

	[SerializeField]
	GameObject hoursHand;



    public int timeBooster;
    public float playTime=0f;
    public int intPlayTime;

    //time parameters
    public int seconds;
    public int minutes;
    public int hours;
    public int days;



    void Start()
    {
        timeBooster = 1;
        playTime = 300f;
    }



    void Update()
    {
        updateTime();
    }

    private void updateTime()
    {
        playTime += Time.deltaTime * timeBooster;

        intPlayTime = (int)playTime;
        minutes = intPlayTime % 60;
        hours = (intPlayTime / 60) % 24;

        float minutesDegree = (intPlayTime / 60f) * 360f;
        minutesHand.transform.localRotation = Quaternion.Euler(new Vector3(0, minutesDegree, 0));

        float hoursDegree = (intPlayTime / 720f) * 360f;
        hoursHand.transform.localRotation = Quaternion.Euler(new Vector3(0, hoursDegree, 0));

        if (Input.GetKey("space"))
            timeBooster = 5;
        else
            timeBooster = 1;
    }
  
}
