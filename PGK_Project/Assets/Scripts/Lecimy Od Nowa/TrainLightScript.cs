using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainLightScript : MonoBehaviour {

    public GameObject collider;

    public Material material1;
    public Material material2;

    public GameObject red;
    public GameObject green;

    public Material mat1;
    public Material mat2;
    public Material mat3;

    public bool changeColor;

    void Start()
    {
        changeColor = false;
        red.GetComponent<MeshRenderer>().material = mat1;
        green.GetComponent<MeshRenderer>().material = mat2;
        material1 = gameObject.GetComponent<MeshRenderer>().materials[0];
    }

    void OnMouseEnter()
    {
        if (GameState.isStarted)
        {
            gameObject.GetComponent<MeshRenderer>().material = material2;
        }
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = material1;
    }

    void OnMouseDown()
    {
        if (changeColor)
        {
            red.GetComponent<MeshRenderer>().material = mat1;
            green.GetComponent<MeshRenderer>().material = mat2;
            changeColor = false;
        }
        else if (!changeColor)
        {
            red.GetComponent<MeshRenderer>().material = mat2;
            green.GetComponent<MeshRenderer>().material = mat3;
            changeColor = true;
        }


    }



}
