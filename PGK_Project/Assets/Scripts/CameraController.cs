using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float scrollSpeed = 10f;
    public float minY = 5f;
    public float maxY = 20f;
    public bool isGameOver = false;

    private void Start()
    {
        isGameOver = false;
    }

    void Update() {
        if (!isGameOver)
        {

        Vector3 pos = transform.position;

        if (Input.GetKey("w") ) 
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") )
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") )
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") )
        {
            pos.z += panSpeed * Time.deltaTime;
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime *100f;
        

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        pos.y = Mathf.Clamp(pos.y, minY, maxY);


        transform.position = pos;
        }
	}
    public void gameOver()
    {
        isGameOver = true;
        GameObject.Find("GameOverText").GetComponent<Renderer>().enabled = true;
    }
}
