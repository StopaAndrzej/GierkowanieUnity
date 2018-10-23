using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{

    public float speed;
    public float lastSpeed;
    public GameObject StopTrain;
    public bool onStation = false;
    public bool showOptions = false;
    public bool isClicked = false;
    public GameObject trainOption1;

    void Start()
    {
        trainOption1 = this.gameObject.transform.GetChild(0).gameObject;
        trainOption1.GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
        if (onStation == true && showOptions == true)
        {
            trainOption1.GetComponent<MeshRenderer>().enabled = true;

        }
        else
        {
            trainOption1.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "TrainStation")
        {
            onStation = true;
        }
    }

    public void OnMouseDown()
    {
        if (!isClicked)
        {
            showOptions = true;
            isClicked = true;
        }
        else if (isClicked)
        {
            showOptions = false;
            isClicked = false;
        }

    }
}
