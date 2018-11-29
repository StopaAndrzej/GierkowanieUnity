using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenuOptions : MonoBehaviour {


    public int id_Option;
    public GameObject option1;
    public GameObject minute;
    public GameObject hour;
    public GameObject ParentWithAnimations;
    public GameObject camera1;
    public GameObject reportsTester;

    // Use this for initialization
    void Start () {
        option1 = gameObject.transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        GetComponent<Image>().color = new Color32(104, 46, 46, 255);
        option1.GetComponent<Image>().color = new Color32(75, 14, 14, 255);
    }

    void OnMouseExit()
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        option1.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
    }

    void OnMouseDown()
    {
        if (id_Option == 1)
        {
            Debug.Log("nowa gra!");
            GameState.isStarted = true;
            minute.transform.localRotation= Quaternion.Euler(0, 90, 0);
            hour.transform.localRotation = Quaternion.Euler(0, 90, 115);
            ParentWithAnimations.GetComponent<PanelAnimationScript>().Animate();
            camera1.GetComponent<Transform>().transform.position = new Vector3(77, 352.4f, 140);
            camera1.GetComponent<Transform>().transform.localRotation = Quaternion.Euler(90f, 0, 0);
            camera1.GetComponent<CameraControll>().gameStarted = true;
            reportsTester.GetComponent<DummyTrainData>().fillWithData();
        }
    }
}
