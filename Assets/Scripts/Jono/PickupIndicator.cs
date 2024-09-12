using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIndicator : MonoBehaviour
{
    public GameObject Player;
    public GameObject Indicator;
    //public GameObject PickUp;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;

        if(GameObject.FindGameObjectsWithTag("Pickup").Length <= 0)
        {

            Indicator.SetActive(false);
            //PickUp = null;
        }

        if (GameObject.FindGameObjectsWithTag("Pickup").Length >= 1)
        {
            Indicator.SetActive(true);
            //PickUp = GameObject.FindGameObjectWithTag("Pickup");
            transform.LookAt(GameObject.FindGameObjectWithTag("Pickup").transform);
        }
    }
}
