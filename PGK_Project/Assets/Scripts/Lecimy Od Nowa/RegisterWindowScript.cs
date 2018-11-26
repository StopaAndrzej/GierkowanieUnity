using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterWindowScript : MonoBehaviour {

    public Button exitButton;
    public Button plusButton;
    public Button minusButton;
    public Button normalButton;
    public TextMeshProUGUI priceText;


    // Use this for initialization
    void Start () {
        exitButton.onClick.AddListener(closePanel);
        plusButton.onClick.AddListener(delegate { setTicketPrice(GameState.ticketPrice + 1); });
        minusButton.onClick.AddListener(delegate { setTicketPrice(GameState.ticketPrice - 1); });
        normalButton.onClick.AddListener(delegate { setTicketPrice(GameState.normalTicketPrice); });
        setTicketPrice(GameState.ticketPrice);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Klik");
        }

    }

    private void closePanel()
    {
        gameObject.SetActive(false);
    }
    private void setTicketPrice(int price)
    {
        if(price > 0)
        {
            GameState.ticketPrice = price;
            priceText.SetText(price.ToString() + "$");
        }
    }
}
