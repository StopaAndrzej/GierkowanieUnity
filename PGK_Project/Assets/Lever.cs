using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public TrainTrack previousNode;
    public TrainTrack nextNode1;
    public TrainTrack nextNode2;
    public GameObject arrow;

    private void OnMouseDown()
    {

        if (previousNode.nextTrack == nextNode1)
        {
            arrow.GetComponent<SteeringArrow>().change();
            previousNode.nextTrack = nextNode2;
        } else {
            arrow.GetComponent<SteeringArrow>().change();
            previousNode.nextTrack = nextNode1;
        }
        Debug.Log(previousNode.nextTrack);

    }
}
