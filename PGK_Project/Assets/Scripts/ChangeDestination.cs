using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDestination : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
            if (other.transform.tag == "crowd")
            {
            Debug.Log("aaaa");
            Debug.Log("aaaa");
            Debug.Log("aaaa");
            Debug.Log("aaaa");
            Debug.Log("aaaa");
            Debug.Log("aaaa");
        }
    }
}
