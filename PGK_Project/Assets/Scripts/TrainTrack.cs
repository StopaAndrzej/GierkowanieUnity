using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTrack : MonoBehaviour
{

    public bool broken = false;
    public GameObject fixedTrack;
    public GameObject brokenTrack;
    public Texture2D toolCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Cursor defaultC;

    // Use this for initialization
    void Start()
    {

        fixedTrack.SetActive(true);
        brokenTrack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (broken)
        {
            brokenTrack.SetActive(true);
            fixedTrack.SetActive(false);
        }
        else
        {
            brokenTrack.SetActive(false);
            fixedTrack.SetActive(true);
        }
    }

    private void OnMouseEnter()
    {
        if (broken) Cursor.SetCursor(toolCursor, hotSpot, cursorMode);
    }
    private void OnMouseExit()
    {
        if (broken) Cursor.SetCursor(null, hotSpot, cursorMode);
    }
    private void OnMouseDown()
    {
        if (broken)
        {
            broken = false;
            Cursor.SetCursor(null, hotSpot, cursorMode);
            fixedTrack.SetActive(true);
        }
    }
}
