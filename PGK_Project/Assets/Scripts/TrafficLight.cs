using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject lightTimer;
    public float timeConstant = 20;
    public float timeLeftForChange;
    public bool changeLights = false;
    public float changeLightTime = 2;

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
        timeLeftForChange = timeConstant;
    }

    // Update is called once per frame
    void Update () {

        if (changeLights)
        {
            if(changeLightTime > 0)
            {
                changeLightTime -= Time.deltaTime;
                orangeLight();
            }
            else
            {
                changeLights = false;
                changeLightTime = 2f;
            }
        } else
        {
            if (isGreen)
            {
                colliderR.GetComponent<BoxCollider>().enabled = true;
                colliderL.GetComponent<BoxCollider>().enabled = true;
                greenLight();
            }
            else
            {
                redLight();
                colliderR.GetComponent<BoxCollider>().enabled = false;
                colliderL.GetComponent<BoxCollider>().enabled = false;
            }
            timeLeftForChange -= Time.deltaTime;
            int timeInInt = (int)timeLeftForChange;
            lightTimer.GetComponent<TextMeshProUGUI>().SetText(timeInInt.ToString());
            if(timeInInt == 0)
            {
                isGreen = !isGreen;
                timeLeftForChange = timeConstant;
                changeLights = true;
            }
        }


    }

    public void OnMouseDown()
    {
        if (isGreen)
        {
            changeLights = true;
            isGreen = false;

        } else
        {
            changeLights = true;
            isGreen = true;
        }
        timeLeftForChange = timeConstant;
    }

    public void redLight()
    {
        orange.GetComponent<Renderer>().material = orangeMaterialOriginal;
        green.GetComponent<Renderer>().material = greenMaterialOriginal;
        red.GetComponent<Renderer>().material = redMaterial;

        lightTimer.GetComponent<TextMeshProUGUI>().faceColor = new Color(255,0,0);
    }

    public void greenLight()
    {
        orange.GetComponent<Renderer>().material = orangeMaterialOriginal;
        red.GetComponent<Renderer>().material = redMaterialOriginal;
        green.GetComponent<Renderer>().material = greenMaterial;

        lightTimer.GetComponent<TextMeshProUGUI>().faceColor = new Color(0, 255, 0);
    }

    public void orangeLight()
    {
        orange.GetComponent<Renderer>().material = orangeMaterial;
        red.GetComponent<Renderer>().material = redMaterialOriginal;
        green.GetComponent<Renderer>().material = greenMaterialOriginal;
    }

}
