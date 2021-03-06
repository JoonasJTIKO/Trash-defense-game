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
        private float originalSpeed;
        private bool slowed = false;
        private float slowedTime;

        private GameObject parentTest2;

        private int currentWaypoint = 0;
        
        void Start()
        {
            originalSpeed = speed;
            waypoints = FindObjectOfType<WaypointList>().waypointList;
            transform.position = waypoints[currentWaypoint].transform.position;
        }

        void FixedUpdate()
        {
            Move();
            if(slowed)
            {
                slowedTime -= Time.deltaTime;
                if(slowedTime <= 0)
                {
                    slowed = false;
                    speed = originalSpeed;
                }
            }
        }

        // will move towards the current target waypoint, and start moving to the next one once it reaches it
        // waypoints must be in the desired order in the list
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
        
        // will change the speed of the enemy for an amount of time, unless enemy is already affected
        public void SetSpeed(float changeAmount, float slowTime)
        {
            if(!slowed)
            {
                speed = speed / changeAmount;
                slowedTime = slowTime;
                slowed = true;
            }
        }
    }
}

