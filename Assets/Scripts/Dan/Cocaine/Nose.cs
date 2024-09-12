using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nose : MonoBehaviour
{
    public int Wait;
    private bool hit;
    public GameObject[] CocainePuffs;
    public ParticleSystem cokeParticleLeft;
    public ParticleSystem cokeParticleRight;
    public Transform SniffRight;
    public Transform SniffLeft;
    public float SniffTime;
    AudioSource source;
    void Start()
    {
        CocainePuffs = GameObject.FindGameObjectsWithTag("CocainePuff");
        source = GetComponent<AudioSource>();

    }
    private void OnEnable()
    {
        GameEvents.DamageEnemy += TakeDamage;
    }
    private void OnDisable()
    {
        GameEvents.DamageEnemy -= TakeDamage;
    }
    protected virtual void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target && hit == false)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(source, AudioManager.CorporateClipTags.Sniffing);
            CokeParticle();
            Debug.Log("Nose Hit");
            hit = true; // ensures nose can't be spammed
            StartCoroutine(CokeParticleStop());
            StartCoroutine(Delay());
        }
    }
    private IEnumerator Delay()
    {
        for (int i = 0; i < CocainePuffs.Length;)
        {
            if(CocainePuffs[i].tag != ("CocainePuff")) // if the tag of current index isnt CocainePuff
            {
                CocainePuffs[i].tag = ("CocainePuff"); // reset tag
                CocainePuffs[i].GetComponent<Cocaine>().cokeParticle.Stop(); // stops particle system
                CocainePuffs[i].GetComponent<Cocaine>().particleActivated = false; // stops dealing damage
            }
            i++; // counts up by one
        }
        yield return new WaitForSeconds(Wait);
        hit = false; // lets nose be shot again
    }
    private void CokeParticle()
    {
        // moves the partciles attached in the inspector towards a empty game object to give player feedback that the nose clears the patches, i used lean tween move
        cokeParticleLeft.Play();
        cokeParticleRight.Play();
        LeanTween.move(cokeParticleRight.gameObject, SniffRight, SniffTime);
        LeanTween.move(cokeParticleLeft.gameObject, SniffLeft, SniffTime);

    }
    IEnumerator CokeParticleStop()
    {
        yield return new WaitForSeconds(5f);
        cokeParticleLeft.Stop();
        cokeParticleRight.Stop();
    }
}
