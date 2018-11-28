using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrainPeron : MonoBehaviour {

    private bool slowDown;
    private bool isStoped;

    public float lastSpeed;
    private float slowDownParameter;

    private GameObject thisGameObject;

    // Use this for initialization
    void Start() {
       isStoped = false;
       slowDown = false;
       slowDownParameter = 1;
    }

    void FixedUpdate () {
        if (slowDown)
        {
            SlowDownTheTrain(thisGameObject);
        }
        if (isStoped)
        {
            if (thisGameObject.GetComponent<TrainMovement>().readyToGo == true)
            {
                SpeedUpTheTrain(thisGameObject);
            }
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        
       if (other.transform.tag == "Train")
       {
           Debug.Log("STOP!!!");
           lastSpeed = other.GetComponent<TrainMovement>().moveSpeed;
           thisGameObject = other.gameObject;
           slowDownParameter=0.001f;
           slowDown = true;
           
          

            
            //isStoped = true;
            //isTrain = true;
            //isCargo = false;
        }
       //if (other.transform.tag == "TrainCargo")
       //{
       //    lastSpeed = other.GetComponent<CargoMove>().speed;
       //    other.GetComponent<CargoMove>().speed = 0;
       //    thisGameObject = other.gameObject;
       //    isStoped = true;
       //    isCargo = true;
       //    isTrain = false;
       //}
        
    }

    private void SlowDownTheTrain(GameObject obj)
    {
        if (obj.GetComponent<TrainMovement>().moveSpeed > 0)
        {
            
            obj.GetComponent<TrainMovement>().moveSpeed -= slowDownParameter;
            slowDownParameter *= 1.02f;
        }
        else
        {
            slowDownParameter = 1;
            obj.GetComponent<TrainMovement>().moveSpeed = 0;
            isStoped = true ;
        }
    }

    private void SpeedUpTheTrain(GameObject obj)
    {
        if(obj.GetComponent<TrainMovement>().moveSpeed < lastSpeed)
        {
            obj.GetComponent<TrainMovement>().moveSpeed += slowDownParameter;
            slowDownParameter *= 1.02f;
        }
        else
        {
            slowDownParameter = 1;
            obj.GetComponent<TrainMovement>().moveSpeed = lastSpeed;
            slowDown = false;
            isStoped = false;
        }
    }
}
