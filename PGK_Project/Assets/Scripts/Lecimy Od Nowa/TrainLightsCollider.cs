using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLightsCollider : MonoBehaviour {

    private float lastSpeed;

    public bool isStoped = false;
    public bool isTrain = false;
    public bool isCargo = false;

    public GameObject stopControlImported;
    public GameObject thisGameObject;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isStoped == true && stopControlImported.GetComponent<TrainLightScript>().changeColor == true)
        {
            if (isTrain)
            {
                thisGameObject.GetComponent<TrainMovement>().moveSpeed = lastSpeed;
                isStoped = false;
            }
            //if (isCargo)
            //    thisGameObject.GetComponent<CargoMove>().speed = lastSpeed;
            //isStoped = false;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!stopControlImported.GetComponent<TrainLightScript>().changeColor)
        {
            if (other.transform.tag == "Train")
            {
                Debug.Log("STOP");
                lastSpeed = other.GetComponent<TrainMovement>().moveSpeed;
                other.GetComponent<TrainMovement>().moveSpeed = 0;
                thisGameObject = other.gameObject;
                isStoped = true;
                isTrain = true;
                isCargo = false;
            }
            //if (other.transform.tag == "TrainCargo")
            //{
            //    lastSpeed = other.GetComponent<CargoMove>().speed;
            //    other.GetComponent<CargoMove>().speed = 0;
            //    thisGameObject = other.gameObject;
            //    isStoped = true;
            //    isCargo = true;
            //    isTrain = false;
            //}
        }
    }
}
