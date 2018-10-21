using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayActualTimeOnText : MonoBehaviour {

    private Text clockText;
    public int hour;
    public int minute;
    private string display;


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        setTime();
        clockText.text = display;
        //System.DateTime time = System.DateTime.Now;
        //clockText.text = time.ToString("hh:mm");
    }

    void setTime()
    {
        clockText = GetComponent<Text>();
        hour = System.DateTime.Now.Minute;
        minute = System.DateTime.Now.Second;

        hour = hour % 24;

        display = "";
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
