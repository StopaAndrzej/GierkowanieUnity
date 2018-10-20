using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTrigger : MonoBehaviour {

    public bool isBarrierClosed = false;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if(isBarrierClosed)
        {
            isBarrierClosed = false;
            anim.enabled = true;
        } else
        {
            isBarrierClosed = true;
            anim.SetTrigger("CloseBarrier");
        }
    }

    public void pauseAnimationEvent()
    {
        anim.enabled = false;
    }
}
