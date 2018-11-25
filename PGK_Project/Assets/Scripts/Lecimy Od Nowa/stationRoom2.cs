using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class stationRoom2 : MonoBehaviour {

    public List<GameObject> selectedObjs;
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;


    void Start()
    {
        material1 = selectedObjs[0].GetComponent<MeshRenderer>().materials[0];
        material2 = selectedObjs[1].GetComponent<MeshRenderer>().materials[0];

    }



    void OnMouseEnter()
    {
        selectedObjs[0].GetComponent<MeshRenderer>().material = material3;
        selectedObjs[1].GetComponent<MeshRenderer>().material = material4;
    }


    void OnMouseExit()
    {
        selectedObjs[0].GetComponent<MeshRenderer>().material = material1;
        selectedObjs[1].GetComponent<MeshRenderer>().material = material2;
    }
}
