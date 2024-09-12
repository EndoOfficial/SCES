using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceLessSoundsController : MonoBehaviour
{
    public GameObject Player;
    public float RotateSpeed;
    public float timer;
    public GameObject FacelessFella;
    public Transform SpawnPoint;
    public bool CanSpawn;
    public bool Blocked;
    public bool Spawned;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //transform.SetParent(Player.gameObject.transform);
        timer = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        transform.position = Player.transform.position;
        timer -= Time.deltaTime;
        RaycastHit hit;
        Physics.Raycast(SpawnPoint.position, transform.forward, out hit);
        //Physics.Raycast(Player.transform.position, SpawnPoint.position - Player.transform.position, out hit);
        
        
        //Debug.Log(hit.collider.gameObject.name);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;

        if (timer < 0 && CanSpawn && !Blocked)
        {
            if (!Spawned)
            {
                StartCoroutine(SpawnFaceless());
            }
                      
            
            
        }

        if(hit.collider.tag == "Player" && !Blocked)
        {
            
            CanSpawn = true;
            Debug.DrawRay(SpawnPoint.position, transform.position - SpawnPoint.position, Color.red);
            

        }
        if(hit.collider.tag == "Ground")
        {
            CanSpawn = false;
            Debug.DrawRay(SpawnPoint.position, transform.position - SpawnPoint.position, Color.green);
            
            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Blocked = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Blocked = false;
        }
    }

    public IEnumerator SpawnFaceless()
    {
        Spawned = true;
        CanSpawn = false;
        RotateSpeed = 0;
        var NewFaceless = Instantiate(FacelessFella, this.gameObject.transform.GetChild(0).position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        timer = Random.Range(1f, 3f);
        CanSpawn = true;
        RotateSpeed = 50;
        Spawned = false;
    }
}
