using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightCross : MonoBehaviour
{

    public List<GameObject> firstDirection; //lista jest tworzona z palca za kazdym razem gdy tworzymy skrzyzowanie przypisujemy sygnalizatory ktore maja sie zmieniac na ten sam kolor swiatla do jednej listy
    public List<GameObject> secondDirection; //lista swiatel ktore maja zmieniac sie przeciwnie do pierwszej listy


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject light in firstDirection) //jesli jakis z elementow pierwszej listy zmieni kolor to zmien dla wszystkich z drugiej
        {
            if (light.GetComponent<TrafficLight>().isGreen)
            {
                foreach (GameObject light1 in secondDirection)
                {
                    if(light1.GetComponent<TrafficLight>().isGreen == true)
                    {
                        light1.GetComponent<TrafficLight>().changeLights = true;
                        light1.GetComponent<TrafficLight>().timeLeftForChange = light1.GetComponent<TrafficLight>().timeConstant;
                    }
                    light1.GetComponent<TrafficLight>().isGreen = false;
                }
            }
            else
            {
                foreach (GameObject light1 in secondDirection)
                {
                    if (light1.GetComponent<TrafficLight>().isGreen == false)
                    {
                        light1.GetComponent<TrafficLight>().changeLights = true;
                        light1.GetComponent<TrafficLight>().timeLeftForChange = light1.GetComponent<TrafficLight>().timeConstant;
                    }
                    light1.GetComponent<TrafficLight>().isGreen = true;
                }
            }
        }
    }
}