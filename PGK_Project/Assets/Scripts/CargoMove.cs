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

    public Vector3 newRotation;
    public float timer;
    public float speed;
    public float lastSpeed;
    public float rotationSpeed;


   

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

        newRotation = transform.localEulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed * Time.deltaTime;
        RotateTrain();

    }

    public void RotateTrain()
    {
        this.transform.eulerAngles = Vector3.Lerp(transform.localEulerAngles, newRotation, rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CargoStation")
        {
            isMagazine = true;
        }
    }

}
