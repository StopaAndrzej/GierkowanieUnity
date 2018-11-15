using System.Collections;
using UnityEngine;

public class SelectedFlash : MonoBehaviour {

    public GameObject selectedObject;
    Renderer renderer;
    Material materialCopy;
    Color initialColor;
    public int red;
    public int green;
    public int blue;
    public bool lookingAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;
    private void Start()
    {
        renderer = selectedObject.GetComponent<Renderer>();
        materialCopy = new Material(renderer.material);
        initialColor = materialCopy.color;
        renderer.material = materialCopy;
    }

    // Update is called once per frame
    void Update ()
    {
		if (lookingAtObject == true)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
        }
	}

    void OnMouseOver()
    {
        lookingAtObject = true;
        if (startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
    }

    void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = initialColor;
    }

    IEnumerator FlashObject()
    {
        while(lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.05f);
            if(flashingIn == true)
            {
                if(red <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    red -= 25;
                }
            }

            if(flashingIn == false)
            {
                if(red >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    red += 25;
                }
            }
        }
    }
}
