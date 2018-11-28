using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {



	public Transform[] path;
    public Transform currentPath;
    public float maxSteerAngle = 40f;
	public float moveSpeed = 1f;
    public GameObject model1;
    public GameObject model2;
    public GameObject[] gos;
    public List<Transform> nodes;
	public int currentNode = 0;
    public int whichSpawn;
    public GameObject dispatcher; //link do dyspozytornik ktora zlicza pojazdy i na jej podstawie wydaje ciezarowki

    void Start () {
        
        moveSpeed = 1f;


        currentPath = findClosestSpawn().transform;
        dispatcher = GameObject.Find("Dispatcher");//przypisanie dyspozytorni ciezarowek
        Transform[] pathTransforms = currentPath.GetComponentsInChildren<Transform> ();
		nodes = new List<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms [i] != currentPath.transform) {
				nodes.Add (pathTransforms [i]);
			}
		}
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

		if(Vector3.Distance(transform.position, nodes[currentNode].position) < 10f){
			if(currentNode == nodes.Count - 1){
				currentNode = 0;
                Destroy(gameObject);
                //dispatcher.GetComponent<Dispatcher>().actuallNumberWorkers++;
            }
            else
            {
				currentNode++;
			}

		}
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other);
        //moveSpeed = 0;
    }

    public GameObject findClosestSpawn()
    {
        gos = GameObject.FindGameObjectsWithTag("carPath");
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
