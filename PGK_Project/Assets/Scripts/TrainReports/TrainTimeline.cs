using UnityEngine;

class TrainTimeline : MonoBehaviour
{
    public Vector2 measures = new Vector2(200.0f, 20.0f);
    public float margin = 10.0f;
    public DummyTrainData data;

    private void Awake()
    {
        data = gameObject.GetComponent<DummyTrainData>();
    }

    private void OnGUI()
    {
        int timelineId = 0;

        // todo: Feed real world data.

        // foreach station
        //  TimelineGUI(timelineId);
        //  foreach train
        //      TrainGUI(timelineId, distance);
        //  timelineId++;

        // Dummy data.
        if (data != null && GameState.isStarted)
        {
            foreach (DummyStation station in data.stations)
            {
                TimelineGUI(timelineId);
                foreach (DummyTrain train in station.trains)
                {
                    TrainGUI(timelineId, train.timeToSpawn, station.maxTime, null);
                }
                timelineId++;
            }
        }
    }

    private Vector2 GetTimelinePosition(int timelineId)
    {
        float x = Screen.width / 2 - measures.x / 2;
        float y = margin + measures.y * timelineId;
        return new Vector2(x, y);
    }

    private void TimelineGUI(int timelineId)
    {
        Vector2 position = GetTimelinePosition(timelineId);
        DummyStation station = data.stations[timelineId];
        Rect box = new Rect(position.x, position.y, measures.x, measures.y);
        GUI.Box(box, "");
    }

    private void TrainGUI(int timelineId, float distance, float maxDistance, GameObject train)
    {
        Vector2 position = GetTimelinePosition(timelineId);
        float trainProgress = distance / maxDistance;
        Rect trainBox = new Rect(position.x + trainProgress * (measures.x - measures.y), position.y, measures.y, measures.y);

        if (GUI.Button(trainBox, "T"))
        {
            if (train != null)
            {
                // todo: Focus camera on train.
            }
        }
    }
}
