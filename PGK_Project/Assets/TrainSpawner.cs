using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour {

    public GameObject passangerTrainPrefab;
    public float timer = 0;
    public float spawnTime = 5f;
    public GameObject spawnedTrain;
    public GameObject trainTracks;
    public LineRenderer lineRendererGreen;
    public LineRenderer lineRendererRed;
    public float timeToNextSpawn = 10f;
    public int peron = 1;

    private void Start()
    {
        peron = Random.Range(1, 3);
        timeToNextSpawn = 10f;
    }
    private void FixedUpdate()
    {
        //timeToNextSpawn -= Time.deltaTime;
        //if(timeToNextSpawn <= 0)
        //{
        //    spawnedTrain = spawnPassangerTrain(passangerTrainPrefab);

        //    if (peron == 1)
        //    {
        //        TrainTrack[] properPath = trainTracks.GetComponent<TrainPath>().peron1Path;
        //        spawnedTrain.GetComponent<TrainMovement>().setPath(properPath, lineRendererGreen, lineRendererRed);
        //    } else
        //    {
        //        TrainTrack[] properPath = trainTracks.GetComponent<TrainPath>().peron2Path;
        //        spawnedTrain.GetComponent<TrainMovement>().setPath(properPath, lineRendererGreen, lineRendererRed);
        //    }

        //    timeToNextSpawn = 10f;
        //    peron = Random.Range(1, 3);
        //}
    }

    public GameObject spawnPassangerTrain(GameObject prefab)
    {
        return Instantiate(prefab, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }

    public void spawnTrain(int peron)
    {
        spawnedTrain = spawnPassangerTrain(passangerTrainPrefab);
        if (peron == 1)
        {
            TrainTrack[] properPath = trainTracks.GetComponent<TrainPath>().peron1Path;
            spawnedTrain.GetComponent<TrainMovement>().setPath(properPath);
        }
        else
        {
            TrainTrack[] properPath = trainTracks.GetComponent<TrainPath>().peron2Path;
            spawnedTrain.GetComponent<TrainMovement>().setPath(properPath);
        }
    }
}
