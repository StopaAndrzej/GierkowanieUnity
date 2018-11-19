using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parking : MonoBehaviour {

    public GameObject carPrefab;
    public GameObject currentSpawnedCar;
    public GameObject parent; //Cars folder
    public GameObject[] carPaths;
    double timer = 0.0;
    int period = 1;

    private void Start()
    {
        carPaths = GameObject.FindGameObjectsWithTag("carPath");
    }

    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > period)
        //{
        //    spawnCar();
        //    period = Random.Range(5, 10);
        //    timer = 0.0;
        //}
    }
    public void spawnCar()
    {
        int r = Random.Range(1, 3);
        currentSpawnedCar = Instantiate(carPrefab, gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);
        if (r == 1)
        {
            currentSpawnedCar.GetComponent<CarMovement>().model2.SetActive(false);
        }
        else
        {
            currentSpawnedCar.GetComponent<CarMovement>().model1.SetActive(false);
        }
        int p = Random.Range(0, carPaths.Length);
        currentSpawnedCar.GetComponent<CarMovement>().currentPath = carPaths[p].transform;
    }
}
