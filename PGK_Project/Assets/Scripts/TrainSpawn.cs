using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawn : MonoBehaviour {

    public Transform pos;
    public GameObject go;
    double timer = 0.0;

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
            spawnCar();
            timer = 0.0;
        }
    }
    void spawnCar()
    {
        Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }
}
