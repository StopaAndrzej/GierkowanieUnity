using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispatcher : MonoBehaviour {

    // Use this for initialization
    public int actuallNumberWorkers;
    public float timer;
    public bool readyToDepartureTruck;
    public bool stopTimer;

    public Animator anim;

    void Start () {
        actuallNumberWorkers = 0;
        timer = 0.0f;
        readyToDepartureTruck = false;
        stopTimer = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (actuallNumberWorkers >= 3)
        {
            Work();
        }
        else if (actuallNumberWorkers < 3)
        {
            timer = 0.0f;
        }
        if (readyToDepartureTruck)
        {
            DepartureTruck();
        }
	}

    private void Work()
    {
        if(!stopTimer)
        {
            timer += Time.deltaTime;
            if (timer > 10.0f)
            {
                readyToDepartureTruck = true;
            }
        }
            
    }

    private void DepartureTruck()
    {
            print("Ciezarowka wyjechala z dyspozytorni!");
            anim.Play("DispatcherOpen");
            readyToDepartureTruck = false;
            timer = 0.0f;
            stopTimer = true;
            Rest(5.0f);
    }

    private void Rest(float rest)
    {
        timer += Time.deltaTime;
        if (timer >= rest)
        {
            timer = 0.0f;
            stopTimer = false;
        }
    }


}
