using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoMove : MonoBehaviour {

    public int trainCapacity;
    public float speed;
    public float lastSpeed;



    // Use this for initialization
    void Start () {
        trainCapacity = 1000;
        speed = 150;

    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
    }
}
