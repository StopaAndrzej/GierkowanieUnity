using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCHuman : MonoBehaviour {

    public Transform home;
    NavMeshAgent agent;
    private string nameOfPath;

    public int i=0;

    // Use this for initialization
    void Start () {
        var randomInt = Random.Range(0, 6);
        nameOfPath = "CheckPoint" +i;
        home = GameObject.Find(nameOfPath).transform;
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(home.position);
        agent.GetComponent<NavMeshAgent>().speed = 1 + Random.Range(-0.5f, 0.5f);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + Random.Range(-0.02f, 0.02f), transform.localScale.z);
    }
	
	// Update is called once per frame
	void Update () {
        nameOfPath = "CheckPoint" + i;
        home = GameObject.Find(nameOfPath).transform;
        agent.SetDestination(home.position);
    }
}
