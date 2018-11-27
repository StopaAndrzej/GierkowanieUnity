using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour {

    public Material material1;
    public Material material2;
    public Material material3;

    void Start()
    {
        material1=gameObject.GetComponent < MeshRenderer > ().materials[0];
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
        gameObject.GetComponent<MeshRenderer>().material = material3;
    }

    void OnMouseUp()
    {
        gameObject.GetComponent<MeshRenderer>().material = material1;
    }
}
