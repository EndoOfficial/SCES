using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private int damage = 10;
    public GameObject respawnPos;
    private CharacterController chara;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.OnRuralplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.RuralClipTags.Splash);
            chara = other.GetComponent<CharacterController>();
            chara.enabled = false;
            other.transform.position = respawnPos.transform.position;
            chara.enabled = true;
            if(other.GetComponent<Health>().health > damage)
            {
                GameEvents.DamagePlayer?.Invoke(damage);
            }
            else
            {
                GameEvents.DamagePlayer?.Invoke(10);
            }
        }
    }
}
