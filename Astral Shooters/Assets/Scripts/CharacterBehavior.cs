using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 400f;

    public bool grounded = false;

    private float ySpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Forward movement
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        //Left movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -1 * moveSpeed * Time.deltaTime;
        }

        //Right movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        //Backwards movement
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -1 * moveSpeed * Time.deltaTime;
        }

        //Jump movement
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                grounded = true;
            }
        }
        
        void onCOllisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                grounded = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
        }
    }
}
