using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayActualTimeOnText : MonoBehaviour {

    public TextMeshProUGUI clockText;
    public float timeInMinutes = 300.0f;
    public int intTime;
    private string display;

    private int minutes;
    private int hours;


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        setTime();
        clockText.text = display;
    }

    void setTime()
    {
        timeInMinutes += Time.deltaTime;
        intTime = (int)timeInMinutes;
        minutes = intTime % 60;
        hours = (intTime / 60) % 24;

        display = "";
        if (hours < 10)
        {
            display = "0";
        }
        display += hours.ToString() + ":";
        if (minutes < 10)
        {
            display += "0";
        }
        display += minutes.ToString();
    }
}
