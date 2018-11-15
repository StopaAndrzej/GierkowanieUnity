using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove2 : MonoBehaviour {

    public int trainCapacity;
    public float speed = 10;
    private int numberToDestroy;

    private float timer;

    public int whichPeron;
    private bool wrongPeron;
    private bool isClicked;
    private bool enterTheTrain;
    public bool readyToGo;

    public GameObject passagersFolder;
    public GameObject peopleSpawner;

    // Use this for initialization
    void Start () {
        timer = 0;
        isClicked = false;
        readyToGo = false;
        trainCapacity = 20;
        numberToDestroy = 0;
        peopleSpawner = GameObject.Find("PeopleSpawner0");
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = transform.right * speed * Time.deltaTime;
        if (enterTheTrain)
        {
            if (passagersFolder.transform.childCount > numberToDestroy && trainCapacity > 0)
            {
                timer += Time.deltaTime;
                if (timer > 1)
                {
                    timer = 0;
                    trainCapacity--;
                    Destroy(passagersFolder.transform.GetChild(numberToDestroy).gameObject);
                    peopleSpawner.GetComponent<PeopleSpawner>().peopleNumber--;
                    numberToDestroy++;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "TrainStation")
        {
            if (whichPeron == other.GetComponent<CheckPeronID>().peronID)
            {
                wrongPeron = false;
            }
            if(whichPeron !=other.GetComponent<CheckPeronID>().peronID)
            {
                wrongPeron = true;
            }

            if(whichPeron == 0)
            {
                passagersFolder = GameObject.Find("SpawnedPeopleFolder0");
            }
            if (whichPeron == 1)
            {
                passagersFolder = GameObject.Find("SpawnedPeopleFolder1");
            }
        }
    }

    public void OnMouseDown()
    {
        if (!isClicked)
        {
            if (wrongPeron == true)
            {
                Debug.Log("WRONG PERON!!!");
                readyToGo = true;
            }
            else
            {
                Debug.Log("PROSZE WSIADAC!!!!");
                isClicked = true;
                enterTheTrain = true;
            }

        }
        else if (isClicked )
        {
            if (wrongPeron == true)
            {
                Debug.Log("WRONG PERON!!!");
                readyToGo = true;
            }
            else
            {
                Debug.Log("ODJAZD!!!!");
                isClicked = true;
                enterTheTrain = false;
                readyToGo = true;
            }
        }
    }

}
