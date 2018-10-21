using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainTimeTable : MonoBehaviour {

    private Text clockText;
    public int hour;
    public int minute;
    private string display;
    public int offset;


    // Use this for initialization
    void Start()
    {
        setTime();
        clockText.text = display;
    }

    // Update is called once per frame
    void Update()
    {
        
        //System.DateTime time = System.DateTime.Now;
        //clockText.text = time.ToString("hh:mm");
    }

    void setTime()
    {
        clockText = GetComponent<Text>();
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute+offset;
        if (minute >= 60)
        {
            hour++;
            minute = minute % 60;
        }
    
        if (hour < 10)
        {
            display = "0";
        }
        display += hour.ToString() + ":";
        if (minute < 10)
        {
            display += "0";
        }
        display += minute.ToString();
    }
}
