using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace towerdefense
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        public float speed = 10f;
        Vector2 lastClickedPos;
        bool moving;

        private Vector2 moveInput;

        [Range(1.3f,2f)]
        public float boostAmount;

        private Vector2 joystickOriginalPosition;

        private float xpositionToFlip;

        [SerializeField]
        private PlayerInputAction playerAction;

        private GameObject attachedTrash;
        private Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            joystickOriginalPosition = new Vector2(0.0f, 0.0f);
        }

        void Awake()
        {
            playerAction = new PlayerInputAction();
        }

        private void OnEnable()
        {
            playerAction.Player.Enable();
        }

        private void OnDisable()
        {
            playerAction.Player.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            joystickMove();
            restrictMove();
        }

        //restrict player character from moving beyond limits
        private void restrictMove()
        {
            if (this.transform.position.x < -8.5f)
            {
                this.transform.position = new Vector3(-8.5f, this.transform.position.y, 0);
            }
            if (this.transform.position.x > 8.5f)
            {
                this.transform.position = new Vector3(8.5f, this.transform.position.y, 0);
            }

            if (this.transform.position.y < -4.5f)
            {
                this.transform.position = new Vector3(this.transform.position.x, -4.5f, 0);
            }
            if (this.transform.position.y > 4.5f)
            {
                this.transform.position = new Vector3(this.transform.position.x, 4.5f, 0);
            }
        }

        private void joystickMove()
        {
            moveInput = playerAction.Player.Move.ReadValue<Vector2>();
            if (moveInput != Vector2.zero)
            {
                moving = true;
                anim.SetBool("Walking", true);
                if (moveInput.x > 0)
                {
                    this.GetComponent<SpriteRenderer>().flipX = false;
                    if (attachedTrash)
                    {
                        attachedTrash.transform.localPosition = new Vector2(0.3f, 0f);
                    }
                }

                else if (moveInput.x < 0)
                {
                    this.GetComponent<SpriteRenderer>().flipX = true;
                    if (attachedTrash)
                    {
                        attachedTrash.transform.localPosition = new Vector2(-0.3f, 0f);
                    }    
                }                
            }

            if (moveInput == Vector2.zero)
            {
                moving = false;
                anim.SetBool("Walking", false);
            }

            if (moving)
            {
                transform.Translate(moveInput * speed * Time.deltaTime);
            }
        }

        //attach trash object to player
        public void setChildObject(GameObject a)
        {
            attachedTrash = a;
        }

        public void removeChildObject()
        {
            attachedTrash = null;
        }

        public void startSpeedBoost()
        {
            StartCoroutine(speedBoost());
        }

        public IEnumerator speedBoost()
        {
            speed = speed * boostAmount;
            yield return new WaitForSeconds(4.0f);
            speed = speed / boostAmount;
        }
    }
}
