using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainOption1 : MonoBehaviour {


    public bool enableToOpenTrain=false;
    public bool isOpen = false;
    public bool test = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(gameObject.GetComponentInParent<TrainMove>().isClicked == true)
        {
            enableToOpenTrain = true;
        }
        else
        {
            enableToOpenTrain = false;
        }
    }

    public void OnMouseDown()
    {
        if (enableToOpenTrain == true && isOpen == false)
        {
            test = true;
            isOpen = true;
            Debug.Log("OTWARTE!");
        }
        else if(enableToOpenTrain == true && isOpen == true)
        {
            test = false;
            isOpen = false;
            Debug.Log("ZAMKNIETE!");
        }
    }

    
}
