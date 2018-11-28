using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPanel : MonoBehaviour {

    public Material material1;
    public Material material2;


    void Start()
    {
        material1 = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials[2];
           // GetComponent<MeshRenderer>().materials[0];
    }


    void OnMouseEnter()
    {
        Debug.Log("zmien");
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = material2;
    }

    void OnMouseExit()
    {
        Debug.Log("!zmien");
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>()material = material1;
    }
}
