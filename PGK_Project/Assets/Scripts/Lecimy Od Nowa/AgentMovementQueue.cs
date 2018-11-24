using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovementQueue : MonoBehaviour {

    public Transform home;
    NavMeshAgent agent;
    private string nameOfPath;

    // Use this for initialization
    void Start () {
        nameOfPath = "CapsuleDestinationEntance";
        home = GameObject.Find(nameOfPath).transform;
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(home.position);
        agent.GetComponent<NavMeshAgent>().speed = 10f;
        //transform.localScale = new Vector3(transform.localScale.x * 3, transform.localScale.y * 4 + Random.Range(-0.1f, 0.1f), transform.localScale.z * 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
