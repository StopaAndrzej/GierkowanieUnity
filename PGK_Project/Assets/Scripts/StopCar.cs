using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCar : MonoBehaviour {

    public float moveSpeed;
    public float timer = 0;
    public GameObject car;
    public float scaleFactor = 0;
	// Use this for initialization
	void Start () {
        GameObject.Find("AnnoyBarOfCar").GetComponent<Renderer>().enabled = false;
        GameObject.Find("AnnoyBarOfCarRed").GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " collided with " + other.name);
        //Debug.Log("SSIEMMMA ENIIIUUU!");

        GameObject go = GameObject.Find("BarrierTriggerCube");
        BarrierTrigger b = go.GetComponent<BarrierTrigger>();
        if (other.transform.tag == "barrier")
        {
            moveSpeed = car.GetComponent<CarMovement>().moveSpeed;
            car.GetComponent<CarMovement>().moveSpeed = 0;


        }
            
        else if (other.transform.tag == "Train")
        {
            Debug.Log("GAME OVER");
        }else if (other.transform.tag == "car")
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
            GameObject.Find("AnnoyBarOfCar").GetComponent<Renderer>().enabled = false;
            GameObject.Find("AnnoyBarOfCarRed").GetComponent<Renderer>().enabled = false;
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
                GameObject.Find("AnnoyBarOfCar").GetComponent<Renderer>().enabled = true;
                GameObject.Find("AnnoyBarOfCarRed").GetComponent<Renderer>().enabled = true;

                Transform t = GameObject.Find("AnnoyBarOfCarRed").transform;
                GameObject.Find("AnnoyBarOfCarRed").transform.localScale = new Vector3(scaleFactor, 
                                                                                        t.transform.localScale.y,
                                                                                        t.transform.localScale.z);
                if(scaleFactor < 0.8)
                {
                    scaleFactor += timer * 0.0001f;
                }
            }
        }
        //timer += Time.deltaTime;
        //int seconds = timer % 60;
        //timer++;
    }
}
