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
    public bool wrongPeron = false;
    public GameObject trainOption1;
    public GameObject passangers;
    public int numberToDestroy;
    public GameObject bar;
    public GameObject barRed;
    public GameObject barRedHolder;
    public float scaleFactor = 0;
    public float timer = 0;
    public GameObject peopleSpawner;

    public int whichWay;
    public int whichPeron;

    void Start()
    {
        bar.GetComponent<Renderer>().enabled = false;
        barRed.GetComponent<Renderer>().enabled = false;
        trainCapacity = 20;
        numberToDestroy = 0;
        trainOption1 = this.gameObject.transform.GetChild(0).gameObject;
        trainOption1.GetComponent<MeshRenderer>().enabled = false;
        trainOption1.GetComponent<BoxCollider>().enabled = false;
        //passangers = GameObject.Find("FolderWithPassagers");
        peopleSpawner = GameObject.Find("PeronSpawner");
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
        if (onStation == true && showOptions == true)
        {
            
            trainOption1.GetComponent<MeshRenderer>().enabled = true;
            trainOption1.GetComponent<BoxCollider>().enabled = true;
            if (passangers.transform.childCount > numberToDestroy && trainCapacity > 0)
            {
                timer += Time.deltaTime;
                if (timer > 1)
                {
                    timer = 0;
                    trainCapacity--;
                    loadPeople = true;
                    Destroy((passangers.transform.GetChild(numberToDestroy).gameObject));
                    peopleSpawner.GetComponent<PeopleSpawner>().peopleNumber--;
                    numberToDestroy++;
                }
                int pplInTrain = 20 - trainCapacity;
                scaleFactor = (float)(pplInTrain * 0.92);
                bar.GetComponent<Renderer>().enabled = true;
                barRed.GetComponent<Renderer>().enabled = true;

                Transform t = barRedHolder.transform;
                barRedHolder.transform.localScale = new Vector3(scaleFactor,
                                                         t.transform.localScale.y,
                                                         t.transform.localScale.z);
                numberToDestroy = 0;
            }
            else
            {
                trainOption1.GetComponent<MeshRenderer>().enabled = false;
                trainOption1.GetComponent<BoxCollider>().enabled = false;
                loadPeople = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "TrainStation")
        {
            if (whichPeron == other.GetComponent<CheckPeronID>().peronID)
            {
                wrongPeron = false;
            }

            if (whichPeron != other.GetComponent<CheckPeronID>().peronID)
            {
                wrongPeron = true;
            }

            if (whichPeron == 1)
            { 
                passangers = GameObject.Find("FolderWithPassagers1");
            }
            if(whichPeron == 2)
            {
                passangers = GameObject.Find("FolderWithPassagers");
            }
            onStation = true;
        }
    }

    public void OnMouseDown()
    {
        if (!isClicked)
        {
            if (wrongPeron == true)
            {
                Debug.Log("WRONG PERON!!!");
            }
            else
            {
                showOptions = true;
                isClicked = true;
            }
            
        }
        else if (isClicked)
        {
            showOptions = false;
            isClicked = false;
        }
    }
}