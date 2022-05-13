using UnityEngine;
using System.Collections;

public class RaycastShootComplete : MonoBehaviour
{

    public int gunDamage = 1;                                           
    public float fireRate = 0.25f;                                       
    public float weaponRange = 50f;                                       
    public float hitForce = 100f;                                        
    public Transform gunEnd;                                           
    private Camera fpsCam;                                                
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);   
    private AudioSource gunAudio;                                        
    private LineRenderer laserLine;                                        
    private float nextFire;                                                


    void Start()
    {
       
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update()
    {
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

          
            RaycastHit hit;

           
            laserLine.SetPosition(0, gunEnd.position);

            
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
               
                laserLine.SetPosition(1, hit.point);

                
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                
                if (health != null)
                {
                  
                    health.Damage(gunDamage);
                }
                   if (hit.rigidbody != null)
                {
                    
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }


    private IEnumerator ShotEffect()
    {
       
        gunAudio.Play();

        
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}