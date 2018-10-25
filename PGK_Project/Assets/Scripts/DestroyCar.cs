using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "car")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
