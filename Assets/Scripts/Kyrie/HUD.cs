
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// simple example of an event-driven UI script 
// attached to a UI canvas that represents the HUD

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI HealthLevel;         // UI element set in inspector
    public RawImage HealthIndicator;               // UI element set in inspector

    public Color HighHealthColour = Color.green;
    public Color LowHealthColour = Color.red;

    public float LowHealthPercent = 50.0f;      // HealthIndicator changes colour when below this


    private void OnEnable()
    {
        GameEvents.OnHealthChanged += OnHealthChanged;      // subscribe to event
    }

    private void OnDisable()
    {
        GameEvents.OnHealthChanged -= OnHealthChanged;      // unsubscribe from event
    }


    // handler for OnHealthChanged event, which is fired whenever health or max health is changed in-game
    private void OnHealthChanged(float newHealth, float maxHealth)
    {
        HealthLevel.text = newHealth.ToString();

        float healthPercent = newHealth / maxHealth;

        if (healthPercent < LowHealthPercent)
            HealthIndicator.color = LowHealthColour;
        else
            HealthIndicator.color = HighHealthColour;
    }
}