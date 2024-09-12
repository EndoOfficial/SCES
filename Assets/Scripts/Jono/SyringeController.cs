using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeController : MonoBehaviour
{
    public ConfigurableJoint CFGJ;
    public Rigidbody MyRB;
    public Rigidbody MyChildRB;
    public GameObject Child;
    public GameObject ChosenAttach;
    public float SpringForce;
    public float speed;
    private float angle;
    private float angle2;
    public bool IsGrounded;
    public bool CanJumpToRoof;
    public bool Jumping;
    public GameObject Target;
    public Vector3 TargetPos;
    public Vector3 ThisPos;
    public Vector3 AttachPos;

    //public List<GameObject> AttachmentPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CFGJ = GetComponentInChildren<ConfigurableJoint>();
        Target = GameObject.FindGameObjectWithTag("Player");

        //AttachmentPoints.AddRange(GameObject.FindGameObjectsWithTag("AttachmentPoints"));
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Child.GetComponent<GroundCheck>().Grounded;

        if (Child.GetComponent<GroundCheck>().Grounded == false)
        {
            MyRB.AddRelativeForce(-transform.forward * 2.5f);
            MyChildRB.AddRelativeForce(-transform.forward * 2.5f);
        }
        else
        {
            MyRB.AddForce(transform.up * SpringForce);
        }

        if (!Jumping)
        {
            TargetPos = Target.transform.position;
            ThisPos = transform.position;
            TargetPos.x = TargetPos.x - ThisPos.x;
            TargetPos.z = TargetPos.z - ThisPos.z;
            angle = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Roof" && CanJumpToRoof)
        {


            if (Random.Range(0, 100) < 8)
            {
                //ChosenAttach = AttachmentPoints[Random.Range(0, AttachmentPoints.Count)];
                SpringForce = 800f;
                Jumping = true;
                transform.rotation = Quaternion.Euler(Random.Range(-50, 50), 0, Random.Range(-50, 50));
                MyRB.AddForce(transform.up * SpringForce);
                CanJumpToRoof = false;



            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Roof" && IsGrounded)
        {
            Jumping = false;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Roof" && !CanJumpToRoof)
        {
            transform.SetParent(collision.gameObject.transform);
            MyRB.isKinematic = true;
            MyRB.useGravity = false;
            CanJumpToRoof = false;
            Debug.Log("Doink");

        }

    }

    public IEnumerator Jump()
    {
        if (IsGrounded)
        {
            yield return new WaitForSeconds(1);

            Debug.Log("Boing");
            yield return new WaitForSeconds(2);
        }

    }
}