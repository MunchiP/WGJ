using System.Collections;
using UnityEngine;

public class WaypointNPCMover : MonoBehaviour
{
    public float moveSpeed = 2f;
        
    public bool IsWaiting { get => _isWaiting; set => _isWaiting=value; }

    [SerializeField]
    private Transform waypointParent;
    [SerializeField]
    private bool _isWaiting = true;
    
    private Transform[] waypoints;
    private int currentWaypointIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform parent = transform.parent.transform;
        waypointParent = parent.Find("WaypointParent");

        waypoints = new Transform[waypointParent.childCount];

        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_isWaiting) //TODO: Include Gamepause when its implemented
        {
            return;
        }

        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position)< 0.1f)
        {
            currentWaypointIndex = Mathf.Min(currentWaypointIndex + 1, waypoints.Length -1);
        }

    }

    
}
