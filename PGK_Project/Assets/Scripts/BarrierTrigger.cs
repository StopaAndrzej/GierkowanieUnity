using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTrigger : MonoBehaviour {



    public bool isBarrierClosed = false;
    public double clickDelay = 0;
    public GameObject[] barrierLights;
    public GameObject baricade1;
    public GameObject baricade2;
    public Material[] myMaterials = new Material[5];
    public Animator anim;

	// Use this for initialization
	void Start () {

        baricade1 = GameObject.Find("BarrierTriggerCube1");
        baricade2 = GameObject.Find("BarrierTriggerCube2");
        anim = anim.GetComponent<Animator>();
        foreach(GameObject t in barrierLights)
        {
            t.GetComponent<Renderer>().material = myMaterials[0];
        }
        //foreach (GameObject x in baricades)
        //{
            baricade1.GetComponent<BoxCollider>().enabled = false;
            baricade2.GetComponent<BoxCollider>().enabled = false;
        //}

    }

    // Update is called once per frame
    void FixedUpdate () {
        clickDelay += Time.deltaTime;

        if (isBarrierClosed == true && clickDelay >= 1.0f)
        {
            foreach (GameObject t in barrierLights)
            {
                t.GetComponent<Renderer>().material = myMaterials[1];
            }
            
        }
        else if (isBarrierClosed == false && clickDelay >= 1.0f)
        {
            foreach (GameObject t in barrierLights)
            {
                t.GetComponent<Renderer>().material = myMaterials[0];
            }
           
        }
	}

    private void OnMouseDown()
    {
        if(isBarrierClosed && clickDelay >= 5.0f)
        {
            clickDelay = 0;
            baricade1.GetComponent<BoxCollider>().enabled = false;
            baricade2.GetComponent<BoxCollider>().enabled = false;
            //baricades[1].GetComponent<BoxCollider>().enabled = false;
            isBarrierClosed = false;
            anim.enabled = true;
           


        } else if(!isBarrierClosed && clickDelay >= 5.0f)
        {
            clickDelay = 0;
            baricade1.GetComponent<BoxCollider>().enabled = true;
            baricade2.GetComponent<BoxCollider>().enabled = true;
            //baricades[1].GetComponent<BoxCollider>().enabled = true;
            isBarrierClosed = true;
            anim.SetTrigger("CloseBarrier");
            

        }
    }

    public void pauseAnimationEvent()
    {
        anim.enabled = false;
    }
}
