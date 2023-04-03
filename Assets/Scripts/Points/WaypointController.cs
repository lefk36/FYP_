using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int waypointIndex = 0;
    private float minDistance = 0.1f;
    private int lastWaypointIndex;
    int randomIndex;

    [SerializeField]
    private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[waypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = Time.deltaTime * speed;

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, velocity);

        CheckDistanceWaypoint(distance);
    }

   private void CheckDistanceWaypoint(float currentDistance)
    {
        
           

            if (currentDistance <= minDistance)
            {
            targetWaypoint = waypoints[waypointIndex];
            waypointIndex++;
            UpdateTargetWayPoint();
            RandomizeWaypoints();
            }
        
    }

    private void UpdateTargetWayPoint()
    {
       
        //waypointIndex = randomIndex;
        if(waypoints.Count > lastWaypointIndex)
        {
            waypointIndex = 0;
        }
        //targetWaypoint = waypoints[randomIndex];
    }

    private void RandomizeWaypoints()
    {
        System.Random randomIndex = new System.Random();
        int n = waypoints.Count;
        while (n > 1)
        {
            n--;
            int k = randomIndex.Next(n + 1);
            Transform value = waypoints[k];
            waypoints[k] = waypoints[n];
            waypoints[n] = value;

        }
    }
    }
