using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStopLights : MonoBehaviour {

    public bool stopControl = false;

    public Material[] myMaterials = new Material[3];
    public GameObject red;
    public GameObject green;

    void Start()
    {
        red.GetComponent<Renderer>().material = myMaterials[0];
        green.GetComponent<Renderer>().material = myMaterials[2];
    }


    public void OnMouseDown()
    {
        if (stopControl == true)
        {
            stopControl = false;
            red.GetComponent<Renderer>().material = myMaterials[0];
            green.GetComponent<Renderer>().material = myMaterials[2];
        }

        else if (stopControl == false)
        {
            stopControl = true;
            red.GetComponent<Renderer>().material = myMaterials[1];
            green.GetComponent<Renderer>().material = myMaterials[0];
        }

    }
}
