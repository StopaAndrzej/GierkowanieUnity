using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimationScript : MonoBehaviour {


    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

    public void Animate()
    {
        anim.Play("HideMenuPanel");
    }
}
