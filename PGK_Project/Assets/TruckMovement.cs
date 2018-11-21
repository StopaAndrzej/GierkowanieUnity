using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour {

    public Transform currentPath;
    public float maxSteerAngle = 40f;
    public float moveSpeed = 0.2f;
    public GameObject model1;
    public List<Transform> nodes;
    public int currentNode = 0;

    void Start()
    {
        moveSpeed = 0.1f;
        Transform[] pathTransforms = currentPath.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != currentPath.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }


    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckNodeDistance();
    }



    private void ApplySteer()
    {

        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        transform.Rotate(0, newSteer, 0);
    }

    private void Drive()
    {
        transform.position += transform.forward * moveSpeed;
    }

    private void CheckNodeDistance()
    {

        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 1f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
                moveSpeed = 0;
            }
            else
            {
                currentNode++;
            }

        }
    }
}
