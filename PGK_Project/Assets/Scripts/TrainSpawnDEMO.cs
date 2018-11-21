using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawnDEMO : MonoBehaviour {

    public GameObject trainToSpawn;
    public GameObject spawner;
    public GameObject folderToHoldTrains;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Instantiate(trainToSpawn, spawner.transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f), folderToHoldTrains.transform);
        }
    }
}
