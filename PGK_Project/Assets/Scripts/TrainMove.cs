using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    public int trainCapacity;
    public float speed;
    public float lastSpeed;
    public GameObject StopTrain;
    public bool onStation = false;
    public bool showOptions = false;
    public bool loadPeople = false;
    public bool isClicked = false;
    public GameObject trainOption1;
    public GameObject passangers;
    public int numberToDestroy;
    

    void Start()
    {
        trainCapacity = 20;
        numberToDestroy = 0;
        trainOption1 = this.gameObject.transform.GetChild(0).gameObject;
        trainOption1.GetComponent<MeshRenderer>().enabled = false;
        trainOption1.GetComponent<BoxCollider>().enabled = false;
        passangers = GameObject.Find("FolderWithPassagers");
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
        if (onStation == true && showOptions == true)
        {
            trainOption1.GetComponent<MeshRenderer>().enabled = true;
            trainOption1.GetComponent<BoxCollider>().enabled = true;
            if (passangers.transform.childCount > numberToDestroy && trainCapacity>0)
            {
                trainCapacity--;
                loadPeople = true;
                Destroy((passangers.transform.GetChild(numberToDestroy).gameObject));
                numberToDestroy++;
            }
            numberToDestroy = 0;
            


        }
        else
        {
            trainOption1.GetComponent<MeshRenderer>().enabled = false;
            trainOption1.GetComponent<BoxCollider>().enabled = false;
            loadPeople = false;
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
