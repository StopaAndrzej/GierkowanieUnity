using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrain : MonoBehaviour {

    private bool isActive = false;
    private float lastSpeed;
    private bool isStoped=false;
    

    public void OnMouseDown()
    {
        if (isActive)
        {
            isActive = false;
            Debug.Log("Blocade is not active!");
            GameObject go = GameObject.FindGameObjectWithTag("Train");
            TrainMove tm = go.GetComponent<TrainMove>();
            tm.speed = lastSpeed;
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
                other.GetComponent<TrainMove>().speed = 0;
                Debug.Log("Train stoped!");
                
            }
           
        }
       
 
    }


}
//GetComponent<Rigidbody>().velocity = transform.forward* speed * Time.deltaTime;