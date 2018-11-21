using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTruck : MonoBehaviour {

    public float moveSpeed;
    public float timer = 0;
    public GameObject car;
    public GameObject bar;
    public GameObject barRed;
    public GameObject barRedHolder;
    public GameObject savedBarrier;
    public float scaleFactor = 0;
    public bool insideBarierTrigger = false;
    public bool stoppedAtLights = false;

    private TrafficLight trafficLights = null;
    // Use this for initialization
    void Start()
    {
        bar.GetComponent<Renderer>().enabled = false;
        barRed.GetComponent<Renderer>().enabled = false;
        timer = 0;
        scaleFactor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (insideBarierTrigger == true && savedBarrier.GetComponent<BoxCollider>().enabled == false)
        {
            car.GetComponent<TruckMovement>().moveSpeed = moveSpeed;
            timer = 0.0f;
            bar.GetComponent<Renderer>().enabled = false;
            barRed.GetComponent<Renderer>().enabled = false;
            //scaleFactor = 0.0f;
        }
        if (stoppedAtLights && trafficLights.isGreen)
        {
            stoppedAtLights = false;
            car.GetComponent<TruckMovement>().moveSpeed = moveSpeed;
            timer = 0.0f;
            bar.GetComponent<Renderer>().enabled = false;
            barRed.GetComponent<Renderer>().enabled = false;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " collided with " + other.name);

        GameObject go = GameObject.Find("BarrierTriggerCube");
        //BarrierTrigger b = go.GetComponent<BarrierTrigger>();
        if (other.transform.tag == "barrier")
        {
            moveSpeed = car.GetComponent<TruckMovement>().moveSpeed;
            car.GetComponent<TruckMovement>().moveSpeed = 0;
            savedBarrier = other.gameObject;
            insideBarierTrigger = true;
        }

        else if (other.transform.tag == "Train")
        {
            GameObject.Find("MainCamera").GetComponent<CameraController>().gameOver();
        }
        else if (other.transform.tag == "car")
        {
            moveSpeed = car.GetComponent<TruckMovement>().moveSpeed;
            car.GetComponent<TruckMovement>().moveSpeed = 0;
        }
        else if (other.transform.tag == "TrafficLightStop")
        {
            trafficLights = other.GetComponent<TrafficStop>().trafficLights;
            if (trafficLights.isGreen != true)
            {
                moveSpeed = car.GetComponent<TruckMovement>().moveSpeed;
                car.GetComponent<TruckMovement>().moveSpeed = 0;
                stoppedAtLights = true;
            }
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "barrier"
            || other.transform.tag == "car")
        {
            car.GetComponent<TruckMovement>().moveSpeed = moveSpeed;
            timer = 0.0f;
            bar.GetComponent<Renderer>().enabled = false;
            barRed.GetComponent<Renderer>().enabled = false;
            scaleFactor = 0.0f;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "barrier"
            || other.transform.tag == "car"
            || other.transform.tag == "TrafficLightStop")
        {
            timer += Time.deltaTime;
            if (timer > 10.0f)
            {
                bar.GetComponent<Renderer>().enabled = true;
                barRed.GetComponent<Renderer>().enabled = true;

                Transform t = barRedHolder.transform;
                if (scaleFactor < 4.1)
                {
                    scaleFactor += timer * 0.0001f;
                    barRedHolder.transform.localScale = new Vector3(scaleFactor,
                                                         t.transform.localScale.y,
                                                         t.transform.localScale.z);
                }
                if (scaleFactor > 4.1)
                {
                    car.GetComponent<TruckMovement>().moveSpeed = moveSpeed;
                }
            }
        }
        //timer += Time.deltaTime;
        //int seconds = timer % 60;
        //timer++;
    }
}
