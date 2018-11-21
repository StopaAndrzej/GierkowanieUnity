using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSteering : MonoBehaviour {

    public Animator anim;

    public GameObject changeSteeringImported;
    public bool isClicked;

    void Start()
    {
        isClicked = false;
        anim = GetComponent<Animator>();
        changeSteeringImported.GetComponent<BoxCollider>().enabled = false;
    }

    void OnMouseDown()
    {
        if (!isClicked)
        {
            anim.Play("LeverRight");
            isClicked = true;
            changeSteeringImported.GetComponent<BoxCollider>().enabled = true;
        }
        else if (isClicked)
        {
            anim.Play("LeverLeft");
            isClicked = false;
            changeSteeringImported.GetComponent<BoxCollider>().enabled = false;
        }

    }


}
