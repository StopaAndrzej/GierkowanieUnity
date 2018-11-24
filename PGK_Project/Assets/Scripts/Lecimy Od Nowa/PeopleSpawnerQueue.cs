using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnerQueue : MonoBehaviour {

    double timer = 0.0;
    public int peopleNumber = 0;
    public Transform pos;
    public GameObject go;
    public GameObject parent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);

            timer = 0.0f;
            peopleNumber++;
        }
    }
}
