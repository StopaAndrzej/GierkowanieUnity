using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public TrainTrack previousNode;
    public TrainTrack nextNode1;
    public TrainTrack nextNode2;

    private void OnMouseDown()
    {
        Debug.Log(previousNode.nextTrack);
        Debug.Log(nextNode1);
        Debug.Log(nextNode2);

        if (previousNode.nextTrack == nextNode1)
        {
            previousNode.nextTrack = nextNode2;
        } else {
            previousNode.nextTrack = nextNode1;
        }

    }
}
