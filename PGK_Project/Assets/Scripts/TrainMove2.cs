using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove2 : MonoBehaviour {

    public float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = transform.right * speed * Time.deltaTime;
    }

    
}
