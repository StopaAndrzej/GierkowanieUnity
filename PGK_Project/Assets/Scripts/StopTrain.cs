using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrain : MonoBehaviour {

    private bool isActive = false;
    private float lastSpeed;
    

    public void OnMouseDown()
    {
        if (isActive)
        {
            isActive = false;
            Debug.Log("Blocade is not active!");
        }

        else if (!isActive)
        {
            isActive = true;
            Debug.Log("Blocade is active!");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.transform.tag == "Train")
            {
               
                lastSpeed = other.GetComponent<TrainMove>().speed;
                other.GetComponent<TrainMove>().speed = 1000;
                Debug.Log("Train stoped!");
                
            }
           
        }
 
    }


}
//GetComponent<Rigidbody>().velocity = transform.forward* speed * Time.deltaTime;