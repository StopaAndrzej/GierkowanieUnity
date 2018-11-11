using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficStop : MonoBehaviour {

    public TrafficLight trafficLights;
    public float lastSpeed = 0;
    public bool isStopped = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!trafficLights.isGreen)
    //    {
    //        if (other.transform.tag == "car")
    //        {
    //            Debug.Log("STOP CAR");
    //            Debug.Log("STOP CAR");
    //            Debug.Log("STOP CAR");
    //            Debug.Log("STOP CAR");
    //            Debug.Log("STOP CAR");
    //            Debug.Log("STOP CAR");
    //            lastSpeed = other.GetComponent<CarMovement>().moveSpeed;
    //            other.GetComponent<CarMovement>().moveSpeed = 0;

    //            isStopped = true;
    //        }
    //    }
    //}
}
