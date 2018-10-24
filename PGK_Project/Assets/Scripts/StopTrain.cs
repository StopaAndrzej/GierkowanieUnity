using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrain : MonoBehaviour
{

    private float lastSpeed;
    public bool isStoped = false;
    public bool isTrain = false;
    public bool isCargo = false;
    public GameObject stopControlImported;
    public GameObject thisGameObject;


    void Update()
    {
        if (isStoped == true && stopControlImported.GetComponent<TrainStopLights>().stopControl == false)
        {
            if (isTrain)
            {
                thisGameObject.GetComponent<TrainMove>().speed = lastSpeed;
                TrainMove trainMove = thisGameObject.GetComponent<TrainMove>();
                trainMove.bar.GetComponent<Renderer>().enabled = false;
                trainMove.barRed.GetComponent<Renderer>().enabled = false;
            }
            if (isCargo)
                thisGameObject.GetComponent<CargoMove>().speed = lastSpeed;
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
                isTrain = true;
                isCargo = false;
            }
            if (other.transform.tag == "TrainCargo")
            {
                lastSpeed = other.GetComponent<CargoMove>().speed;
                other.GetComponent<CargoMove>().speed = 0;
                thisGameObject = other.gameObject;
                isStoped = true;
                isCargo = true;
                isTrain = false;
            }
        }
    }


}
//GetComponent<Rigidbody>().velocity = transform.forward* speed * Time.deltaTime;