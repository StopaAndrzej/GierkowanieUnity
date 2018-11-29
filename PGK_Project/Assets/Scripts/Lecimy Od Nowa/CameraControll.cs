using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {



    public float panSpeed = 20f;
    public float turbo;
    public bool isGameOver = false;

    public float minY = 5f;
    public float maxY = 20f;
    public float scrollSpeed = 10f;
    public Vector2 panLimit;
    public bool gameStarted;
    public int view;
    public bool isFolowingTarget;

    public Quaternion target;

    private GameObject targetToFollow;
    // Use this for initialization
    void Start () {
        view = 1; ;
        gameStarted = false;
        turbo = 1.0f;
        isGameOver = false;
        isFolowingTarget = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isGameOver && gameStarted)
        {
            if (Input.GetKeyDown("space"))
            {
                if (view == 1)
                {
                    view = 2;
                    target = Quaternion.Euler(45, 0, 0);
                    
                }
                else if (view == 2)
                {
                    view = 1;
                    target = Quaternion.Euler(90, 0, 0);
                }
            }

            Vector3 pos = transform.localPosition;

            if (isFolowingTarget)
            {
                pos.x = targetToFollow.transform.position.x;
                pos.z = targetToFollow.transform.position.z;
                if(view == 2)
                {
                    pos.z = pos.z - 150;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                turbo = 3.0f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                turbo = 1.0f;
            }

            if (Input.GetKey("d"))
            {
                pos.x += panSpeed * Time.deltaTime * turbo;
                stopFollowingTarget();
            }

            if (Input.GetKey("a"))
            {
                pos.x -= panSpeed * Time.deltaTime * turbo;
                stopFollowingTarget();
            }

            if (Input.GetKey("s"))
            {
                pos.z -= panSpeed * Time.deltaTime * turbo;
                stopFollowingTarget();
            }

            if (Input.GetKey("w"))
            {
                pos.z += panSpeed * Time.deltaTime * turbo;
                stopFollowingTarget();
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y -= scroll * scrollSpeed * Time.deltaTime * 100f * turbo;


            pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
            pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

            pos.y = Mathf.Clamp(pos.y, minY, maxY);


            transform.localPosition = pos;
            transform.rotation = Quaternion.Lerp(transform.rotation, target,  0.1f);
        }
            
    }
    public void followTarget(GameObject o)
    {
        targetToFollow = o;
        isFolowingTarget = true;
        view = 2;
        target = Quaternion.Euler(45, 0, 0);
    }

    public void stopFollowingTarget()
    {
        isFolowingTarget = false;
    }
}
