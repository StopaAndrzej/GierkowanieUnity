using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoSpawn : MonoBehaviour {

    public GameObject[] go;

    public int thisHour;
    public int thisMinute;
    public Text[] timeTables;

    public GameObject actualSpawnedObject;

    void Start()
    {

    }

    void Update()
    {
        thisHour = System.DateTime.Now.Minute;
        thisMinute = System.DateTime.Now.Second;
        thisHour = thisHour % 24;
        spawnTrain();
    }


    void spawnTrain()
    {
        foreach (Text t in timeTables)
        {
            if (t.GetComponent<TrainTimeTable>().hour == thisHour && t.GetComponent<TrainTimeTable>().minute == thisMinute)
            {
                actualSpawnedObject = Instantiate(go[0], transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                actualSpawnedObject.GetComponent<CargoMove>().whichWay = t.GetComponent<TrainTimeTable>().whichWay;
                actualSpawnedObject.GetComponent<CargoMove>().whichPeron = t.GetComponent<TrainTimeTable>().whichPeron;
                t.GetComponent<TrainTimeTable>().hour = -1;


            }
        }

    }
}
