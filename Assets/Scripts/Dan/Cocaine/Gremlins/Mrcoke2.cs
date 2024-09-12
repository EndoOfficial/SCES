using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mrcoke2 : MonoBehaviour
{
    public float Cooldown;
    private GameObject[] targets;
    public int speed;
    public float AnimTime;
    int targetIndex;
    public GameObject target;
    public int damage;
    private bool hit;
    public LayerMask Player;
    public float radius;
    public GameObject CokeChecker;
    public bool Melee;
    private NavMeshAgent _agent;
    private Animator anim;
    private Transform PlayerTransform;
   
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        CokeChecker = GameObject.Find("CocaineCheck");
        targets = GameObject.FindGameObjectsWithTag("CocainePuff");

        StartCoroutine(GetTargets());

        if (targets.Length > 0)
        {
            targetIndex = Random.Range(0, targets.Length);
            target = targets[targetIndex];
            //_agent.SetDestination(target.transform.position);
        }

        

    }
    public void Update()
    {

        PlayerTransform = GameObject.FindWithTag("Player").transform;
        //transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        //transform.position += transform.forward * speed * Time.deltaTime;
        if (Physics.CheckSphere(transform.position, radius, Player))
        {
            if (!hit)
            {
                
                anim.SetTrigger("Puff");
                hit = true;
                StartCoroutine(HitDelay());
                GameEvents.DamagePlayer?.Invoke(damage);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other != target && target != null)
        //{
        //    return;
        //}
        if (other.gameObject.CompareTag("CocainePuff"))
        {

            anim.SetTrigger("Puff");
            other.gameObject.tag = ("Untagged");  
            Retarget(); // Ensures that the patch can't be targeted
            GameEvents.CokeTarget?.Invoke(); // Event to retarget if need be
            
        }

       
    }
    private IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(Cooldown);
        hit = false;
    }
    private void OnEnable()
    {
        GameEvents.CokeTarget += Retarget;
    }
    private void OnDisable()
    {
        GameEvents.CokeTarget -= Retarget;
    }
    public void Retarget()
    {
        if (target != null)
        {
            if (target.tag != ("CocainePuff")) // first checks if the current target is no longer a valid target
            {
                StartCoroutine(GetTargets()); // starts the retargetting coroutine
            }
        }
        else
        {
            _agent.SetDestination(PlayerTransform.transform.position);
        }
    }
    public IEnumerator GetTargets()
    {
        yield return new WaitForSeconds(AnimTime); // waits until the set time (animation time)
        targets = GameObject.FindGameObjectsWithTag("CocainePuff"); // re-gets the places that can be puffed in
        if (targets.Length <= 0)
        {
            _agent.SetDestination(PlayerTransform.transform.position);
            yield break;
        }
        targetIndex = Random.Range(0, targets.Length); // re-sets the target array
        target = targets[targetIndex]; // gets a new target
        
        _agent.SetDestination( target.transform.position);
        //_agent.speed += 5;

    }
    
}