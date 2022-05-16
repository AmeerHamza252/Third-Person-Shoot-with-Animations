using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range=100.0f;
    public float damage=10.0f;
    public GameObject tps;
    // Start is called before the first frame update
    
    void Update()
    {
        //OnDrawGizmosSelected();
       if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(tps.transform.position,tps.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Debug.DrawRay(tps.gameObject.transform.position, tps.transform.forward, Color.blue);
    //}
    //void OnDrawGizmosSelected()
    //{
    //    // Draws a 5 unit long red line in front of the object
    //    Gizmos.color = Color.red;
    //    Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
    //    Gizmos.DrawRay(transform.position, direction);
    //}
}
