using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class turretShoot : MonoBehaviour
    {
        [SerializeField]
        private Transform enemy;
        [SerializeField]
        private GameObject projectile;
        private Vector2 direction;
        private float timeBtwShots = 0;
        [SerializeField]
        private float fireRate;
        [SerializeField]
        private float range;
        List<GameObject> NearGameobjects = new List<GameObject>();
        GameObject closestObject;
        private float oldDistance = 9999;
        private Animator anim;
    
        [SerializeField]
        private GameObject object1, object2;     // Player ship and turret, respectively
        private float Distance_; // shows distance between 2 objects in unity

        [SerializeField]
        private float force;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }
    
        // Update is called once per frame
        void Update()
        {
            if(closestObject == null)
            {
                foreach (GameObject g in NearGameobjects)
                {
                    float dist = Vector3.Distance(this.gameObject.transform.position, g.transform.position);
                    if (dist < oldDistance)
                    {
                        closestObject = g;
                        oldDistance = dist;
                    }
                }
            }
            oldDistance = 9999;
            if (closestObject != null)
            {
                enemy = closestObject.transform;
                object1 = closestObject;
                Vector2 enemyPos = enemy.position;
                direction = enemyPos - (Vector2)transform.position;
                Distance_ = Vector2.Distance(object1.transform.position, object2.transform.position);
                transform.up = direction;
                if(timeBtwShots <= 0 )
                {    
                    if(anim != null)
                    {
                        anim.SetBool("Shoot", true);
                    }
                    GameObject bulletIns = Instantiate(projectile, (Vector2)transform.position + direction.normalized, transform.rotation);
                    bulletIns.GetComponent<Rigidbody2D>().AddForce(direction * force);
                    timeBtwShots = 1 / fireRate;
                }
                else
                {
                    if(anim != null)
                    {
                        anim.SetBool("Shoot", false);
                    }
                    timeBtwShots -= Time.deltaTime;
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                NearGameobjects.Add(col.gameObject);
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                NearGameobjects.Remove(col.gameObject);
                if(col.gameObject == closestObject)
                {
                    closestObject = null;
                }
            }
        }
    }
}