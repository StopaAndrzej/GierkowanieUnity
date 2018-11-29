using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainScript : MonoBehaviour {

    public Button exitButton;
    public Button overFillButton;
    public Button openButton;
    public TextMeshProUGUI text;
    public int capacity;
    public int actualCapacity;
    public Image box;
    public int maxCapacity;
    public bool onlyOnce;
    public bool isOpen;
    public int isReadyToGo;

    // Use this for initialization
    void Start () {
        isReadyToGo = 0;
        onlyOnce = false;
        isOpen = false;
        exitButton.onClick.AddListener(closePanel);
        overFillButton.onClick.AddListener(moreSize);
        openButton.onClick.AddListener(openTrain);
        actualCapacity =0;
        maxCapacity = 16;
    }
	
	// Update is called once per frame
	void Update () {
        text.SetText(capacity.ToString() + "/" + maxCapacity.ToString());
    }

    private void closePanel()
    {
        gameObject.SetActive(false);
    }

    private void moreSize()
    {
        if (!onlyOnce)
        {
            onlyOnce = true;
            maxCapacity += 8;
            text.SetText(actualCapacity.ToString() + "/" + maxCapacity.ToString());
            box.GetComponent<Image>().color = new Color32(236, 147, 137, 255);
        }
    }

    private void openTrain()
    {
        if (isOpen)
        {
            isReadyToGo++;
            openButton.GetComponent<Image>().color = new Color32(198, 145, 94,255);
            isOpen = false;

        }
        else
        {
            isReadyToGo++;
            openButton.GetComponent<Image>().color = new Color32(144, 197, 94, 255);
            isOpen = true;
        }
    }
}
