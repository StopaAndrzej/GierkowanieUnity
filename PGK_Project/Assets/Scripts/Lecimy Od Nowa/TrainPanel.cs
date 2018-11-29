using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPanel : MonoBehaviour {

    public Material material1;
    public Material material2;
    public GameObject panel;

    public int capacity1;
    public int maxCapacity1;

    void Start()
    {
        capacity1 = 0;
        maxCapacity1 = 16;
        panel.SetActive(false);
        material1 = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials[2];
        panel = Resources.FindObjectsOfTypeAll<TrainScript>()[0].gameObject;
        Debug.Log(Resources.FindObjectsOfTypeAll<TrainScript>()[0].gameObject);
    }


    void OnMouseEnter()
    {
        Debug.Log("zmien");
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = material2;
    }

    void OnMouseExit()
    {
        Debug.Log("!zmien");
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = material1;
    }

    void OnMouseDown()
    {
        panel.SetActive(true);
        panel.GetComponent<TrainScript>().capacity = capacity1;
        panel.GetComponent<TrainScript>().maxCapacity = maxCapacity1;
    }
}
