using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrain : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Train" || other.transform.tag == "TrainCargo" || other.transform.tag == "TrainExpress")
        {
            Destroy(other.gameObject);
        }
    }
}
