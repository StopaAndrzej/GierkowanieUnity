using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{

    public GameObject[] trainTracks = null;
    public int timeToNextEvent = 20;
    public float time = 0;

    void Start()
    {
        trainTracks = GameObject.FindGameObjectsWithTag("Repairable");
    }

    void Update()
    {

        time += Time.deltaTime;
        if (time > timeToNextEvent)
        {
            GameObject o = randomTrackPos();
            o.GetComponent<TrainTrack>().broken = true;
            time = 0;
        }
    }

    private GameObject randomTrackPos()
    {
        int trackNumber = Random.Range(0, trainTracks.Length);
        GameObject o = trainTracks[trackNumber].gameObject;
        return o;
    }
}
