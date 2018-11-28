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


    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            timer = 0;
            spawnedTrain = spawnPassangerTrain(passangerTrainPrefab);

            int r = Random.Range(1, 3);
            if (r == 1)
            {
                TrainTrack[] properPath = trainTracks.GetComponent<TrainPath>().peron1Path;
                spawnedTrain.GetComponent<TrainMovement>().setPath(properPath, lineRendererGreen, lineRendererRed);
            } else
            {
                TrainTrack[] properPath = trainTracks.GetComponent<TrainPath>().peron2Path;
                spawnedTrain.GetComponent<TrainMovement>().setPath(properPath, lineRendererGreen, lineRendererRed);
            }
        }
    }

    public GameObject spawnPassangerTrain(GameObject prefab)
    {
        return Instantiate(prefab, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }
}
