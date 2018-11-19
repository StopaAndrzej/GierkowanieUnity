using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour {

    public GameObject target;
    public float time = 0;
    public float timeToFade = 3;

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(onClick);
    }

    public void onClick()
    {
        if (target != null)
        {
            GameObject.Find("Main Camera").GetComponent<CameraController>().followTarget(target);
            GameObject.Find("EventList").GetComponent<AddObjectToList>().removeFromList(gameObject);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
    }
}

