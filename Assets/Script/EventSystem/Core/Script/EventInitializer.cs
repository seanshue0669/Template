using EventSO;
using UnityEngine;

public class EventInitializer : MonoBehaviour
{
    public EventListSO eventListSO;

    private void Awake()
    {
        if (eventListSO == null)
        {
            Debug.LogError("EventListSO is not assigned in the Inspector.");
            return;
        }
        EventSystem.Instance.Initialize(eventListSO);
    }
}
