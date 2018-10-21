using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

    public Transform pos;
    public GameObject go;
    double timer = 0.0;
 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 20)
        {
            spawnCar();
            timer = 0.0;
        }
    }
    void spawnCar()
    {
        Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        Debug.Log("CAR SPAWN");
        Debug.Log("CAR SPAWN");
        Debug.Log("CAR SPAWN");
        Debug.Log(go.ToString());
    }
}
