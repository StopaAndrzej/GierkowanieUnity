using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressSpawner : MonoBehaviour {

    public Transform pos;
    public GameObject redPath;
    public GameObject go;
    public GameObject currentSpawnedCar;
    double timer = 0.0;
    int warning = 300;
    int period = 310;
    public int id;
    public bool isGone;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < redPath.transform.childCount; ++i)
        {
            redPath.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }

            
        isGone = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer> warning && isGone == false)
        {
            for (int i = 0; i < redPath.transform.childCount; ++i)
            {
                redPath.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if (timer > period && isGone == false)
        {
            spawnExpress();
            period = Random.Range(1, 5);
            timer = 0.0;
            isGone = true;
        }
    }
    void spawnExpress()
    {
        Instantiate(go, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        
        Debug.Log("SPAWN EXPRESS");
        Debug.Log("SPAWN EXPRESS");
        Debug.Log("SPAWN EXPRESS");
        Debug.Log(go.ToString());
    }
}
