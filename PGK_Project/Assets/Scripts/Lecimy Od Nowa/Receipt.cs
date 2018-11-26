using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receipt : MonoBehaviour {

    public List<GameObject> selectedObjs;
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;

    public GameObject panel;

    void Start()
    {
        material1 = selectedObjs[0].GetComponent<MeshRenderer>().materials[0];
        material2 = selectedObjs[1].GetComponent<MeshRenderer>().materials[0];
        panel.SetActive(false);
    }



    void OnMouseEnter()
    {
        if (GameState.isStarted)
        {
            selectedObjs[0].GetComponent<MeshRenderer>().material = material3;
            selectedObjs[1].GetComponent<MeshRenderer>().material = material4;
            selectedObjs[2].GetComponent<MeshRenderer>().material = material4;
        }
    }

    void OnMouseExit()
    {
        selectedObjs[0].GetComponent<MeshRenderer>().material = material1;
        selectedObjs[1].GetComponent<MeshRenderer>().material = material2;
        selectedObjs[2].GetComponent<MeshRenderer>().material = material2;
    }

    void OnMouseDown()
    {
        if (GameState.isStarted)
        {
            panel.SetActive(true);
        }
    }
}
