using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nicotine : MonoBehaviour
{
    public Collider Col;
    Rigidbody rb;
    AudioSource audioSource;
    private float rage = -20f;
    private float rotation = 1.5f;

    private void Start()
    {
         audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.Rotate(0f, rotation, 0f);
    }
    private void OnEnable()
    {
        GameEvents.LevelWin += DestroyNicotine;
    }
    private void OnDisable()
    {
        GameEvents.LevelWin -= DestroyNicotine;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            //GameEvents.OnplayAudio?.Invoke(audioSource, AudioManager.ClipTags.NicotinePickUp);
            //FindObjectOfType<AudioManager>().Play("Upgrade");
            GameEvents.Nicotine?.Invoke();
            GameEvents.RageIncrease?.Invoke(rage);
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.isKinematic = true;
            Col.enabled = false;
        }
    }
    public void DestroyNicotine()
    {
        Destroy(gameObject);
    }
}