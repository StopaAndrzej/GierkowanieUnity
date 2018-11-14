using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTrack : MonoBehaviour
{

    public Texture2D toolCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Cursor defaultC;
    public ProgressBar progressBar;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(toolCursor, hotSpot, cursorMode);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }
    private void OnMouseDown()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
        progressBar.startProgress();
    }
    private void Update()
    {
        if (progressBar.isComplete)
        {
            gameObject.GetComponentInParent<TrainTrack>().broken = false;
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }
}
