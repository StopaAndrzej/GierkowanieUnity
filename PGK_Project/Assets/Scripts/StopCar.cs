using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCar : MonoBehaviour {

    public float moveSpeed;
    public float timer = 0;
    public GameObject car;
    public GameObject bar;
    public GameObject barRed;
    public GameObject barRedHolder;
    public GameObject savedBarrier;
    public float scaleFactor = 0;
    public bool insideBarierTrigger = false;

	// Use this for initialization
	void Start () {
        bar.GetComponent<Renderer>().enabled = false;
        barRed.GetComponent<Renderer>().enabled = false;
        timer = 0;
        scaleFactor = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(insideBarierTrigger==true && savedBarrier.GetComponent<BoxCollider>().enabled==false)
        {
            car.GetComponent<CarMovement>().moveSpeed = moveSpeed;
            timer = 0.0f;
            bar.GetComponent<Renderer>()  .enabled = false;
            barRed.GetComponent<Renderer>().enabled = false;
            //scaleFactor = 0.0f;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " collided with " + other.name);

        GameObject go = GameObject.Find("BarrierTriggerCube");
        BarrierTrigger b = go.GetComponent<BarrierTrigger>();
        if (other.transform.tag == "barrier")
        {
            moveSpeed = car.GetComponent<CarMovement>().moveSpeed;
            car.GetComponent<CarMovement>().moveSpeed = 0;
            savedBarrier = other.gameObject;
            insideBarierTrigger = true;
        }
            
        else if (other.transform.tag == "Train")
        {
            GameObject.Find("MainCamera").GetComponent<CameraController>().gameOver();
        }
        else if (other.transform.tag == "car")
        {
            moveSpeed = car.GetComponent<CarMovement>().moveSpeed;
            car.GetComponent<CarMovement>().moveSpeed = 0;
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "barrier"
            || other.transform.tag == "car") {
            car.GetComponent<CarMovement>().moveSpeed = moveSpeed;
            timer = 0.0f;
            bar.GetComponent<Renderer>().enabled = false;
            barRed.GetComponent<Renderer>().enabled = false;
            scaleFactor = 0.0f;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "barrier"
            || other.transform.tag == "car")
            {
            timer += Time.deltaTime;
            if(timer > 10.0f)
            {
                bar.GetComponent<Renderer>().enabled = true;
                barRed.GetComponent<Renderer>().enabled = true;

                Transform t = barRedHolder.transform;
                if(scaleFactor < 4.1)
                {
                    scaleFactor += timer * 0.0001f;
                    barRedHolder.transform.localScale = new Vector3(scaleFactor, 
                                                         t.transform.localScale.y,
                                                         t.transform.localScale.z);
                }
                if (scaleFactor > 4.1)
                {                
                    car.GetComponent<CarMovement>().moveSpeed = moveSpeed;
                }
            }
        }
        //timer += Time.deltaTime;
        //int seconds = timer % 60;
        //timer++;
    }
}
