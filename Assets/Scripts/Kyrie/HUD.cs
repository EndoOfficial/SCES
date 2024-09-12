
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;


//// simple example of an event-driven UI script 
//// attached to a UI canvas that represents the HUD

//public class HUD : MonoBehaviour
//{
//    public TextMeshProUGUI HealthLevel;         // UI element set in inspector
//    public Image HealthIndicator;               // UI element set in inspector

//    public Color HighHealthColour = Color.green;
//    public Color LowHealthColour = Color.red;

//    public float LowHealthPercent = 50.0f;      // HealthIndicator changes colour when below this


//    }


//    // handler for OnHealthChanged event, which is fired whenever health or max health is changed in-game
//    private void OnHealthChanged(int newHealth, int maxHealth)
//    {
//        HealthLevel.text = newHealth.ToString();

//        float healthPercent = (float)newHealth / (float)maxHealth;

//        if (healthPercent < LowHealthPercent)
//            HealthIndicator.color = LowHealthColour;
//        else
//            HealthIndicator.color = HighHealthColour;
//    }
//}