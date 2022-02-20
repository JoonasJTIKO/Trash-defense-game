using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public Transform enemy;
    public GameObject projectile;
    Vector2 direction;
    private float timeBtwShots = 0;
    public float fireRate;
    public float range;
    List<GameObject> NearGameobjects = new List<GameObject>();
    GameObject closestObject;
    private float oldDistance = 9999;
   
    public GameObject object1, object2;     // Player ship and turret, respectively
    public float Distance_; // shows distance between 2 objects in unity

    public float force;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
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
        oldDistance = 9999;
        if (closestObject != null)
        {
            enemy = closestObject.transform;
            object1 = closestObject;
            Vector2 enemyPos = enemy.position;
            direction = enemyPos - (Vector2)transform.position;
            Distance_ = Vector2.Distance(object1.transform.position, object2.transform.position);
            if(Distance_ < range && timeBtwShots <= 0 )
            {    
                GameObject bulletIns = Instantiate(projectile, transform.position, Quaternion.identity);
                bulletIns.GetComponent<Rigidbody2D>().AddForce(direction * force);
                timeBtwShots = fireRate;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("detected");
            NearGameobjects.Add(col.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("undetected");
            NearGameobjects.Remove(col.gameObject);
        }
    }
}