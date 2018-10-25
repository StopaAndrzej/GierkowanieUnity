using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressDetect : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Train" || other.transform.tag == "TrainCargo" || other.transform.tag == "car")
        {
            Debug.Log("BUUUUUUUUUUUUUUUUUUM!");
                GameObject.Find("MainCamera").GetComponent<CameraController>().gameOver();
            
        }

    }
}
