using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour {

	public GameObject[] wayPoints;
	int currentPoint;
	public float rotationSpeed;
	public float speed;
	float wayPointRadius = 0.01f;

	void Update(){
		if(Vector3.Distance(wayPoints[currentPoint].transform.position, transform.position) < wayPointRadius){
			currentPoint++;
			if(currentPoint >= wayPoints.Length){
				currentPoint =0;
			}
		}
		
		transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentPoint].transform.position, Time.deltaTime*speed);
		var rotation = Quaternion.LookRotation (wayPoints [currentPoint].transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);
	}

}
