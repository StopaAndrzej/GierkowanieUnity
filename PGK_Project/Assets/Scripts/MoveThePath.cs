using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThePath : MonoBehaviour {

	public List<FollowThePath> pathsToFollow;
	public FollowThePath pathToFollow;
	public int currentWayPointID = 0;
	public float speed;
	private float reachDistance = 0.05f;
	public float rotationSpeed = 5.0f;
	public string pathName;

	Vector3 last_position;
	Vector3 current_position;

	void Start () {
		//pathToFollow = GameObject.Find (pathName).GetComponent<FollowThePath> ();
		pathToFollow = pathsToFollow[0]. GetComponent<FollowThePath>();
		last_position = transform.position;

	}

	void Update () {
		float distance = Vector3.Distance (pathToFollow.path_objs [currentWayPointID].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, pathToFollow.path_objs [currentWayPointID].position, Time.deltaTime * speed);

		var rotation = Quaternion.LookRotation (pathToFollow.path_objs [currentWayPointID].position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);

		if (distance <= reachDistance) {
			currentWayPointID++;
		}
		if (currentWayPointID >= pathToFollow.path_objs.Count) {
			currentWayPointID = 0;
		}
	}



}
