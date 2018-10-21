using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCar : MonoBehaviour {


    public GameObject car;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "TestCollider")
        Debug.Log("SSIEMMMA ENIIIUUU!");
        //car.GetComponent<CarMovement>().moveSpeed = 0;
        
    }
}
