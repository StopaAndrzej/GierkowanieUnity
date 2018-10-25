using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoMove : MonoBehaviour
{


    public bool isMagazine = false;
    public bool isClicked;
    public bool showOptions = false;
    public bool isFull;

    public int trainCapacity;
    public int actualCapacity;
    public int showMagazineCapacity;

    public float timer;
    public float speed;
    public float lastSpeed;

    public GameObject cargoBar;
    public GameObject cargoBarRed;
    public GameObject cargoBarHolder;
   

    public float scaleFactor = 0;

    public int whichWay;
    public int whichPeron;


    // Use this for initialization
    void Start()
    {
        isFull = false;
        isClicked = false;
        timer = 0;
        showMagazineCapacity = 100000;
        trainCapacity = 1000;
        actualCapacity = 0;
        speed = 150;
        //cargoBar = this.gameObject.transform.GetChild(0).gameObject;
        cargoBar.GetComponent<MeshRenderer>().enabled = false;
        cargoBar.GetComponent<BoxCollider>().enabled = false;
        cargoBarRed.GetComponent<MeshRenderer>().enabled = false;
        cargoBarRed.GetComponent<BoxCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
        if (isMagazine == true && showOptions == true)
        {
            //cargoBar.GetComponent<MeshRenderer>().enabled = true;
            //cargoBarRed.GetComponent<MeshRenderer>().enabled = true;

            
            if (showMagazineCapacity > 0 && actualCapacity < trainCapacity)
            {
                timer += Time.deltaTime;
                if (timer > 0.2f)
                {
                    timer = 0;
                    showMagazineCapacity-=4;
                    actualCapacity += 4;
                    scaleFactor = (float)(actualCapacity * 0.0097);
                    cargoBar.GetComponent<Renderer>().enabled = true;
                    cargoBarRed.GetComponent<Renderer>().enabled = true;
                    Transform t = cargoBarHolder.transform;

                    cargoBarHolder.transform.localScale = new Vector3(scaleFactor,
                                                             t.transform.localScale.y,
                                                             t.transform.localScale.z);
                    if (actualCapacity>500)
                        isFull = true;
                }
            }
        }
        else
        {
            cargoBar.GetComponent<Renderer>().enabled = false;
            cargoBarRed.GetComponent<Renderer>().enabled = false;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CargoStation")
        {
            isMagazine = true;
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
