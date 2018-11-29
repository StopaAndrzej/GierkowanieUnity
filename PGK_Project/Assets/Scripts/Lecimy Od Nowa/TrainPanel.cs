using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPanel : MonoBehaviour {

    public int ID;

    public Material material1;
    public Material material2;
    public GameObject panel;

    public int capacity1;
    public int maxCapacity1;


    public bool isOpened1;

    void Start()
    {

        material1 = gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials[2];
        capacity1 = 0;
        maxCapacity1 = 16;
        isOpened1 = false;

    }

    void Update()
    {

          //  panel.GetComponent<TrainScript>().text.SetText(capacity1.ToString()+"/"+maxCapacity1.ToString());
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
        panel = Resources.FindObjectsOfTypeAll<TrainScript>()[0].gameObject;
        panel.GetComponent<TrainScript>().actualCapacity = capacity1;
        panel.GetComponent<TrainScript>().maxCapacity = maxCapacity1;
        if (isOpened1)
        {
            isOpened1 = false;
        }
        else if (!isOpened1)
        {
            isOpened1 = true;
        }
        panel.GetComponent<TrainScript>().isOpened = isOpened1;
    }
}
