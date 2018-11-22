using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockPakageOnTruck : MonoBehaviour {

    public bool isDocked;

 
    
  

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "car")
        {
            isDocked = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "car")
        {
            isDocked = false;
        }
    }
}
