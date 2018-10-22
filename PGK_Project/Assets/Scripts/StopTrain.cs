using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrain : MonoBehaviour {

    private float lastSpeed;
    public bool isStoped = false;
    public GameObject stopControlImported;
    public GameObject thisGameObject;


     void Update()
    {
        if (isStoped == true && stopControlImported.GetComponent<TrainStopLights>().stopControl==false)
        {
            
            //        //GameObject go = GameObject.FindGameObjectWithTag("Train");
            //        //TrainMove tm = go.GetComponent<TrainMove>();
            thisGameObject.GetComponent<TrainMove>().speed = lastSpeed;
            //        //tm.speed = lastSpeed;
            isStoped = false;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (stopControlImported.GetComponent<TrainStopLights>().stopControl)
        {
            if (other.transform.tag == "Train")
            {
                Debug.Log("STOP");
                lastSpeed = other.GetComponent<TrainMove>().speed;
                other.GetComponent<TrainMove>().speed = 0;
                thisGameObject = other.gameObject; 
                isStoped = true;
            }
        }
    }


}
//GetComponent<Rigidbody>().velocity = transform.forward* speed * Time.deltaTime;