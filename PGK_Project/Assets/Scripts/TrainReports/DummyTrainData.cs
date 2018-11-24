using System;
using System.Collections.Generic;
using UnityEngine;

public class DummyTrainData : MonoBehaviour
{
    public List<DummyStation> stations = new List<DummyStation>();
    public float speed;
    public float notificationTreshold = 5.0f;

    private void Update()
    {
        foreach(DummyStation station in stations)
        {
            foreach (DummyTrain train in station.trains)
            {
                bool wasAboveTreshold = (train.distance > notificationTreshold);
                train.distance -= speed * Time.deltaTime;

                if (train.distance <= notificationTreshold && wasAboveTreshold)
                {
                    NotificationSystem.Notify("Train approaching", null);
                }

                if (train.distance <= 0)
                {
                    train.distance = station.maxDistance;
                }
            }
        }
    }
}

[Serializable]
public class DummyStation
{
    public List<DummyTrain> trains = new List<DummyTrain>();
    public float maxDistance;
}

[Serializable]
public class DummyTrain
{
    public float distance;
}