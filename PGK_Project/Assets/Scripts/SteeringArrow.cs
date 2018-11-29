using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringArrow : MonoBehaviour {

    public bool changeSteering=false;
    public int angle;
    public int angle2;


    public void change()
    {
        if (changeSteering == true)
        {
            //transform.localRotation.y= new Vector3(0)
            transform.localEulerAngles = new Vector3(0, angle - angle2, 0);
            changeSteering = false;
        }
        
        else if (changeSteering == false)
        {
            transform.localEulerAngles = new Vector3(0, angle, 0);
            changeSteering = true;
        }
            
    }
}
