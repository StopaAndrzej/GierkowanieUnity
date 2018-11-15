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
            period = Random.Range(5, 10);
            timer = 0.0;
        }
    }
    void spawnCar()
    {
        int r = Random.Range(1, 3);
        currentSpawnedCar = Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);
        if (r == 1)
        {
            currentSpawnedCar.GetComponent<CarMovement>().model2.SetActive(false);
        } else
        {
            currentSpawnedCar.GetComponent<CarMovement>().model1.SetActive(false);
        }
        currentSpawnedCar.GetComponent<CarMovement>().whichSpawn = id;
    }
}
