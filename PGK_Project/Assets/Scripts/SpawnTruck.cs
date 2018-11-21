using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour {

    public GameObject truckPrefab;
    public GameObject truckFolder;
    public GameObject truckPath;
    public GameObject spawnedTruck;


    // Use this for initialization
    void Start () {
        //truckPaths = GameObject.FindGameObjectsWithTag("truckPath");
    }
	
	public void Spawn()
    {
        Debug.Log("SPAWN TRUCK!");
        spawnedTruck = Instantiate(truckPrefab, gameObject.transform.position, Quaternion.Euler(0.0f, 90.0f, 0.0f), truckFolder.transform);
        spawnedTruck.GetComponent<TruckMovement>().currentPath = truckPath.transform;

    }


}
