using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Vector3 move;
    protected Rigidbody rb;
    protected float dist = 1.3f;
    public float speed;
    protected float x;
    protected float z;
    public LayerMask groundMask;
    public bool isGrounded;
    public int jumpForce;
    public bool canMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //checks if the player is standing on ground
        if (isGrounded = Physics.Raycast(transform.position, Vector3.down, dist, groundMask))
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
        }
        else rb.useGravity = true;

        //moves the player 
        move = new Vector3(x, 0, z);
        transform.Translate(move * speed * Time.deltaTime);

        //Jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
