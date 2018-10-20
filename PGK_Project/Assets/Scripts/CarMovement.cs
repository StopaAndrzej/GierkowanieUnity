using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

	public Transform path;
	public float maxSteerAngle = 40f;
	public float moveSpeed;
    public double timer = 0.0;
    public Transform spawnPos;


    private List<Transform> nodes;
	private int currentNode = 0;

	void Start () {
		Transform[] pathTransforms = path.GetComponentsInChildren<Transform> ();
		nodes = new List<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms [i] != path.transform) {
				nodes.Add (pathTransforms [i]);
			}
		}
        spawnPos = GameObject.FindGameObjectWithTag("CarSpawnPos").transform;
	}
	

	void FixedUpdate () {
		ApplySteer ();
		Drive ();
		CheckNodeDistance ();
	}

	private void ApplySteer(){

		Vector3 relativeVector = transform.InverseTransformPoint (nodes [currentNode].position);
		float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
		print (newSteer);
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

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1000)
        {
            spawnCar();
            timer = 0.0;
        }

    }

    void spawnCar()
    {
        Instantiate(gameObject, spawnPos);
    }
}
