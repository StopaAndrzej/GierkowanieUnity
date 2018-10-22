using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSteering : MonoBehaviour {

    public int angle;
    private bool isActive = false;
    public GameObject changeSteeringImported;


  

    public void OnTriggerEnter(Collider other)
    {
        if (changeSteeringImported.GetComponent<SteeringArrow>().changeSteering)
        {
            if (other.transform.tag == "Train")
            {
                other.transform.localEulerAngles = new Vector3(0, angle, 0);
                Debug.Log("Strzalka DZIALA!");
            }
        }

    }
}
