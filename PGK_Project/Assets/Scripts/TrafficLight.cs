using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {

    public bool isGreen = true;
    public Material off;
    public Material greenMaterial;
    public Material orangeMaterial;
    public Material redMaterial;

    public GameObject green;
    public GameObject orange;
    public GameObject red;

    private Material greenMaterialOriginal;
    private Material orangeMaterialOriginal;
    private Material redMaterialOriginal;

    private int delay = 1;

    void Start () {
        greenMaterialOriginal = green.GetComponent<Renderer>().material;
        orangeMaterialOriginal = orange.GetComponent<Renderer>().material;
        redMaterialOriginal = red.GetComponent<Renderer>().material;

        green.GetComponent<Renderer>().material = greenMaterial;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnMouseDown()
    {
        if (isGreen)
        {
            isGreen = false;
            green.GetComponent<Renderer>().material = greenMaterialOriginal;
            orange.GetComponent<Renderer>().material = orangeMaterial;
            //Invoke("GreenToRed", delay);
            greenToRed();
            enableColliders(false); 
            //red.GetComponent<Renderer>().material = redMaterial;
        } else
        {
            enableColliders(true);
            isGreen = true;
            red.GetComponent<Renderer>().material = redMaterialOriginal;
            orange.GetComponent<Renderer>().material = orangeMaterial;
            //Invoke("RedToGreen", delay);
            redToGreen();
        }

    }

    public void greenToRed()
    {
        orange.GetComponent<Renderer>().material = orangeMaterialOriginal;
        red.GetComponent<Renderer>().material = redMaterial;
    }

    public void redToGreen()
    {
        orange.GetComponent<Renderer>().material = orangeMaterialOriginal;
        green.GetComponent<Renderer>().material = greenMaterial;

    }

    private void enableColliders(bool enable)
    {
        GameObject trafficStop = GameObject.Find("TrafficLightStop");

        foreach (BoxCollider g in trafficStop.GetComponentsInChildren<BoxCollider>())
        {
            Debug.Log(g.tag);
            if (g.tag == "CrowdBlockade")
            {
                g.enabled = enable;
            }
        }
    }
}
