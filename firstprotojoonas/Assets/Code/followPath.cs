using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class followPath : MonoBehaviour
    {
        private Transform[] waypoints;

        [SerializeField]
        private float speed = 1;

        private GameObject parentTest2;

        private int currentWaypoint = 0;
        
        void Start()
        {
            waypoints = GameObject.Find("Waypoints").GetComponent<WaypointList>().waypointList;
            transform.position = waypoints[currentWaypoint].transform.position;
        }

        void Update()
        {
            Move();
        }

        private void Move()
        {
            if(currentWaypoint <= waypoints.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
                if (transform.position == waypoints[currentWaypoint].transform.position)
                {
                    currentWaypoint += 1;
                }
            }
        }
    }
}

