using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoMove : MonoBehaviour {


    public bool isMagazine=false;
    public bool isClicked;
    public bool showOptions = false;

    public int trainCapacity;
    public int actualCapacity;
    public int showMagazineCapacity;

    public float timer;
    public float speed;
    public float lastSpeed;

    public GameObject cargoOption1;
    public GameObject importedCapacity;



    // Use this for initialization
    void Start () {
        isClicked = false;
        timer = 0;
        trainCapacity = 1000;
        actualCapacity = 0;
        speed = 150;
        cargoOption1 = this.gameObject.transform.GetChild(0).gameObject;
        cargoOption1.GetComponent<MeshRenderer>().enabled = false;
        cargoOption1.GetComponent<BoxCollider>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
        if(isMagazine==true && showOptions==true)
        {
            cargoOption1.GetComponent<MeshRenderer>().enabled = true;
            cargoOption1.GetComponent<BoxCollider>().enabled = true;
            showMagazineCapacity = importedCapacity.GetComponent<Magaize>().capacity;
            if (showMagazineCapacity > 0 && actualCapacity < trainCapacity)
            {
                timer += Time.deltaTime;
                if (timer > 0.2f)
                {
                    timer = 0;
                    showMagazineCapacity--;
                    actualCapacity+=2;
                }
            }
        }
        else
        {
            cargoOption1.GetComponent<MeshRenderer>().enabled = false;
            cargoOption1.GetComponent<BoxCollider>().enabled = false;
            
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
