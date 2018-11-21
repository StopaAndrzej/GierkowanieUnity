using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DispatcherPanel : MonoBehaviour {

    public GameObject panel;
    public GameObject dispatcher;
    public TextMeshProUGUI pracownicy;
    private int liczbaPracownikow;


    // Use this for initialization
    void Start () {
        panel.SetActive(false);
        liczbaPracownikow = 0;



    }
	
	// Update is called once per frame
	void Update () {
        //pracownicy.text = "";
        //liczbaPracownikow =dispatcher.GetComponent<Dispatcher>().actuallNumberWorkers;
        //pracownicy.text = liczbaPracownikow.ToString();
        //pracownicy.text += "/56";
    }


    void OnMouseDown()
    {
        Debug.Log("Otworz panel depozytorni!");
        panel.SetActive(true);
    }
}
