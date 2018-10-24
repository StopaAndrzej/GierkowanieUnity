using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{

    public Transform pos;
    public GameObject go;
    double timer = 0.0;
    public int peopleNumber = 0;
    private int peronCapacity = 100;
    private float maxScaleFactor = 16.7f;
    public GameObject crowdBar;
    public GameObject crowdBarRed;
    public GameObject crowdBarRedHolder;
    public GameObject parent;

    public double crowdBarScaleFactor = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);

            timer = 0.0f;
            peopleNumber++;
        }
        if (peopleNumber > 10)
        {
            crowdBar.GetComponent<Renderer>().enabled = true;
            crowdBarRed.GetComponent<Renderer>().enabled = true;
            Transform t = crowdBarRedHolder.transform;
            float scale = (float)crowdBarScaleFactor;
            crowdBarRedHolder.transform.localScale = new Vector3(scale,
                                                     t.transform.localScale.y,
                                                     t.transform.localScale.z);
            if (peopleNumber < peronCapacity)
            {
                crowdBarScaleFactor = (float)(peopleNumber * 0.167);
            }
        }
        else
        {
            crowdBar.GetComponent<Renderer>().enabled = false;
            crowdBarRed.GetComponent<Renderer>().enabled = false;
        }
    }
}
