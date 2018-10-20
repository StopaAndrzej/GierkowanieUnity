using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSteering : MonoBehaviour {

    public int angle;
    private bool isActive = false;


    public void OnMouseDown()
    {
        if (isActive)
        {
            isActive = false;
            Debug.Log("Trigger is not active!");
        }

        else if (!isActive)
        {
            isActive = true;
            Debug.Log("Trigger is active!");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (other.transform.tag == "Train")
            {
                other.transform.localEulerAngles = new Vector3(0, angle, 0);
            }
        }

    }
}
