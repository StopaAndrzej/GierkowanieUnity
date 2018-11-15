using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour {

    public Transform home;
    NavMeshAgent agent;
    private string nameOfPath;



	// Use this for initialization
	void Start () {
       
        var randomInt = Random.Range(0, 6);
        nameOfPath = "CapsuleDestination" + randomInt.ToString();
        home = GameObject.Find(nameOfPath).transform;
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(home.position);
        agent.GetComponent<NavMeshAgent>().speed = 10 + Random.Range(-5f, 5f);
        transform.localScale = new Vector3(transform.localScale.x*4,transform.localScale.y * 4 + Random.Range(-0.5f, 0.5f),transform.localScale.z*4);
   
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
