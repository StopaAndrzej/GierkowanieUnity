using System;
using System.Collections.Generic;
using UnityEngine;

public class DummyTrainData : MonoBehaviour
{
    public List<DummyStation> stations = new List<DummyStation>();
    public float speed;
    public float notificationTreshold = 0.0f;
    public GameObject spawner;

    private void Update()
    {
        int i = 1;
        foreach(DummyStation station in stations)
        {
            foreach (DummyTrain train in station.trains)
            {
                bool wasAboveTreshold = (train.timeToSpawn > notificationTreshold);
                train.timeToSpawn -= Time.deltaTime;

                if (train.timeToSpawn <= notificationTreshold && wasAboveTreshold)
                {
                    spawner.GetComponent<TrainSpawner>().spawnTrain(i);
                    NotificationSystem.Notify("Train approaching", spawner.GetComponent<TrainSpawner>().spawnedTrain);
                }

                if (train.timeToSpawn <= 0)
                {
                    train.timeToSpawn = station.maxTime;
                }
            }
            i++;
        }
    }
    public void fillWithData()
    {
        stations.Clear();
        notificationTreshold = 0.0f;

        DummyTrain t1 = new DummyTrain();
        t1.timeToSpawn = 30;
        DummyTrain t2 = new DummyTrain();
        t2.timeToSpawn = 80;
        DummyStation s1 = new DummyStation();
        s1.maxTime = 120;
        s1.trains.Add(t1);
        s1.trains.Add(t2);

        DummyTrain t3 = new DummyTrain();
        t3.timeToSpawn = 100;
        DummyTrain t4 = new DummyTrain();
        t4.timeToSpawn = 115;
        DummyStation s2 = new DummyStation();
        s2.maxTime = 120;
        s2.trains.Add(t3);
        s2.trains.Add(t4);

        stations.Add(s1);
        stations.Add(s2);
    }
}

[Serializable]
public class DummyStation
{
    public List<DummyTrain> trains = new List<DummyTrain>();
    public float maxTime;
}

[Serializable]
public class DummyTrain
{
    public float timeToSpawn;
}
