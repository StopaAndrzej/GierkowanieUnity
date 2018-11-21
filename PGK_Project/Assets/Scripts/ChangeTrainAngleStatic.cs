using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrainAngleStatic : MonoBehaviour {

    public float angle;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "TrainCargo")
        {
            other.transform.GetComponent<CargoMove>().newRotation = new Vector3(0, angle, 0);
        }
    }

}
