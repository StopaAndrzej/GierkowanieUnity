﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Collections.Generic;
using TMPro;

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
    public List<int> typeOfTrain;
    private bool spawnTrainDelay;
    private int spawnTrainDelaySavedTime;

    private int avaivableTrains;
    private int cargoLimitControll;

    //trains banner
    public List<Sprite> icons;
    public GameObject bannerSlots;
    public List<SpriteRenderer> sprites;

    //trains banner timetables
    public GameObject bannerTimeSlots;                      //SPRAWDZIC
    public List<TextMeshProUGUI> times;

    void Start()
    {
        foreach (Transform child in bannerSlots.transform)
        {
            sprites.Add(child.GetComponent<SpriteRenderer>());
        }

        foreach (Transform child1 in bannerTimeSlots.transform)
        {
            times.Add(child1.GetComponent<TextMeshProUGUI>());             //SPRAWDZIC
        }

        timeBooster = 1;
        playTime = 300f;
        endLevelTime = 1260;
        spawnTrainDelay = false;
        TrainTimeTablesGenerator();
        TrainTypesGenerator();
    }

    void Update()
    {
        UpdateTime();
        DisplayTrainTimeTable();
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

        if (Input.GetKeyDown(KeyCode.Space))
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
                GameObject actualSpawnedTrain = Instantiate(trainType[0], trainSpawner.transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
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

    private void TrainTimeTablesGenerator()
    {
        //5->7
        avaivableTrains = (int)(UnityEngine.Random.Range(3, 5));
        for(int i=0; i<avaivableTrains; i++)
        {
            timetables.Add(UnityEngine.Random.Range(330, 420));

        }


        //7->9.30
        avaivableTrains = (int)(UnityEngine.Random.Range(7, 9));
        for (int i = 0; i < avaivableTrains; i++)
        {
            timetables.Add(UnityEngine.Random.Range(420, 570));
 
        }

        timetables.Sort();
    }

    private void TrainTypesGenerator()
    {
        foreach(int i in timetables)
        {
            if (i < 420)
            {
                typeOfTrain.Add(0); //5->7 tylko osobowe
            }
            else
            {
                typeOfTrain.Add(UnityEngine.Random.Range(0, 2)); //po 7 moga byc towarowe
            }
            
        }
    }

    private void DisplayTrainTimeTable()
    {
        for(int i=0; i<sprites.Count; i++)
        {
            sprites[i].sprite = icons[typeOfTrain[i]];
            string convertToString=null;
            if ((timetables[i] / 60) < 10)
            {
                convertToString += "0";
            }
            convertToString += (timetables[i] / 60).ToString()+":";
            if ((timetables[i] % 60) < 10)
            {
                convertToString += "0";
            }
            convertToString += (timetables[i]%60).ToString();
            times[i].text = convertToString;
        }
    }



    private void FinishLevel()
    {
        if(intPlayTime>=endLevelTime)
        {
            Debug.Log("LevelComplited!");
        }
    }

   
    
}
