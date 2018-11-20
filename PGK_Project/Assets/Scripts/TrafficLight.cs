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
        if (isGreen)
        {
            colliderR.GetComponent<BoxCollider>().enabled = true;
            colliderL.GetComponent<BoxCollider>().enabled = true;
            greenLight();
            //red.GetComponent<Renderer>().material = redMaterial;
        }
        else
        {
            redLight();
            colliderR.GetComponent<BoxCollider>().enabled = false;
            colliderL.GetComponent<BoxCollider>().enabled = false;
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

    public void redLight()
    {
        orange.GetComponent<Renderer>().material = orangeMaterialOriginal;
        green.GetComponent<Renderer>().material = greenMaterialOriginal;
        red.GetComponent<Renderer>().material = redMaterial;
    }

    public void greenLight()
    {
        orange.GetComponent<Renderer>().material = orangeMaterialOriginal;
        red.GetComponent<Renderer>().material = redMaterialOriginal;
        green.GetComponent<Renderer>().material = greenMaterial;
    }



}
