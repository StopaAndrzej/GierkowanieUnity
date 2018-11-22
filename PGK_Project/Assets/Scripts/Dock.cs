using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : MonoBehaviour {

    public Animator anim;
    public GameObject panel;
    public int tonarz;
    public GameObject collider;
    private bool animVar;
    private bool panelAble;
    // Use this for initialization
    void Start () {
        panel.SetActive(false);
        anim = GetComponent<Animator>();
        tonarz = 0;
        animVar = true;
        panelAble = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (panelAble)
        {
            if (collider.GetComponent<DockPakageOnTruck>().isDocked)
            {
                Debug.Log("Wchodzi do update");
                if (animVar)
                {
                    Animate();
                    animVar = false;
                }
            }
            else
            {
                animVar = true;
            }
        }
            
	}

    void Animate()
    {
        Debug.Log("Laduj kontener!");
        anim.Play("DockPakage");
    }

    void OnMouseDown()
    {
        Debug.Log("Otworz panel doku!");
        panelAble = true;
        panel.SetActive(true);
    }
}
