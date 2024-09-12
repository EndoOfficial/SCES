using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject GameController;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            //GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.PickUp);
            GameController = GameObject.FindGameObjectWithTag("GameManager");
            GameController.GetComponent<GameController>().ItemsCollected = GameController.GetComponent<GameController>().ItemsCollected + 1;
            Destroy(gameObject);
        }
    }
}
