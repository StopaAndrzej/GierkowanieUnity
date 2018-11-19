using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDestination : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "crowd")
        {
            Destroy(other.gameObject);
            GameObject.Find("Parking").GetComponent<Parking>().spawnCar();
        }
    }
}
