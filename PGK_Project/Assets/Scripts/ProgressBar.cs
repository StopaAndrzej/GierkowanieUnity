using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    public bool isComplete = false;
    public bool inProgress = false;
    public double timeToFillBar = 10;
    public int iterations = 100;
    float barScaleFactor = 0;
    public GameObject bar;
    public GameObject barHolder;
    public GameObject barRed;
    double timer = 0;
    float maxScale = 0;
    private void Start()
    {
        show(true);
        maxScale = bar.transform.localScale.x / barRed.transform.localScale.x;
    }

    private void Update()
    {
        if (barScaleFactor > maxScale)
        {
            isComplete = true;
            show(false);
        }
        if (!isComplete && inProgress)
        {
            show(true);
            timer += Time.deltaTime;

            if (timer > timeToFillBar / iterations)
            {
                barScaleFactor += maxScale / iterations;
                Transform t = barHolder.transform;
                barHolder.transform.localScale = new Vector3(barScaleFactor,
                                                             t.transform.localScale.y,
                                                             t.transform.localScale.z);
                timer = 0;
            }
        }
    }
    public void startProgress()
    {
        inProgress = true;
        show(true);
    }
    public void show(bool show)
    {
        if (show)
        {
            bar.GetComponent<Renderer>().enabled = true;
            barRed.GetComponent<Renderer>().enabled = true;
        } else
        {
            bar.GetComponent<Renderer>().enabled = false;
            barRed.GetComponent<Renderer>().enabled = false;
        }
    }
    public void reset()
    {
        isComplete = false;
        barScaleFactor = 0;
    }
}
