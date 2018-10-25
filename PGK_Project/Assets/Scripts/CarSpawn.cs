using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

    public Transform pos;
    public GameObject go;
    public GameObject currentSpawnedCar;
    public GameObject parent;
    double timer = 0.0;
    int period=1;
    public int id;
 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > period)
        {
            spawnCar();
            period = Random.Range(1, 5);
            timer = 0.0;
        }
    }
    void spawnCar()
    {
        currentSpawnedCar = Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);
        currentSpawnedCar.GetComponent<CarMovement>().whichSpawn = id;
        Debug.Log("CAR SPAWN");
        Debug.Log("CAR SPAWN");
        Debug.Log("CAR SPAWN");
        Debug.Log(go.ToString());
    }
}
