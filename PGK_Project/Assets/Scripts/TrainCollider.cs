﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCollider : MonoBehaviour
{

    public TrainMove thisTrain;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Train collided with " + other);

        if (other.transform.tag == "Train" )
        {
            TrainMove otherTrain = other.GetComponent<TrainMove>();
            if (otherTrain.speed == 0)
            {
                Debug.Log("Collision with train which stopped");
                thisTrain.lastSpeed = thisTrain.speed;
                thisTrain.speed = 0;
            }
            else
            {
                GameObject.Find("MainCamera").GetComponent<CameraController>().gameOver();
            }
        }

        if(other.transform.tag == "TrainCargo")
        {
            CargoMove otherTrain = other.GetComponent<CargoMove>();
            GameObject.Find("MainCamera").GetComponent<CameraController>().gameOver();
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Train")
        {
            Invoke("restartTrain", 1);
        }
    }
    private void restartTrain()
    {
            thisTrain.speed = thisTrain.lastSpeed;
    }
}
