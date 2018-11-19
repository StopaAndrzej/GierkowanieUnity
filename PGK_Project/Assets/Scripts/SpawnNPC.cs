using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour {

    public List<GameObject> spawnPoints;
    public GameObject objectToSpawn;
    public GameObject positionSpawn;
    public GameObject folderToHoldCopies;

    private float timer = 0.0f;

    void Start()
    {
        foreach(Transform spawn in transform)
        {
            spawnPoints.Add(spawn.gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            int index=UnityEngine.Random.Range(0, spawnPoints.Count + 1);
            Debug.Log(index);
            positionSpawn = spawnPoints[index];
            Instantiate(objectToSpawn, positionSpawn.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f), folderToHoldCopies.transform);
            timer = 0.0f;
        }
    }


}
