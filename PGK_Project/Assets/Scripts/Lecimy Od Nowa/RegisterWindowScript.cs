using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterWindowScript : MonoBehaviour {

    public GameObject exitButton;
    public GameObject plusButton;
    public GameObject minusButton;
    public TextMeshProUGUI price;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Klik");
        }

    }


    
}
