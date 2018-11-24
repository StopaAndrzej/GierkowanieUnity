using System;
using System.Collections.Generic;
using UnityEngine;

class NotificationSystem : MonoBehaviour
{
    static NotificationSystem instance;
    public int maxNotificationCount = 5;
    public float topMargin = 50.0f;
    public float length = 200.0f;

    List<Notification> notifications = new List<Notification>();

    public static void Notify(string message, GameObject gameObject)
    {
        instance.AddNotification(message, gameObject);
    }

    private void AddNotification(string message, GameObject gameObject)
    {
        while(notifications.Count >= maxNotificationCount)
        {
            notifications.RemoveAt(0);
        }
        Notification notification = new Notification();
        notification.message = string.Format("[{0:0.0}s] {1}", Time.time, message);
        notification.gameObject = gameObject;
        notifications.Add(notification);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Only one notification system should exist on scene!");
        }
    }

    private void OnGUI()
    {
        Rect area = new Rect(0, topMargin, length, Screen.height - topMargin);
        GUILayout.BeginArea(area);

        for(int i = 0; i < notifications.Count; i++)
        {
            if (GUILayout.Button(notifications[i].message))
            {
                notifications.RemoveAt(i);
                i--;
                // todo: Focus camera on notification game object.
            }
        }

        GUILayout.EndArea();
    }

    class Notification
    {
        public string message;
        public GameObject gameObject;
    }
}
