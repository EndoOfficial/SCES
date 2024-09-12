using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyeText : MonoBehaviour
{
    private int PlayerHealth = 100;
    private TextMeshProUGUI Hint;

    private void Start()
    {
        Hint = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        GameEvents.DamagePlayer += DamagePlayer;
    }

    private void OnDisable()
    {
        GameEvents.DamagePlayer -= DamagePlayer;
    }


    public void DamagePlayer(int damage)
    {
        PlayerHealth -= damage;
        if(PlayerHealth <= 25)
        {
            Hint.enabled = true;
        }
    }
}
