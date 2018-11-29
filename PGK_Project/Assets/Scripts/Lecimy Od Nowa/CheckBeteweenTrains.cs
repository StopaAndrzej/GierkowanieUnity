using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBeteweenTrains : MonoBehaviour {

    public GameObject train;

	void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Train")
        {
            train.GetComponent<TrainMovement>().moveSpeed = 0;
        }
    }
}
