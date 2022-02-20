using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class followPath : MonoBehaviour
    {
        [SerializeField]
        private Transform[] waypoints;

        [SerializeField]
        private float speed = 1;

        private int currentWaypoint = 0;
        // Start is called before the first frame update
        
        void Start()
        {
            transform.position = waypoints[currentWaypoint].transform.position;
            foreach (Transform child in waypoints)
            {
                child.SetParent(null, true);
            }
        }

        // Update is called once per frame
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

