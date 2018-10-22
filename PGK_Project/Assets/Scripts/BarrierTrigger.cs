using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTrigger : MonoBehaviour {



    public bool isBarrierClosed = false;
    public GameObject[] barrierLights;
    public GameObject[] baricades;
    public Material[] myMaterials = new Material[5];
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = anim.GetComponent<Animator>();
        foreach(GameObject t in barrierLights)
        {
            t.GetComponent<Renderer>().material = myMaterials[0];
        }
        foreach (GameObject x in baricades)
        {
            x.GetComponent<BoxCollider>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update () {
 

        if (isBarrierClosed == true)
        {
            foreach (GameObject t in barrierLights)
            {
                t.GetComponent<Renderer>().material = myMaterials[1];
            }

            
            
        }
        else if (isBarrierClosed == false)
        {
            foreach (GameObject t in barrierLights)
            {
                t.GetComponent<Renderer>().material = myMaterials[0];
            }
        }
	}

    private void OnMouseDown()
    {
        if(isBarrierClosed)
        {
            baricades[0].GetComponent<BoxCollider>().enabled = false;
            baricades[1].GetComponent<BoxCollider>().enabled = false;
            isBarrierClosed = false;
            anim.enabled = true;
           
        } else
        {
            baricades[0].GetComponent<BoxCollider>().enabled = true;
            baricades[1].GetComponent<BoxCollider>().enabled = true;
            isBarrierClosed = true;
            anim.SetTrigger("CloseBarrier");
            
        }
    }

    public void pauseAnimationEvent()
    {
        anim.enabled = false;
    }
}
