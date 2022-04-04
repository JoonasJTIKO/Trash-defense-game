using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float speed = 10f;
        Vector2 lastClickedPos;
        bool moving;
        bool carryingTrash;

        private float xpositionToFlip;

        private GameObject attachedTrash;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxis("Fire1") > 0f)
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
                if (transform.position.x < lastClickedPos.x)
                {
                    // transform.localScale = new Vector2(-1.5f, transform.localScale.y);
                    this.GetComponent<SpriteRenderer>().flipX = true;
                    // if (carryingTrash)
                    // {
                    //     attachedTrash.transform.position = new Vector2(System.Math.Abs(xpositionToFlip), 0f);
                    // }
                }
                else
                {
                    // transform.localScale = new Vector2(1.5f, transform.localScale.y);
                    this.GetComponent<SpriteRenderer>().flipX = false;
                    // if (carryingTrash)
                    // {
                    //     attachedTrash.transform.position = new Vector2(System.Math.Abs(xpositionToFlip) * -1, 0f);
                    // }               
                }
                // transform.right = lastClickedPos - new Vector2(transform.position.x, transform.position.y);
            }

            if (moving && (Vector2)transform.position != lastClickedPos)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            }
            else
            {
                moving = false;
            }
            // if (transform.right != (lastClickedPos - new Vector2(transform.position.x, transform.position.y))){
            //     transform.right = lastClickedPos - new Vector2(transform.position.x, transform.position.y);
            // }
        }

        public void setChildObject(GameObject a)
        {
            attachedTrash = a;
            carryingTrash = true;
            xpositionToFlip = attachedTrash.transform.position.x;
        }
    }
}
