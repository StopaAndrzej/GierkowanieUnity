using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimeOnText : MonoBehaviour {


    private Text clockText;
    public int hour;
    public int minute;
    private string display;
  

	// Use this for initialization
	void Start () {
        clockText = GetComponent<Text>();
        hour = UnityEngine.Random.Range(0, 23);
        minute = UnityEngine.Random.Range(0, 59);
        if (hour < 10)
        {
            display = "0";
        }
        display += hour.ToString()+":";
        if(minute<10)
        {
            display += "0";
        }
        display += minute.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        clockText.text = display;
        //System.DateTime time = System.DateTime.Now;
        //clockText.text = time.ToString("hh:mm");
	}
}
