using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelTrains : MonoBehaviour
{
    public Animator anim;
    private bool isExtended;

    void Start()
    {
        isExtended = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isExtended )
        {
            anim.Play("ExtendTrainLabel");
            isExtended = true;
        }
        if(Input.GetMouseButtonDown(0) && isExtended)
        {
            anim.Play("FoldTrainLabel");
            isExtended=false;
        }
    }
}
