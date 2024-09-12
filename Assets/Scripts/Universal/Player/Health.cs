using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public Text text;
    private AudioCycle audioCycle;

    private void OnEnable()
    {
        GameEvents.DamagePlayer += DamagePlayer;
    }

    private void OnDisable()
    {
        GameEvents.DamagePlayer -= DamagePlayer;    
    }

    private void Start()
    {
        audioCycle = GetComponent<AudioCycle>();
    }

    public void DamagePlayer(int damage)
    {
        //FindObjectOfType<AudioManager>().Play("Hurt");
        // reduce health then update it

        if (PlayerPrefs.HasKey("Difficulty"))
        {
            if(PlayerPrefs.GetInt("Difficulty") == 0)
            {
                var tempdamage = damage * 0.5f;
                damage = (int)tempdamage;
            }
            
            if(PlayerPrefs.GetInt("Difficulty") == 2)
            {
                var tempdamage = damage * 1.5f;
                damage = (int)tempdamage;
            }
        }

        damage = Mathf.Clamp(damage, 1, 100000);
        health -= damage;
        GameEvents.OnUniversalplayAudio?.Invoke(audioCycle.GetNextAudioSource(), AudioManager.UniversalClipTags.PlayerHurt);
        if (health <= 0f)
        {
            text.text = health.ToString();
            //GameObject.Find("Player").SendMessage("Finnish");
            // stops time for a game over screen instead of destroying the player and the attached camera
            PlayerDeath();
        }
        else
        {
            // update the health text
            text.text = health.ToString();  
        }
    }
    public void PlayerDeath()
    {
        GameEvents.OnGameOver?.Invoke(true);
    }

}
