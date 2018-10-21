using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainSpawn : MonoBehaviour {

    public GameObject go;

    public int thisHour;
    public int thisMinute;
    public Text[] timeTables;

    public int testHour;
    public int testMinute;
    //public int timer=0;

    void Start()
    {
        
    }

    void Update()
    {
        thisHour = System.DateTime.Now.Hour;
        thisMinute = System.DateTime.Now.Minute;
        spawnTrain();
    }

    
    void spawnTrain()
    {
        foreach( Text t in timeTables)
        {
            if(t.GetComponent<TrainTimeTable>().hour == thisHour && t.GetComponent<TrainTimeTable>().minute == thisMinute)
            {
               
                    Instantiate(go, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                t.GetComponent<TrainTimeTable>().hour = -1;


            }
        }
       
    }
}
