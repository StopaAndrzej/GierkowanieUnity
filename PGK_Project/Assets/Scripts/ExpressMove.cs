using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressMove : MonoBehaviour {

    public int trainCapacity;
    public float speed;
    public float lastSpeed;



    // Use this for initialization
    void Start()
    {
        trainCapacity = 0;
        speed = 450;

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
    }
}
