using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DispatcherPanel : MonoBehaviour {

    public GameObject panel;
    public GameObject dispatcher;
    public TextMeshProUGUI pracownicy;
    public Button truckButton;
    private int liczbaPracownikow;
    public float cd = 5f;

    // Use this for initialization
    void Start () {
        panel.SetActive(false);
        liczbaPracownikow = 0;

        truckButton.onClick.AddListener(() => spawnTruck());

    }
	
	// Update is called once per frame
	void Update () {
        cd -= Time.deltaTime;
        pracownicy.text = "";
        liczbaPracownikow = dispatcher.GetComponent<Dispatcher>().actuallNumberWorkers;
        pracownicy.text = liczbaPracownikow.ToString();
        pracownicy.text += "/56";

        if (liczbaPracownikow >= 3 && cd < 0)
        {
            truckButton.interactable = true;
            int numberOfTrucks = liczbaPracownikow / 3;
            truckButton.GetComponentInChildren<TextMeshProUGUI>().text = numberOfTrucks.ToString();
        } else
        {
            truckButton.interactable = false;
            truckButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        if(cd > 0)
        {
            truckButton.interactable = false;
        }
    }


    void OnMouseDown()
    {
        Debug.Log("Otworz panel depozytorni!");
        panel.SetActive(true);
    }

    private void spawnTruck()
    {
        dispatcher.GetComponent<Dispatcher>().actuallNumberWorkers -= 3;
        dispatcher.GetComponent<Dispatcher>().readyToDepartureTruck = true;
        cd = 5f;
    }
}
