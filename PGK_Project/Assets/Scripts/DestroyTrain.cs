using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrain : MonoBehaviour {

    public int id;

	void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Train")
        {
            if(other.GetComponent<TrainMove>().whichWay == id)
            {
                Debug.Log("DOBRZE!!!");
            }
            else
            {
                Debug.Log("ZŁA TRASA!!!");
            }
            Destroy(other.gameObject);
        }

        if(other.transform.tag == "TrainCargo")
        {
            if (other.GetComponent<CargoMove>().whichWay == id && other.GetComponent<CargoMove>().isFull == true)
            {
                Debug.Log("DOBRZE!!!");
            }
            else if(other.GetComponent<CargoMove>().whichWay == id && other.GetComponent<CargoMove>().isFull == false)
            {
                Debug.Log("BRAK ŁADUNKU!!!");
            }
            else
            {
                Debug.Log("ZŁA TRASA!!!");
            }
            Destroy(other.gameObject);
        }
    }
}
