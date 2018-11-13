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
    private bool spawnTrainDelay;
    private int spawnTrainDelaySavedTime;

    private int avaivableTrains;
    private int generateListinTime;


    void Start()
    {
        timeBooster = 1;
        playTime = 300f;
        endLevelTime = 1260;
        spawnTrainDelay = false;
        generateListinTime = 0;


    }

    void Update()
    {
        UpdateTime();
        TimetablesGenerator();
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
        minutesHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -minutesDegree));

        float hoursDegree = (intPlayTime / 720f) * 360f;
        hoursHand.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -hoursDegree));

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
                ShowTimeTablesGUI();
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

    private void TimetablesGenerator()
    {
        if (intPlayTime >= 300 && intPlayTime < 420)//5->7
        {
            generateListinTime++;
            if (generateListinTime == 1)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(1, 2));
                Debug.Log(generateListinTime + " ile: " + avaivableTrains);
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(300, 420));
                }
            }
        }
        else if (intPlayTime >= 420 && intPlayTime < 510)//7->8.30
        {
            generateListinTime++;
            if (generateListinTime == 2)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(2, 4));
                Debug.Log(generateListinTime + " ile: " + avaivableTrains);
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(420, 510));
                }
            }
        }
        else if (intPlayTime >= 510 && intPlayTime < 600)//8.30->10
        {
            generateListinTime++;
            if (generateListinTime == 2)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(4, 6));
                Debug.Log(generateListinTime + " ile: " + avaivableTrains);
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(510, 600));
                }
            }

        }
        else if (intPlayTime >= 600 && intPlayTime < 720)//10->12
        {
            generateListinTime++;
            if (generateListinTime == 2)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(1, 3));
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(600, 720));
                }
            }

        }
        else if (intPlayTime >= 720 && intPlayTime < 840)//12->14
        {
            generateListinTime++;
            if (generateListinTime == 2)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(3, 5));
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(720, 840));
                }
            }

        }
        else if (intPlayTime >= 840 && intPlayTime < 960)//14->16
        {
            generateListinTime++;
            if (generateListinTime == 2)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(6, 8));
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(840, 960));
                }
            }

        }
        else if (intPlayTime >= 960 && intPlayTime < 1080)//16->18
        {
            generateListinTime++;
            if (generateListinTime == 2)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(6, 10));
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(960, 1080));
                }
            }

        }
        else if (intPlayTime >= 1080 && intPlayTime < 1200)//20->22
        {
            generateListinTime++;
            if (generateListinTime == 2)
            {
                avaivableTrains = (int)(UnityEngine.Random.Range(4, 6));
                for (int i = 0; i <= avaivableTrains; i++)
                {
                    timetables.Add(UnityEngine.Random.Range(1080, 1200));
                }
            }

        }
    }

    private void ShowTimeTablesGUI()
    {
        GUI.Box(new Rect(0, 0, 80, 20), "TEXT");
    }

    private void FinishLevel()
    {
        if(intPlayTime>=endLevelTime)
        {
            Debug.Log("LevelComplited!");
        }
    }

   
    
}
