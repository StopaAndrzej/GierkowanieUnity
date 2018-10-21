using System.Collections;
using UnityEngine;
using System;
using System.Globalization;
using System.Collections.Generic;

public class Clock : MonoBehaviour {

	[SerializeField]
	GameObject secondsHand;

	[SerializeField]
	GameObject minutesHand;

	[SerializeField]
	GameObject hoursHand;

    public int hour = 1;
    public int minute = 15;
    public int second = 0;

    public DateTime currentTime = new DateTime(1, 1, 1, 2, 15, 0);

    void Start()
    {
       

    }     
        void Update () {
		

		float secondsDegree = (currentTime.Second / 60f) * 360f;
		secondsHand.transform.localRotation = Quaternion.Euler(new Vector3 (0, secondsDegree, 0));

		float minutesDegree = (currentTime.Minute / 60f) * 360f;
		minutesHand.transform.localRotation = Quaternion.Euler(new Vector3 (0, minutesDegree, 0));

		float hoursDegree = (currentTime.Hour / 12f) * 360f;
		hoursHand.transform.localRotation = Quaternion.Euler(new Vector3 (0, hoursDegree, 0));
	}
}
