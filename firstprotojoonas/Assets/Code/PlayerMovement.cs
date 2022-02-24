using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float speed = 10f;
        Vector2 lastClickedPos;
        bool moving;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxis("Fire1") > 0f) {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }

            if (moving && (Vector2)transform.position != lastClickedPos) {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            } else {
                moving = false;
            }
        }
    }
}
