using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObjectToList : MonoBehaviour {

    public GameObject itemTemplate;
    public GameObject content;
    public static int number = 0;
    public Button[] buttons;
    public int maxNumber = 6;

    public void addItem(GameObject itemToAdd)
    {
        setParents(null);
        var copy = Instantiate(itemTemplate);
        string textToSet = "New " + itemToAdd.name + " " + number++;
        copy.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = textToSet;
        copy.transform.SetParent(content.transform, false);
        setParents(content);
        buttons = content.GetComponentsInChildren<Button>();
        copy.transform.localScale = new Vector3(1, 1, 1);
        copy.GetComponent<ListItem>().target = itemToAdd;
    }

    public void setParents(GameObject o)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null)
            {
            
                if (i >= maxNumber - 1)
                {
                    buttons[i].transform.SetParent(null, false);
                    Destroy(buttons[i].gameObject);
                    continue;
                }
                if (o == null)
                {
                    buttons[i].transform.SetParent(null, false);
                }
                else
                {
                    buttons[i].transform.SetParent(o.transform, false);
                }
            }
        }
    }
    public void removeFromList(GameObject o)
    {
        Button[] buffer = buttons;
        List<Button> newButtons = new List<Button>();
        int i = 0;
        Button but = o.GetComponent<Button>();
        foreach (Button b in buttons)
        {
            if (b != but)
            {
                newButtons.Add(b);
            }
            i++;
        }
        buttons = newButtons.ToArray();
    }
}
