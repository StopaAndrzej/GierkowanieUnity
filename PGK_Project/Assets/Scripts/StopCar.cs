using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCar : MonoBehaviour {

    public float moveSpeed;

    public GameObject car;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " collided with " + other.name);
        //Debug.Log("SSIEMMMA ENIIIUUU!");
        if(other.transform.tag == "barrier"
            || other.transform.tag == "car")
        {
            moveSpeed = car.GetComponent<CarMovement>().moveSpeed;
            car.GetComponent<CarMovement>().moveSpeed = 0;
        } else if (other.transform.tag == "Train")
        {
            Debug.Log("GAME OVER");
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "barrier"
            || other.transform.tag == "car") {
            car.GetComponent<CarMovement>().moveSpeed = moveSpeed;
        }
    }
}
