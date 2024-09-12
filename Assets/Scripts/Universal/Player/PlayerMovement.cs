using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float Movement;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float dist;
    public GameObject checkBox;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckBox(checkBox.transform.position, new Vector3(.5f, .5f, .5f) * dist, Quaternion.identity, groundMask);

        // stop falling if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // get move direction
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            Movement = 1;
            StopAllCoroutines();
        }
        if (x == 0 && z == 0)
        {
            StartCoroutine(StopWalking());
        }

        //get a Vector3 and set it to the direction of movement
        Vector3 move = transform.right * x + transform.forward * z;

        //apply Vector3 to character controller
        controller.Move(move * speed * Time.deltaTime);

        //if jumped and is grounded, Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // apply gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    private IEnumerator StopWalking()
    {
        yield return new WaitForSeconds(0.05f);
        Movement = 0;
    }
}
