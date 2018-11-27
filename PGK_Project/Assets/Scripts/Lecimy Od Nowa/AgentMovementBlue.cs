using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovementBlue : MonoBehaviour {

    public Transform home;
    NavMeshAgent agent;
    private string nameOfPath;



    // Use this for initialization
    void Start()
    {
        var randomInt = Random.Range(0, 6);
        nameOfPath = "CapsuleDestinationB" + randomInt.ToString();
        home = GameObject.Find(nameOfPath).transform;
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(home.position);
        agent.GetComponent<NavMeshAgent>().speed = 10 + Random.Range(-3f, 3f);
        transform.localScale = new Vector3(transform.localScale.x * 3, transform.localScale.y * 4 + Random.Range(-0.1f, 0.1f), transform.localScale.z * 3);

    }



    // Update is called once per frame
    void Update()
    {

    }


}
