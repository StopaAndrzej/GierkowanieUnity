using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {

    public bool isGreen;
    public Material off;
    public Material greenMaterial;
    public Material orangeMaterial;
    public Material redMaterial;

    public GameObject green;
    public GameObject orange;
    public GameObject red;

    public GameObject colliderL;    //kolajdery do blokowania pieszych, sami dopasowywujemy
    public GameObject colliderR;

  

    private Material greenMaterialOriginal;
    private Material orangeMaterialOriginal;
    private Material redMaterialOriginal;

    private int delay = 1;

    void Start () {
        greenMaterialOriginal = green.GetComponent<Renderer>().material;
        orangeMaterialOriginal = orange.GetComponent<Renderer>().material;
        redMaterialOriginal = red.GetComponent<Renderer>().material;
        green.GetComponent<Renderer>().material = greenMaterial;
        isGreen = true;

        

        
    }

    // Update is called once per frame
    void Update () {
        if (isGreen)                    //wywalilem z onMouseDown do updata, bo w przeciwnym razie nie było by odświeżania w skrypcie trafficLisghtCross
        {
            green.GetComponent<Renderer>().material = greenMaterialOriginal;
            orange.GetComponent<Renderer>().material = orangeMaterial;
            greenToRed();
            colliderR.GetComponent<BoxCollider>().enabled = false;
            colliderL.GetComponent<BoxCollider>().enabled = false;
            //red.GetComponent<Renderer>().material = redMaterial;
        }
        else
        {
            red.GetComponent<Renderer>().material = redMaterialOriginal;
            orange.GetComponent<Renderer>().material = orangeMaterial;
            redToGreen();
            colliderR.GetComponent<BoxCollider>().enabled = true;
            colliderL.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void OnMouseDown()
    {
        if (isGreen)
        {
            isGreen = false;
        } else
        {
            isGreen = true;
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

  

}
