using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeronPanel : MonoBehaviour {

    public Material material1;
    public Material material2;

    public GameObject panel;

    // Use this for initialization
    void Start () {
        material1 = gameObject.GetComponent<MeshRenderer>().materials[0];
        panel.SetActive(false);
    }

    void OnMouseEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material = material2;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = material1;
    }

    void OnMouseDown()
    {
        panel.SetActive(true);
    }


}
	
	

