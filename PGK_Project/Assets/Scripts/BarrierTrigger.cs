using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTrigger : MonoBehaviour {

    public bool isBarrierClosed = false;
    public GameObject barrierLights;
    public Material[] myMaterials = new Material[5];
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = anim.GetComponent<Animator>();
        //barrierLights.GetComponent<Renderer>().material = myMaterials[0];

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDown()
    {
        if(isBarrierClosed)
        {
            //barrierLights.GetComponent<Renderer>().material = myMaterials[1];
            isBarrierClosed = false;
            anim.enabled = true;
        } else
        {
           // barrierLights.GetComponent<Renderer>().material = myMaterials[0];
            isBarrierClosed = true;
            anim.SetTrigger("CloseBarrier");
        }
    }

    public void pauseAnimationEvent()
    {
        anim.enabled = false;
    }
}
