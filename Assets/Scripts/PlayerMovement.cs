using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed=10.0f;
    public float horizontal;
    public float vertical;
    private Rigidbody rb;
    private Animator animator;
    //private Vector3 movDir;
    //public GameObject projectilePrefab;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        //Shoot();

    }
    private void HandleMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        animator.SetFloat("Input Magnitude", horizontal);
        animator.SetFloat("Input Magnitude2", vertical);
        if (Input.GetKey(KeyCode.Q)
            &&Input.GetKey(KeyCode.W)
            )
        {
            animator.SetBool("running", true);
        }
        else {

            animator.SetBool("running", false);
        
        }
    }
    //void Shoot()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    //    }
    //}


}
