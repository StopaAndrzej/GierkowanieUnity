using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrainPeron : MonoBehaviour {


    private float lastSpeed;
    private bool slowDown;
    private float slowDownParameter;

    private GameObject thisGameObject;

    // Use this for initialization
    void Start() {
       slowDown = false;
       slowDownParameter = 1;
    }

    void FixedUpdate () {
        if (slowDown)
        {
            SlowDownTheTrain(thisGameObject);
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        
       if (other.transform.tag == "Train")
       {
           Debug.Log("STOP!!!");
           lastSpeed = other.GetComponentInParent<TrainMove2>().speed;
           thisGameObject = other.gameObject;
           slowDownParameter=1;
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
        if (obj.GetComponentInParent<TrainMove2>().speed > 0)
        {
            
            obj.GetComponentInParent<TrainMove2>().speed -= slowDownParameter;
            slowDownParameter *= 1.02f;
        }
        else
        {
            obj.GetComponentInParent<TrainMove2>().speed = 0;
            slowDown = false;
        }
    }
}
