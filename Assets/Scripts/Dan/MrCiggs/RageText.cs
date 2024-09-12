using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RageText : UiManager
{
    public TextMeshProUGUI rageText;
    private void OnEnable()
    {
        GameEvents.RageIncrease += UpdateRage;
        //GameEvents.CurrentHealth += CurrentHealth;
    }
    private void OnDisable()
    {
        GameEvents.RageIncrease -= UpdateRage;
        //GameEvents.CurrentHealth -= CurrentHealth;
    }
    public void UpdateRage(float rage)
    {
        rageText.text = "Rage: " + rage.ToString();
    }
}
