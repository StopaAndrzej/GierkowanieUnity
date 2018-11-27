using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTicket : MonoBehaviour {

    public int money;
    public int ticketPrice;
    public int normalPrice;
    public int demand;
    public float timer;
    public int whichPeron;

    public List<GameObject> npcReadyToBuyTicket;
    public GameObject npcToDestroy;
    public List<GameObject> perons;

    // Use this for initialization
    void Start () {
        timer = 0;
        money = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        normalPrice = GameState.normalTicketPrice;
        ticketPrice = GameState.ticketPrice;
        demand = ticketPrice- normalPrice;
        if (timer > 2+ demand)
        {
            if (npcReadyToBuyTicket.Count > 0)
            {
                npcToDestroy= npcReadyToBuyTicket[0];
                npcReadyToBuyTicket.RemoveAt(0);
                Destroy(npcToDestroy);
                Debug.Log("Ticket bought!");
                money += ticketPrice;
                whichPeron = Random.Range(0, 2);
                perons[whichPeron].GetComponent<PeopleSpawner1>().SpawnOnPeron();
            }
            timer = 0;
        }
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "crowd")
        {
            npcReadyToBuyTicket.Add(other.gameObject);
        }
    }
}
