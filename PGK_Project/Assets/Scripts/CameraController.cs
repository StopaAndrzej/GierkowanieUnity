using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public float turbo;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float scrollSpeed = 10f;
    public float minY = 5f;
    public float maxY = 20f;
    public bool isGameOver = false;
    public GameObject gameOverText;

    private void Start()
    {
        turbo = 1.0f;
        isGameOver = false;
    }

    void Update() {
        if (!isGameOver)
        {

        Vector3 pos = transform.position;
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                turbo = 3.0f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                turbo = 1.0f;
            }
            if (Input.GetKey("w") ) 
            {
                pos.x += panSpeed * Time.deltaTime*turbo;
            }

            if (Input.GetKey("s") )
            {
                pos.x -= panSpeed * Time.deltaTime * turbo;
            }

            if (Input.GetKey("d") )
            {
                pos.z -= panSpeed * Time.deltaTime * turbo;
            }

            if (Input.GetKey("a") )
            {
                pos.z += panSpeed * Time.deltaTime * turbo;
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
        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }
}
