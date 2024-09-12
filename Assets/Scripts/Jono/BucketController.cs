using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public float ForceMulti;
    private GameObject Player;
    Vector3 Direction;
    private int damage;
    private bool Grounded;
    public bool IsMoving;
    public Rigidbody MyRb;
    private float GroundTimer;
    // Start is called before the first frame update
    void Start()
    {
        GroundTimer = 2;
            Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsMoving)
        //{
        //    GroundTimer -= Time.deltaTime;
        //    if (GroundTimer <= 0)
        //    {
        //        GroundTimer = 2;
        //        IsMoving = false;
        //    }

        //}        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!Grounded)
            {
                StartCoroutine(KnockBack());
                damage = 10;
                GameEvents.DamagePlayer(damage);
                Debug.Log("Bonk");
            }            
                
        }
        if (collision.gameObject.tag == "Ground")
        {
            StartCoroutine(GroundSet());
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KillBox")
        {            
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {   
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);        
    }
    private IEnumerator GroundSet()
    {
        //GameEvents.OnRuralplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.RuralClipTags.BucketLand);
        yield return new WaitForSeconds(2);
        Grounded = true;
    }
    private IEnumerator KnockBack()
    {
        Direction = new Vector3(-Player.transform.position.x, 10, -Player.transform.position.z);
        Player.GetComponent<PlayerMovement>().velocity = Direction.normalized * ForceMulti;
        GameEvents.OnRuralplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.RuralClipTags.PlayerHitByBucket);

        LeanTween.value(Player.GetComponent<PlayerMovement>().velocity.x, 0, 2f)
            .setOnUpdate((float val) => Player.GetComponent<PlayerMovement>().velocity.x = val);

        LeanTween.value(Player.GetComponent<PlayerMovement>().velocity.z, 0, 2f)
            .setOnUpdate((float val) =>
            {
                Player.GetComponent<PlayerMovement>().velocity.z = val;
                //Debug.Log(val);
            });

        yield return null;
    }
    
}
