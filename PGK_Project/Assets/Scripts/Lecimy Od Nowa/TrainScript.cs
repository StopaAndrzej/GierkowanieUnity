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
    public int actualCapacity;
    public Image box;
    public int maxCapacity;
    public bool onlyOnce;
    public bool isOpened;
    public int isReadyToGo;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(true);
        isReadyToGo = 0;
        onlyOnce = false;
        exitButton.onClick.AddListener(closePanel);
        overFillButton.onClick.AddListener(moreSize);
        openButton.onClick.AddListener(openTrain);

    }
	
    void Update()
    {
        text.SetText(actualCapacity.ToString() + "/" + maxCapacity.ToString());
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
        if (isOpened)
        {
            isReadyToGo++;
            openButton.GetComponent<Image>().color = new Color32(198, 145, 94,255);
            isOpened = false;

        }
        else
        {
            isReadyToGo++;
            openButton.GetComponent<Image>().color = new Color32(144, 197, 94, 255);
            isOpened = true;
        }
    }
}
