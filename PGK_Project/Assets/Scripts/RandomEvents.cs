//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RandomEvents : MonoBehaviour {

//    public GameObject[] trainTracks = null;
//    public int timeToNextEvent = 10;
//    public float time = 0;

//    void Start () {
//        trainTracks = GameObject.FindGameObjectsWithTag("Repairable");
//    }
	
//	void Update () {

//        time += Time.deltaTime;
//        if(time > timeToNextEvent)
//        {
//            GameObject o = randomTrackPos();
//            pos = o.transform.position;
//            //GameObject cube = Instantiate(cubeToTrack, pos, Quaternion.identity);
//            o.GetComponent<TrainTrack>().broken = true;

//            pos.x = pos.x - 10;
//            Debug.Log("camPos " + transform.position);
//        }
//    }

//    private GameObject randomTrackPos()
//    {
//        int trackNumber = Random.Range(0, 1);
//        GameObject o = trackGameObjects[trackNumber].gameObject;
//        return o;
//    }
//}
