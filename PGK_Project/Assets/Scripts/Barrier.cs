﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    private void OnMouseDown()
    {
        gameObject.GetComponentInParent<BarrierTrigger>().triggerBarrier();
    }
}
