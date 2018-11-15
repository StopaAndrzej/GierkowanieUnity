﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {



	public Transform[] path;
    public Transform currentPath;
    public float maxSteerAngle = 40f;
	public float moveSpeed = 0.8f;
    public float sensorLenght = 0.5f;
    public float frontSensorPos = 0.8f;

    private List<Transform> nodes;
	private int currentNode = 0;
    public int whichSpawn;

	void Start () {
        
        moveSpeed = 0.8f;
        int r = Random.Range(1, 3);

        currentPath = findClosestPath().transform;

        Transform[] pathTransforms = currentPath.GetComponentsInChildren<Transform> ();
		nodes = new List<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms [i] != currentPath.transform) {
				nodes.Add (pathTransforms [i]);
			}
		}
        //spawnPos = GameObject.FindGameObjectWithTag("CarSpawnPos").transform;
	}
	

	void FixedUpdate () {
		ApplySteer ();
		Drive ();
		CheckNodeDistance ();
	}

   
    
	private void ApplySteer(){

		Vector3 relativeVector = transform.InverseTransformPoint (nodes [currentNode].position);
		float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
	
		transform.Rotate (0, newSteer, 0);
	}

	private void Drive(){
		//GetComponent<Rigidbody> ().velocity = new Vector3 (0 , 0, moveSpeed);
		transform.position += transform.forward * moveSpeed;
	}

	private void CheckNodeDistance(){
		if(Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f){
			if(currentNode == nodes.Count - 1){
				currentNode = 0;
			}
			else{
				currentNode++;
			}

		}
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other);
        //moveSpeed = 0;
    }

    public GameObject findClosestPath()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("carPath");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
