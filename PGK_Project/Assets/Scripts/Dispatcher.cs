using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dispatcher : MonoBehaviour {

    // Use this for initialization
    public int actuallNumberWorkers;
    public float timer;
    public bool readyToDepartureTruck;
    public bool stopTimer;
    public bool procedure;
    public bool spawnOnlyonTime;

    public Animator anim;

    void Start () {
        actuallNumberWorkers = 0;
        timer = 0.0f;
        readyToDepartureTruck = false;
        stopTimer = false;
        procedure = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (actuallNumberWorkers >= 3)
        //{
        //    Work();
        //}
        //else 
        //if (actuallNumberWorkers < 3)
        //{
        //    timer = 0.0f;
        //}
        if (readyToDepartureTruck)
        {
            DepartureTruck();
        }
        if (procedure)
        {
            Rest(5.0f);
        }
	}

    public void Work()
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
            timer = 0;
            stopTimer = true;
            spawnOnlyonTime = true;
            procedure = true;
    }

    private void Rest(float rest)
    {
        
        timer += Time.deltaTime;
        if (timer >= rest)
        {
            Debug.Log("SPAWN CIEZAROWE!");
            if (spawnOnlyonTime)
            {
                GameObject.Find("TruckSpawner").GetComponent<SpawnTruck>().Spawn();
                spawnOnlyonTime = false;
            }
           
            if(timer>= 2 * rest)
            {
                Debug.Log("ZAMKNIJ WROTA!");
                anim.Play("DispatcherClose");
                timer = 0.0f;
                stopTimer = false;
                procedure = false;
            }
            
            
        }
    }


}
