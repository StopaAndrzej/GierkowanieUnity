using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    private Animator animator;
    private bool closed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (!closed)
        {
            animator.SetTrigger("CloseBarrier");
            closed = true;
        } else
        {
            animator.enabled = true;
            closed = false;
        }
    }

    private void pauseAnimationEvent()
    {
        animator.enabled = false;
        closed = true;
    }

}
