using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {

    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public GameObject objectToSelect;
    public List<GameObject> roof;

	// Use this for initialization
	void Start () {
        objectToSelect=transform.GetChild(0).gameObject;
        material1 = objectToSelect.GetComponent<MeshRenderer>().materials[0];
        material4 = roof[0].GetComponent<MeshRenderer>().materials[0];
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        Debug.Log("Zmien kolor");
        objectToSelect.GetComponent<MeshRenderer>().material = material2;
        foreach(GameObject x in roof)
        {
            x.GetComponent<MeshRenderer>().material = material3;
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Wroc kolor");
        objectToSelect.GetComponent<MeshRenderer>().material = material1;
        foreach (GameObject x in roof)
        {
            x.GetComponent<MeshRenderer>().material = material4;
        }
    }
}
