using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour {

    public float maxSteerAngle = 40f;
    public float moveSpeed = 1f;
    public TrainTrack currentNode;
    public TrainTrack[] properPath;
    public TrainTrack[] currentPath;
    public List<TrainTrack> nodesToTarget;
    public List<TrainTrack> wrongNodes;
    public bool isTrainFocused = false;
    public GameObject destination;
    public GameObject pos;

    private LineRenderer greenLineRenderer = null;
    private LineRenderer redLineRenderer = null;

    public bool readyToGo;


    void Start()
    {
        readyToGo = false;
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            isTrainFocused = false;
        }
        try
        {
            ApplySteer();
            Drive();
            CheckNodeDistance();
            currentPath = findCurrentPath();    
            updatePaths(); ///nodesToTarget and wrongNodes used to draw lines 
        } catch (System.Exception e) { }

        if (isTrainFocused)
        {
            drawProperPath(nodesToTarget.ToArray(), greenLineRenderer);
            drawProperPath(wrongNodes.ToArray(), redLineRenderer);
        } else
        {
            greenLineRenderer.positionCount = 0;
            redLineRenderer.positionCount = 0;
        }
    }



    private void ApplySteer()
    {

        Vector3 relativeVector = transform.InverseTransformPoint(currentNode.transform.position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        transform.Rotate(0, newSteer, 0);
    }

    private void Drive()
    {
        transform.position += transform.forward * moveSpeed;
    }

    private void CheckNodeDistance()
    {
        if (Vector3.Distance(transform.position, currentNode.transform.position) < 40f)
        {
            currentNode = currentNode.nextTrack;
        }
    }

    public TrainTrack[] findCurrentPath()
    {
        List<TrainTrack> nodeList = new List<TrainTrack>();
        TrainTrack node = currentNode;
        nodeList.Add(node);

        while(node.nextTrack != null)
        {
            node = node.nextTrack;
            nodeList.Add(node);
        }
        return nodeList.ToArray();
    }

    public void drawProperPath(TrainTrack[] nodesProvided, LineRenderer lineRenderer)
    {
        List<Transform> nodes = new List<Transform>();

        foreach (TrainTrack t in nodesProvided)
        {
            nodes.Add(t.transform);
        }

        int j = 0;
        if(wrongNodes.Count == 0)
        {
            j = 1;
        }
        lineRenderer.positionCount = nodes.Count + j;
        if (wrongNodes.Count == 0)
        {
            lineRenderer.SetPosition(0, transform.position);
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
             currentNode.y += 10f;
            lineRenderer.SetPosition(i + j, currentNode);
        }
    }

    public void updatePaths()
    {

        if (nodesToTarget.Contains(currentNode) && nodesToTarget.Contains(currentNode.nextTrack))
        {
            nodesToTarget.Remove(currentNode);
        } else
        {
            if (!wrongNodes.Contains(currentNode) && !nodesToTarget.Contains(currentNode.nextTrack))
            {
                wrongNodes.Add(currentNode);
            }
            if (!wrongNodes.Contains(currentNode) && !(new List<TrainTrack>(properPath).Contains(currentNode)))
            {
                wrongNodes.Add(currentNode);
            }
        }
        
    }

    private void OnMouseDown()
    {
        isTrainFocused = true;
    }

    public void setPath(TrainTrack[] path, LineRenderer lineRendererGreen, LineRenderer lineRendererRed)
    {
        properPath = path;
        nodesToTarget = new List<TrainTrack>(properPath);
        greenLineRenderer = Instantiate(lineRendererGreen);
        redLineRenderer = Instantiate(lineRendererRed);
        greenLineRenderer.positionCount = 0;
        redLineRenderer.positionCount = 0;
        Debug.Log(pos);

        pos = properPath[properPath.Length - 1].gameObject;
        GameObject dest = Instantiate(destination, pos.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        currentNode = properPath[0];
    }
}
