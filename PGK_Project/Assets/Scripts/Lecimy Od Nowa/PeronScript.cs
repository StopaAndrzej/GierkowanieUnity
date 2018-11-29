using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeronScript : MonoBehaviour {


    public GameObject peopleSpawner;
    public Button exitButton;
    public TextMeshProUGUI peopleCount;
    public int peopleOnPeron;

    // Use this for initialization
    void Start () {
        exitButton.onClick.AddListener(closePanel);
    }
	
	// Update is called once per frame
	void Update () {
        peopleOnPeron = peopleSpawner.GetComponent<PeopleSpawner1>().peopleNumber;
        peopleCount.SetText(peopleOnPeron + "/100");
	}

    private void closePanel()
    {
        gameObject.SetActive(false);
    }
}
