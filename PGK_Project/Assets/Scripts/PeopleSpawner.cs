using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour {

    public Transform pos;
    public GameObject go;
    double timer = 0.0;
    public int peopleNumber = 0;
    public GameObject crowdBar;
    public GameObject crowdBarRed;
    public GameObject crowdBarRedHolder;

    public double crowdBarScaleFactor = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            timer = 0.0f;
            peopleNumber++;
        }
        if(peopleNumber > 10)
        {
            crowdBar.GetComponent<Renderer>().enabled = true;
            crowdBarRed.GetComponent<Renderer>().enabled = true;
            Transform t = crowdBarRedHolder.transform;
            float scale = (float)crowdBarScaleFactor;
            crowdBarRedHolder.transform.localScale = new Vector3(scale,
                                                     t.transform.localScale.y,
                                                     t.transform.localScale.z);
            if (crowdBarScaleFactor < 16.7)
            {
                crowdBarScaleFactor += timer * 0.01f;
            }
        }
    }
}
