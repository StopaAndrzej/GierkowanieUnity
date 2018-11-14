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

    public void OnMouseDown()
    {
        if (!isExtended)
        {
            anim.Play("ExtendTrainLabel");
            isExtended = true;
        }
        if (isExtended)
        {
            anim.Play("FoldTrainLabel");
            isExtended = false;
        }
    }
    
    
}
