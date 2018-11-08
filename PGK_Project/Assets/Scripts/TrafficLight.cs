using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {

    public bool isGreen = false;
    public Material off;
    public Material greenMaterial;
    public Material orangeMaterial;
    public Material redMaterial;

    public GameObject green;
    public GameObject orange;
    public GameObject red;

    private int delay = 1;

    void Start () {
        green.GetComponent<Renderer>().material = off;
        orange.GetComponent<Renderer>().material = off;
        red.GetComponent<Renderer>().material = redMaterial;

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnMouseDown()
    {
        if (isGreen)
        {
            isGreen = false;
            green.GetComponent<Renderer>().material = off;
            orange.GetComponent<Renderer>().material = orangeMaterial;
            //Invoke("GreenToRed", delay);
            greenToRed();
            //red.GetComponent<Renderer>().material = redMaterial;
        } else
        {
            isGreen = true;
            red.GetComponent<Renderer>().material = off;
            orange.GetComponent<Renderer>().material = orangeMaterial;
            //Invoke("RedToGreen", delay);
            redToGreen();

        }

    }

    public void greenToRed()
    {
        orange.GetComponent<Renderer>().material = off;
        red.GetComponent<Renderer>().material = redMaterial;
    }

    public void redToGreen()
    {
        orange.GetComponent<Renderer>().material = off;
        green.GetComponent<Renderer>().material = greenMaterial;

    }
}
