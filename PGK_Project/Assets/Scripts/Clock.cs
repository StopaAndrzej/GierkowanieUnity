using System.Collections;
using UnityEngine;
using System;
using System.Globalization;
using System.Collections.Generic;

public class Clock : MonoBehaviour {


    //connected objects
	[SerializeField]
	GameObject minutesHand;

	[SerializeField]
	GameObject hoursHand;



    private int timeBooster;
    private float playTime=0f;
    public int intPlayTime;

    //time parameters
    private int seconds;
    private int minutes;
    private int hours;
    private int days;
    private int endLevelTime;

    //spawner
    public GameObject trainSpawner;
    public List<GameObject> trainType;
    public List<GameObject> trains;




    //generate timetables
    public List<int> timetables;
    public int timetableTEST;
    public bool spawnTrainDelay;
    private int spawnTrainDelaySavedTime;

    private int i = 0;

    void Start()
    {
        timeBooster = 1;
        playTime = 300f;
        endLevelTime = 1260;

        timetables.Add(305);
        timetables.Add(306);
        timetables.Add(310);

        spawnTrainDelay = false;
        
        
    }


    //Random.Range(-0.5f, 0.5f)

    void Update()
    {
        UpdateTime();
        SpawnTrain();
        FinishLevel();
    }

    private void UpdateTime()
    {
        playTime += Time.deltaTime * timeBooster;
        intPlayTime = (int)playTime;
        minutes = intPlayTime % 60;
        hours = (intPlayTime / 60) % 24;

        float minutesDegree = (intPlayTime / 60f) * 360f;
        minutesHand.transform.localRotation = Quaternion.Euler(new Vector3(0, minutesDegree, 0));

        float hoursDegree = (intPlayTime / 720f) * 360f;
        hoursHand.transform.localRotation = Quaternion.Euler(new Vector3(0, hoursDegree, 0));

        if (Input.GetKey("space"))
            timeBooster = 5;
        else
            timeBooster = 1;
    }

     private void SpawnTrain()
    {
        foreach(int time in timetables)
        {
            if (intPlayTime == time && !spawnTrainDelay)
            {
                Debug.Log("TrainSpawned!");
                GameObject actualSpawnedTrain = Instantiate(trainType[0], trainSpawner.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                trains.Add(actualSpawnedTrain);
                spawnTrainDelay = true;
                spawnTrainDelaySavedTime = intPlayTime;
            }

            if (spawnTrainDelay == true && spawnTrainDelaySavedTime != intPlayTime)
            {
                spawnTrainDelay = false;
            }
        }

        //    //actualSpawnedObject.GetComponent<TrainMove>().whichWay = t.GetComponent<TrainTimeTable>().whichWay;
        //    //actualSpawnedObject.GetComponent<TrainMove>().whichPeron = t.GetComponent<TrainTimeTable>().whichPeron;
        //    //t.GetComponent<TrainTimeTable>().hour = -1;
    }

    private void FinishLevel()
    {
        if(intPlayTime>=endLevelTime)
        {
            Debug.Log("LevelComplited!");
        }
    }
}
