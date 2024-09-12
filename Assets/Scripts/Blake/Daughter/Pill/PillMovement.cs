using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillMovement : MonoBehaviour
{
    public float speed;
    private Transform player;
    public Vector3 lobDirection;
    public Rigidbody rb;
    public Vector3 direction;
    public bool grounded;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        lobDirection = player.position - transform.position;
        rb.AddForce(new Vector3(lobDirection.x * 0.3f, 6, lobDirection.z * 0.3f), ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) // if Ground tag
        {
            grounded = true;
        }
    }
    void Update()
    {
        if (grounded)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    public void DisableIt()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<PillMovement>().enabled = false;
    }
}
