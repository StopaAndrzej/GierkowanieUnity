using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSteering : MonoBehaviour {

    public int angle;


    public void OnTriggerEnter(Collider other)
    {
            if (other.transform.tag == "Train" || other.transform.tag == "TrainCargo" || other.transform.tag == "TrainExpress")
            {
                other.transform.localEulerAngles = new Vector3(0, angle, 0);
                other.GetComponentInParent<GameObject>().transform.localEulerAngles=new Vector3(0, angle, 0);
        }
    }

}
